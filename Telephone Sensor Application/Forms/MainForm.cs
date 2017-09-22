using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telephone_Sensor_Application.Forms;
using Telephone_Sensor_Application.SensorDataService;
using Telephone_Sensor_Application.Utility;

namespace Telephone_Sensor_Application
{
    public partial class MainForm : Form
    {
        private AccelerateForm accelerateForm = new AccelerateForm();
        private MagneticForm magneticForm = new MagneticForm();
        private GyroscopeForm gyroscopeForm = new GyroscopeForm();
        private GravityForm gravityForm = new GravityForm();
        private bool firstdata_b = true;
        private ulong firstdataTime;
        private SensorDataTable sensorDataTable;
        private string baseFilePath;
        private string filename;

        Thread startInventoryThread;

        public MainForm()
        {
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
            Debug.WriteLine(baseFilePath);

        }

        private void accelerateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            accelerateForm.Show(this.dockPanel1);
        }

        private void gravityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gravityForm.Show(this.dockPanel1);
        }

        private void gyroscopeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gyroscopeForm.Show(this.dockPanel1);
        }

        private void magneticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            magneticForm.Show(this.dockPanel1);
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
                SensorDataService1Client sensorDataService1Client = new SensorDataService1Client();
                SensorDataItem[] sensorDataArr = sensorDataService1Client.TryDeque();
                sensorDataService1Client.Close();
                //Debug.WriteLine("" + sensorDataArr.Length);

                sensorDataList = new List<SensorDataItem>(sensorDataArr);

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
                            switch ((SensorType)sditem.Type)
                            {
                                case SensorType.TYPE_ACCELEROMETER:
                                    if (accelerateForm.Visible)
                                    {

                                        accelerateForm.UpdateAccelerateGraph(sditem);
                                    }
                                    break;
                                case SensorType.TYPE_GRAVITY:
                                    if (gravityForm.Visible)
                                    {
                                        gravityForm.UpdateGravityGraph(sditem);
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
            if(accelerateForm.Visible)
            {
                accelerateForm.Clear();
            }

            if(gravityForm.Visible)
            {
                gravityForm.Clear();
            }
        }
    }
}
