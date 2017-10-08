using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telephone_Sensor_Application.Forms;
using Telephone_Sensor_Application.SensorDataService;
using Telephone_Sensor_Application.Utility;
using WeifenLuo.WinFormsUI.Docking;

namespace Telephone_Sensor_Application
{
    public partial class MainForm : Form
    {

        //目前支持的传感器类型，增加的话需要在这里更改
        //public AccelerateForm accelerometerForm = null;
        //public MagneticForm magneticForm = null;
        //public GyroscopeForm gyroscopeForm = null;
        //public GravityForm gravityForm = null;
        public Form3D accelerometerForm = null;
        public Form3D magneticForm = null;
        public Form3D gyroscopeForm = null;
        public Form3D gravityForm = null;
        
        public SettingForm settingForm = null;

        private bool firstdata_b = true;
        private ulong firstdataTime;
        private SensorDataTable sensorDataTable;
        public static string baseFilePath;
        private string filename;

        Thread startInventoryThread;

        public MainForm()
        {
            //目前支持的传感器类型，增加的话需要在这里更改
            //accelerometerForm = new AccelerateForm();
            //magneticForm = new MagneticForm();
            //gyroscopeForm = new GyroscopeForm();
            //gravityForm = new GravityForm();

            accelerometerForm = new Form3D("accelerometerForm", "accelerometer");
            gyroscopeForm = new Form3D("gyroscopeForm", "gyroscope");
            magneticForm = new Form3D("magneticForm", "magnetic");
            gravityForm = new Form3D("gravityForm", "gravity");


            settingForm = new SettingForm(this);

            InitializeComponent();
            sensorDataTable = new SensorDataTable();
            filename = "\\SensorData.txt";
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            windowsToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            stopToolStripMenuItem.Enabled = false;

            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath);
            baseFilePath = Path.Combine(dir.Parent.Parent.FullName, "sensor data files");
            //Debug.WriteLine(baseFilePath);

            settingForm.Show(this.dockPanel1);

        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
            //清除Queue中原有的数据
            SensorDataService1Client sensorDataService1Client = new SensorDataService1Client();
            sensorDataService1Client.ClearSensorDataQueue();
            sensorDataService1Client.Close();

            startInventoryThread = new Thread(startInventory);
            startInventoryThread.IsBackground = true;
            startInventoryThread.Start();

            windowsToolStripMenuItem.Enabled = true;
            stopToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            startToolStripMenuItem.Enabled = false;
        }

        public void startInventory()
        {

            while(true)
            {
                List<SensorDataItem> sensorDataList = null;
                try
                {
                    SensorDataService1Client sensorDataService1Client = new SensorDataService1Client();
                    SensorDataItem[] sensorDataArr = sensorDataService1Client.TryDeque();
                    sensorDataService1Client.Close();
                    sensorDataList = new List<SensorDataItem>(sensorDataArr);
                }
                catch(EndpointNotFoundException e1)
                {
                    MessageBox.Show("Service is not running!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Debug.WriteLine(e1.ToString());
                }

                //Debug.WriteLine("" + sensorDataArr.Length);

                if(sensorDataList != null && sensorDataList.Count>0)
                {
                    foreach(SensorDataItem sditem in sensorDataList)
                    {
                        //记录第一次获得数据的时间
                        if(firstdata_b)
                        {
                            firstdataTime = sditem.Timestamp;
                            firstdata_b = false;
                        }
                        sditem.Timestamp -= firstdataTime;
                        this.BeginInvoke(method: new Action(() =>
                        {
                            //目前支持的传感器类型，增加的话需要在这里更改
                            switch ((SensorType)sditem.Type)
                            {
                                case SensorType.TYPE_ACCELEROMETER:
                                    if (accelerometerForm.Visible)
                                    {

                                        accelerometerForm.UpdateGraph(sditem);
                                    }
                                    break;
                                case SensorType.TYPE_GRAVITY:
                                    if (gravityForm.Visible)
                                    {
                                        gravityForm.UpdateGraph(sditem);
                                    }
                                    break;
                                case SensorType.TYPE_MAGNETIC_FIELD:
                                    if(magneticForm.Visible)
                                    {
                                        magneticForm.UpdateGraph(sditem);
                                    }
                                    break;
                                case SensorType.TYPE_GYROSCOPE:
                                    if(gyroscopeForm.Visible)
                                    {
                                        gyroscopeForm.UpdateGraph(sditem);
                                    }
                                    break;
                            }
                        }
                        ));
                        sensorDataTable.AddSensorDataInfo(sditem);
                    }
                }
                Thread.Sleep(10);
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                startInventoryThread.Abort();
                //firstdata_b = true;
                AccelerateForm.firstdata_b = true;
                this.firstdata_b = true;
                windowsToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                stopToolStripMenuItem.Enabled = false;
                startToolStripMenuItem.Enabled = true;
                settingForm.btnSensorsType.Enabled = true;
            }
            catch(Exception erro)
            {
                Debug.WriteLine(erro.ToString());
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileHelper.SaveFile(sensorDataTable.SensorsTable, baseFilePath + filename);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.RestoreDirectory = true;
            fileDialog.InitialDirectory = baseFilePath;
            fileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            fileDialog.FileName = filename.Substring(1, filename.Length - 1);
            fileDialog.RestoreDirectory = true;

            if(fileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveFileHelper.SaveFile(sensorDataTable.SensorsTable, fileDialog.FileName);
            }
        }

        public void Clear()
        {
            sensorDataTable.Clear();
            if(accelerometerForm.Visible)
            {
                accelerometerForm.Clear();
            }

            if(gravityForm.Visible)
            {
                gravityForm.Clear();
            }

            if(gyroscopeForm.Visible)
            {
                gyroscopeForm.Clear();
            }

            if(magneticForm.Visible)
            {
                magneticForm.Clear();
            }
        }

        private void dockPanel1_ActiveContentChanged(object sender, EventArgs e)
        {

        }
    }
}
