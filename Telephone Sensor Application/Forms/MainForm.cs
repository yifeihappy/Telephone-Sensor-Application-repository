using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telephone_Sensor_Application.Forms;
using Telephone_Sensor_Application.SensorDataService;

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

        Thread startInventoryThread;

        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {

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
            //清除Queue中原有的数据
            SensorDataService1Client sensorDataService1Client = new SensorDataService1Client();
            sensorDataService1Client.ClearSensorDataQueue();
            sensorDataService1Client.Close();

            startInventoryThread = new Thread(startInventory);
        }

        public void startInventory()
        {

            while(true)
            {
                List<SensorDataItem> sensorDataList = null;
                SensorDataService1Client sensorDataService1Client = new SensorDataService1Client();
                SensorDataItem[] sensorDataArr = sensorDataService1Client.TryDeque();
                sensorDataService1Client.Close();

                sensorDataList = new List<SensorDataItem>(sensorDataArr);

                if(sensorDataList != null && sensorDataList.Count>0)
                {
                    foreach(SensorDataItem sditem in sensorDataList)
                    {
                        //记录第一次获得数据的时间
                        if(firstdata_b)
                        {
                            firstdataTime = sditem.Timestamp;
                        }
                        sditem.Timestamp -= firstdataTime;
                        switch((SensorType)sditem.Type)
                        {
                            case SensorType.TYPE_ACCELEROMETER:
                                if(accelerateForm.Visible)
                                {

                                    accelerateForm.UpdateAccelerateGraph(sditem);
                                }
                                break;
                            case SensorType.TYPE_GRAVITY:
                                if(gravityForm.Visible)
                                {
                                    
                                }
                                break;
                        }
                    }
                }
                Thread.Sleep(10);

            }



        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            firstdata_b = true;
            AccelerateForm.firstdata_b = true;
        }
    }
}
