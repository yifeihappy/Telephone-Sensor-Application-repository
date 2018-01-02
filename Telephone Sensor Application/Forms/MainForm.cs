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
        public FormXD accelerometerForm = null;//1
        public FormXD magneticForm = null;//2
        public FormXD OrientationForm = null;//3
        public FormXD gyroscopeForm = null;//4
        public FormXD BH1745_BH1745_ALS_DEVICEForm = null;//5
        public FormXD pressureForm = null;//6
        public FormXD PROXForm = null;//8
        public FormXD gravityForm = null;//9
        public FormXD LinearAccelerationForm = null;//10
        public FormXD RotationVectorForm = null;//11
        public FormXD magnetometerUncalibratedForm = null;//14
        public FormXD GameRotationVectorForm = null;//15
        public FormXD gyroscopeUncalibratedForm = null;//16
        public FormXD SignificantMotionDetectorForm = null;//17
        public FormXD StepDetectorForm = null;//18
        public FormXD StepCounterForm = null;//19
        public FormXD GeoMagneticRotationVectorForm = null;//20
        public FormXD TiltDetectorForm = null;//22
        public FormXD AndroidStationaryDetectorForm = null;//29
        public FormXD AndroidMotionDetectorForm = null;//30
        public FormXD BasicGesturesForm = null;//33171000
        public FormXD FacingForm = null;//33171002
        public FormXD AMDForm = null;//33171006
        public FormXD RMDForm = null;//33171007
        public FormXD PedometerForm = null;//33171009
        public FormXD MotionAccelForm = null;//33171011
        public FormXD CoarseMotionClassifierForm = null;//33171012
        public FormXD IODForm = null;//33171021
        public FormXD DPCForm = null;//33171022
        public FormXD MultiShakeForm = null;//33171023
        public FormXD PersistentMotionDetectorForm = null;//33171024
        public FormXD Oem5TaptapGestureForm = null;//33171027

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
            accelerometerForm = new FormXD("accelerometerForm", "1:accelerometer");//1
            magneticForm = new FormXD("magneticForm", "2:magnetic");//2
            gyroscopeForm = new FormXD("gyroscopeForm", "4:gyroscope");//4
            OrientationForm = new FormXD("OrientationForm", "3:Orientation");//3
            BH1745_BH1745_ALS_DEVICEForm = new FormXD("BH1745_BH1745_ALS_DEVICEForm", "5:BH1745 BH1745 ALS DEVICE");//5
            pressureForm = new FormXD("pressureForm", "6:BMP285 Pressure");//6
            PROXForm = new FormXD("PROXForm", "8:TMD2620 PROX");//8
            gravityForm = new FormXD("gravityForm", "9:gravity");//9
            LinearAccelerationForm = new FormXD("LinearAcceleration", "10:Linear Acceleration");//10
            RotationVectorForm = new FormXD("RotationVectorForm", "11:Rotation Vector");//11
            magnetometerUncalibratedForm = new FormXD("magnetometerUncalibratedForm", "14:AK09916C Magnetometer Uncalibrated");//14
            GameRotationVectorForm = new FormXD("SignificantMotionDetectorForm", "15:Game Rotation Vector");//15
            gyroscopeUncalibratedForm = new FormXD("gyroscopeUncalibratedForm", "16:ICM20690 Gyroscope Uncalibrated");//16
            SignificantMotionDetectorForm = new FormXD("", "17:Significant Motion Detector");//17
            StepDetectorForm = new FormXD("StepDetectorForm", "18:Step Detector");//18
            StepCounterForm = new FormXD("StepCounterForm", "19:Step Counter");//19
            GeoMagneticRotationVectorForm = new FormXD("GeoMagneticRotationVectorForm", "20:GeoMagnetic Rotation Vector");//20
            TiltDetectorForm = new FormXD("TiltDetectorForm", "22:Tilt Detector");//22
            AndroidStationaryDetectorForm = new FormXD("AndroidStationaryDetectorForm", "29:Android Stationary Detector");//29
            AndroidMotionDetectorForm = new FormXD("AndroidMotionDetectorForm", "30:Android Motion Detector");//30
            BasicGesturesForm = new FormXD("BasicGesturesForm", "33171000:Basic Gestures");//33171000
            FacingForm = new FormXD("FacingForm", "33171002:Facing");//33171002
            AMDForm = new FormXD("AMDForm", "33171006:AMD");//33171006
            RMDForm = new FormXD("AMDForm", "33171007:RMD");//33171007
            PedometerForm = new FormXD("PedometerForm", "33171009:Pedometer");//33171009
            MotionAccelForm = new FormXD("MotionAccelForm", "33171011:Motion Accel");//33171011
            CoarseMotionClassifierForm = new FormXD("CoarseMotionClassifierForm", "33171012:Coarse Motion Classifier");//33171012
            IODForm = new FormXD("IODForm", "33171021:IOD");//33171021
            DPCForm = new FormXD("DPCForm", "33171022:DPC");//33171022
            MultiShakeForm = new FormXD("MultiShakeForm", "33171023:MultiShake");//33171023
            PersistentMotionDetectorForm = new FormXD("PersistentMotionDetectorForm", "33171024:Persistent Motion Detector");//33171024
            Oem5TaptapGestureForm = new FormXD("Oem5TaptapGestureForm", "33171027:Oem5 Taptap Gesture");//33171027

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

            while (true)
            {
                List<SensorDataItemXD> sensorDataList = null;
                try
                {
                    SensorDataService1Client sensorDataService1Client = new SensorDataService1Client();
                    SensorDataItemXD[] sensorDataArr = sensorDataService1Client.TryDeque();
                    sensorDataService1Client.Close();
                    sensorDataList = new List<SensorDataItemXD>(sensorDataArr);
                }
                catch (EndpointNotFoundException e1)
                {
                    MessageBox.Show("Service is not running!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Debug.WriteLine(e1.ToString());
                }

                //Debug.WriteLine("" + sensorDataArr.Length);

                if (sensorDataList != null && sensorDataList.Count > 0)
                {
                    foreach (SensorDataItemXD sditemXD in sensorDataList)
                    {
                        //记录第一次获得数据的时间
                        if (firstdata_b)
                        {
                            firstdataTime = sditemXD.Timestamp;
                            firstdata_b = false;
                        }
                        sditemXD.Timestamp -= firstdataTime;
                        this.BeginInvoke(method: new Action(() =>
                        {
                            //目前支持的传感器类型，增加的话需要在这里更改
                            switch ((SensorType)sditemXD.Type)
                            {
                                case SensorType.TYPE_ACCELEROMETER:
                                    if (accelerometerForm.Visible)
                                    {
                                        accelerometerForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_MAGNETIC_FIELD:
                                    if (magneticForm.Visible)
                                    {
                                        magneticForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_ORIENTATION:
                                    if (OrientationForm.Visible)
                                    {
                                        OrientationForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_GYROSCOPE:
                                    if (gyroscopeForm.Visible)
                                    {
                                        gyroscopeForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_LIGHT:
                                    if (BH1745_BH1745_ALS_DEVICEForm.Visible)
                                    {
                                        BH1745_BH1745_ALS_DEVICEForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_PRESSURE:
                                    if (pressureForm.Visible)
                                    {
                                        pressureForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_PROXIMITY:
                                    if (PROXForm.Visible)
                                    {
                                        PROXForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_GRAVITY:
                                    if (gravityForm.Visible)
                                    {
                                        gravityForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_LINEAR_ACCELERATION:
                                    if (LinearAccelerationForm.Visible)
                                    {
                                        LinearAccelerationForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_ROTATION_VECTOR:
                                    if (RotationVectorForm.Visible)
                                    {
                                        RotationVectorForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_MAGNETIC_FIELD_UNCALIBRATED:
                                    if (magnetometerUncalibratedForm.Visible)
                                    {
                                        magnetometerUncalibratedForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_GAME_ROTATION_VECTOR:
                                    if (GameRotationVectorForm.Visible)
                                    {
                                        GameRotationVectorForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_GYROSCOPE_UNCALIBRATED:
                                    if (gyroscopeUncalibratedForm.Visible)
                                    {
                                        gyroscopeUncalibratedForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_SIGNIFICANT_MOTION:
                                    if (SignificantMotionDetectorForm.Visible)
                                    {
                                        SignificantMotionDetectorForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_STEP_DETECTOR:
                                    if (StepDetectorForm.Visible)
                                    {
                                        StepDetectorForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_STEP_COUNTER:
                                    if (StepCounterForm.Visible)
                                    {
                                        StepCounterForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_GEOMAGNETIC_ROTATION_VECTOR:
                                    if (GeoMagneticRotationVectorForm.Visible)
                                    {
                                        GeoMagneticRotationVectorForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_Tilt_Detector:
                                    if (TiltDetectorForm.Visible)
                                    {
                                        TiltDetectorForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_STATIONARY_DETECT:
                                    if (AndroidStationaryDetectorForm.Visible)
                                    {
                                        AndroidStationaryDetectorForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_MOTION_DETECT:
                                    if (AndroidMotionDetectorForm.Visible)
                                    {
                                        AndroidMotionDetectorForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_BASIC_GESTURES:
                                    if (BasicGesturesForm.Visible)
                                    {
                                        BasicGesturesForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_FACING:
                                    if (FacingForm.Visible)
                                    {
                                        FacingForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_AMD:
                                    if (AMDForm.Visible)
                                    {
                                        AMDForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_RMD:
                                    if (RMDForm.Visible)
                                    {
                                        RMDForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_PEDOMETER:
                                    if (PedometerForm.Visible)
                                    {
                                        PedometerForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_MOTION_ACCEL:
                                    if (MotionAccelForm.Visible)
                                    {
                                        MotionAccelForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_COARSE_MOTION_CLASSIFIER:
                                    if (CoarseMotionClassifierForm.Visible)
                                    {
                                        CoarseMotionClassifierForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_IOD:
                                    if (IODForm.Visible)
                                    {
                                        IODForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_DPC:
                                    if (DPCForm.Visible)
                                    {
                                        DPCForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_MUTILSHAKE:
                                    if (MultiShakeForm.Visible)
                                    {
                                        MultiShakeForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_PERSISTENT_MOTION_DETECTOR:
                                    if (PersistentMotionDetectorForm.Visible)
                                    {
                                        PersistentMotionDetectorForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                                case SensorType.TYPE_OEM5_TAPTAP_GESTURE:
                                    if (Oem5TaptapGestureForm.Visible)
                                    {
                                        Oem5TaptapGestureForm.UpdateGraph(sditemXD);
                                    }
                                    break;
                            }

                        }
                        ));
                        sensorDataTable.AddSensorDataInfo(sditemXD);
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
                this.firstdata_b = true;
                windowsToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                stopToolStripMenuItem.Enabled = false;
                startToolStripMenuItem.Enabled = true;
                settingForm.btnSensorsType.Enabled = true;
            }
            catch (Exception erro)
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

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveFileHelper.SaveFile(sensorDataTable.SensorsTable, fileDialog.FileName);
            }
        }

        public void Clear()
        {
            sensorDataTable.Clear();
            if (accelerometerForm.Visible)
            {
                accelerometerForm.Clear();
            }
            if (magneticForm.Visible)
            {
                magneticForm.Clear();
            }

            if (gravityForm.Visible)
            {
                gravityForm.Clear();
            }

            if (gyroscopeForm.Visible)
            {
                gyroscopeForm.Clear();
            }

            if (OrientationForm.Visible)
            {
                OrientationForm.Clear();
            }

            if (gyroscopeForm.Visible)
            {
                gyroscopeForm.Clear();
            }

            if (BH1745_BH1745_ALS_DEVICEForm.Visible)
            {
                BH1745_BH1745_ALS_DEVICEForm.Clear();
            }

            if (pressureForm.Visible)
            {
                pressureForm.Clear();
            }

            if (PROXForm.Visible)
            {
                PROXForm.Clear();
            }

            if (gravityForm.Visible)
            {
                gravityForm.Clear();
            }

            if (LinearAccelerationForm.Visible)
            {
                LinearAccelerationForm.Clear();
            }

            if (RotationVectorForm.Visible)
            {
                RotationVectorForm.Clear();
            }

            if (magnetometerUncalibratedForm.Visible)
            {
                magnetometerUncalibratedForm.Clear();
            }

            if (GameRotationVectorForm.Visible)
            {
                GameRotationVectorForm.Clear();
            }

            if (gyroscopeUncalibratedForm.Visible)
            {
                gyroscopeUncalibratedForm.Clear();
            }

            if (SignificantMotionDetectorForm.Visible)
            {
                SignificantMotionDetectorForm.Clear();
            }

            if (StepDetectorForm.Visible)
            {
                StepDetectorForm.Clear();
            }

            if (StepCounterForm.Visible)
            {
                StepCounterForm.Clear();
            }

            if (GeoMagneticRotationVectorForm.Visible)
            {
                GeoMagneticRotationVectorForm.Clear();
            }

            if (TiltDetectorForm.Visible)
            {
                TiltDetectorForm.Clear();
            }

            if (AndroidStationaryDetectorForm.Visible)
            {
                AndroidStationaryDetectorForm.Clear();
            }

            if (AndroidMotionDetectorForm.Visible)
            {
                AndroidMotionDetectorForm.Clear();
            }

            if (BasicGesturesForm.Visible)
            {
                BasicGesturesForm.Clear();
            }

            if (FacingForm.Visible)
            {
                FacingForm.Clear();
            }

            if (AMDForm.Visible)
            {
                AMDForm.Clear();
            }

            if (RMDForm.Visible)
            {
                RMDForm.Clear();
            }

            if (PedometerForm.Visible)
            {
                PedometerForm.Clear();
            }

            if (MotionAccelForm.Visible)
            {
                MotionAccelForm.Clear();
            }

            if (CoarseMotionClassifierForm.Visible)
            {
                CoarseMotionClassifierForm.Clear();
            }

            if (IODForm.Visible)
            {
                IODForm.Clear();
            }

            if (DPCForm.Visible)
            {
                DPCForm.Clear();
            }

            if (MultiShakeForm.Visible)
            {
                MultiShakeForm.Clear();
            }

            if (PersistentMotionDetectorForm.Visible)
            {
                PersistentMotionDetectorForm.Clear();
            }

            if (Oem5TaptapGestureForm.Visible)
            {
                Oem5TaptapGestureForm.Clear();
            }

        }

        private void dockPanel1_ActiveContentChanged(object sender, EventArgs e)
        {

        }

    }
}
