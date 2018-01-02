using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telephone_Sensor_Application.SensorDataService;
using Telephone_Sensor_Application.SocketService1;
using Telephone_Sensor_Application.Utility;
using WeifenLuo.WinFormsUI.Docking;

namespace Telephone_Sensor_Application.Forms
{
    public partial class SettingForm : DockContent
    {

        private Dictionary<string, SensorType> sensorsTypeDict = null;
        private MainForm mainForm = null;
        //本程序目前支持的传感器类型
        private HashSet<SensorType> selectedSensorsTypeSet = null; 
        private HashSet<SensorType> androidSensorsTypeSet = new HashSet<SensorType>();
        public SettingForm(MainForm mainForm)
        {
            InitializeComponent();
            sensorsTypeDict = new Dictionary<string, SensorType>();
            this.mainForm = mainForm;
        }

        private void btnSensorsType_Click(object sender, EventArgs e)
        {

            checkedListBoxSensorsType.Items.Clear();
            String sensorsTypeStr = null;
            try
            {
                SensorDataService1Client sensorDataService1Client = new SensorDataService1Client();
                sensorsTypeStr = sensorDataService1Client.getSensorsType();
                sensorDataService1Client.Close();

                if (sensorsTypeStr == null || sensorsTypeStr.Length == 0)
                {
                    MessageBox.Show("无可用传感器，或者Android设备未连上Service!", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {

                    //保存Android传感器类型到文件
                    SaveFileHelper.SaveFile(sensorsTypeStr, MainForm.baseFilePath + "\\SensorsType.txt");

                    string[] sensorsTypeArr = sensorsTypeStr.Split(',');
                    for (int i = 1; i < sensorsTypeArr.Length; i++)
                    {
                        string[] sensorsTypeItemArr = sensorsTypeArr[i].Split(':');
                        if(androidSensorsTypeSet.Contains((SensorType)(int.Parse(sensorsTypeItemArr[0]))))
                        {
                            continue;
                        }
                        else
                        {
                            sensorsTypeDict.Add(sensorsTypeItemArr[1], (SensorType)(int.Parse(sensorsTypeItemArr[0])));
                            androidSensorsTypeSet.Add((SensorType)(int.Parse(sensorsTypeItemArr[0])));
                        }
                    }
                    foreach(string sensorName in sensorsTypeDict.Keys)
                    {
                        checkedListBoxSensorsType.Items.Add(sensorName);
                    }

                    buttonOK.Enabled = true;
                }
                
            }
            catch(Exception e1)
            {
                MessageBox.Show("查询失败，可能服务未启动", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Debug.WriteLine("Er"+e1.ToString());
            }
            

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            selectedSensorsTypeSet = new HashSet<SensorType>();
            mainForm.windowsToolStripMenuItem.DropDownItems.Clear();
            for(int i=0; i<checkedListBoxSensorsType.Items.Count; i++)
            {
                if(checkedListBoxSensorsType.GetItemChecked(i))
                {
                    string sensorName = checkedListBoxSensorsType.Items[i].ToString();
                    ToolStripItem ts = new ToolStripMenuItem(sensorName);
                    //目前支持的传感器类型，增加的话需要在这里更改
                    switch(sensorsTypeDict[sensorName])
                    {
                        case SensorType.TYPE_ACCELEROMETER:
                            ts.Click += new EventHandler(accelerateToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_MAGNETIC_FIELD:
                            ts.Click += new EventHandler(magneticToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_ORIENTATION:
                            ts.Click += new EventHandler(orientationToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_GYROSCOPE:
                            ts.Click += new EventHandler(gyroscopeToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_LIGHT:
                            ts.Click += new EventHandler(bH1745BH1745ALSDEVICEToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_PRESSURE:
                            ts.Click += new EventHandler(pressureToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_PROXIMITY:
                            ts.Click += new EventHandler(PROXToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_GRAVITY:
                            ts.Click += new EventHandler(gravityToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_LINEAR_ACCELERATION:
                            ts.Click += new EventHandler(linearAccelerationToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_ROTATION_VECTOR:
                            ts.Click += new EventHandler(rotationVectorToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_MAGNETIC_FIELD_UNCALIBRATED:
                            ts.Click += new EventHandler(magnetometerUncalibratedToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_GAME_ROTATION_VECTOR:
                            ts.Click += new EventHandler(gameRotationVectorToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_GYROSCOPE_UNCALIBRATED:
                            ts.Click += new EventHandler(gyroscopeUncalibratedToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_SIGNIFICANT_MOTION:
                            ts.Click += new EventHandler(significantMotionDetectorToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_STEP_DETECTOR:
                            ts.Click += new EventHandler(stepDetectorToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_STEP_COUNTER:
                            ts.Click += new EventHandler(stepCounterToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_GEOMAGNETIC_ROTATION_VECTOR:
                            ts.Click += new EventHandler(geoMagneticRotationVectorToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_Tilt_Detector:
                            ts.Click += new EventHandler(tiltDetectorToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_STATIONARY_DETECT:
                            ts.Click += new EventHandler(androidStationaryDetectorToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_MOTION_DETECT:
                            ts.Click += new EventHandler(androidMotionDetectorToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_BASIC_GESTURES:
                            ts.Click += new EventHandler(basicGesturesToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_FACING:
                            ts.Click += new EventHandler(facingToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_AMD:
                            ts.Click += new EventHandler(AMDToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_RMD:
                            ts.Click += new EventHandler(RMDToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_PEDOMETER:
                            ts.Click += new EventHandler(pedometerToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_MOTION_ACCEL:
                            ts.Click += new EventHandler(motionAcceToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_COARSE_MOTION_CLASSIFIER:
                            ts.Click += new EventHandler(coarseMotionClassifierToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_IOD:
                            ts.Click += new EventHandler(IODToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_DPC:
                            ts.Click += new EventHandler(DPCToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_MUTILSHAKE:
                            ts.Click += new EventHandler(multiShakeToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_PERSISTENT_MOTION_DETECTOR:
                            ts.Click += new EventHandler(persistentMotionDetectorToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_OEM5_TAPTAP_GESTURE:
                            ts.Click += new EventHandler(oem5TaptapGestureToolStripMenuItem_Click);
                            break;
                        default:
                            ts.Click += new EventHandler(iHaveNotAchieveTheFormOfThisTSMenuItem);
                            break;
                    }
                    mainForm.windowsToolStripMenuItem.DropDownItems.Add(ts);
                    selectedSensorsTypeSet.Add(sensorsTypeDict[sensorName]);
                }
            }

            if(selectedSensorsTypeSet.Count == 0)
            {
                MessageBox.Show("请选择传感器类型!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string msg = "SAMPLINGPERIODUS,";
            foreach (RadioButton rb in groupBoxRadioButton.Controls)
            {
                if (rb.Checked)
                {
                    //Debug.WriteLine(rb.Text);
                    int SamplingPeriodUS = 3;
                    if (rb.Text.Equals("UI"))
                        SamplingPeriodUS = 2;
                    else if (rb.Text.Equals("GAME"))
                        SamplingPeriodUS = 1;
                    else if (rb.Text.Equals("FASTEST"))
                        SamplingPeriodUS = 0;
                    msg += "" + SamplingPeriodUS + '\n';
                    break;
                }
            }

            msg += "SENSORSTYPE";
            foreach(SensorType st in selectedSensorsTypeSet)
            {
                msg += "," + (int)st;
            }
            msg += '\n';//因为android service uses readline() function to read socket message.

            SocketService1Client socketService = new SocketService1Client();
            if (!socketService.sendData(msg))
            {
                MessageBox.Show("设置失败，网络异常!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                socketService.Close();
                return;
            }
            socketService.Close();
            Debug.WriteLine(msg);
            buttonOK.Enabled = false;
            btnSensorsType.Enabled = false;
        }

        private void accelerateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.accelerometerForm.Show(mainForm.dockPanel1);
        }
        private void magneticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.magneticForm.Show(mainForm.dockPanel1);
        }



        private void orientationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.OrientationForm.Show(mainForm.dockPanel1);
        }
        private void gyroscopeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.gyroscopeForm.Show(mainForm.dockPanel1);
        }


        private void bH1745BH1745ALSDEVICEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.BH1745_BH1745_ALS_DEVICEForm.Show(mainForm.dockPanel1);
        }

        private void pressureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.pressureForm.Show(mainForm.dockPanel1);
        }

        private void PROXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.PROXForm.Show(mainForm.dockPanel1);
        }

        private void gravityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.gravityForm.Show(mainForm.dockPanel1);
        }



        private void linearAccelerationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.LinearAccelerationForm.Show(mainForm.dockPanel1);
        }

        private void rotationVectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.RotationVectorForm.Show(mainForm.dockPanel1);
        }

        private void magnetometerUncalibratedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.magnetometerUncalibratedForm.Show(mainForm.dockPanel1);
        }

        private void gameRotationVectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.GameRotationVectorForm.Show(mainForm.dockPanel1);
        }

        private void gyroscopeUncalibratedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.gyroscopeUncalibratedForm.Show(mainForm.dockPanel1);
        }

        private void significantMotionDetectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.SignificantMotionDetectorForm.Show(mainForm.dockPanel1);
        }

        private void stepDetectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.StepDetectorForm.Show(mainForm.dockPanel1);
        }

        private void stepCounterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.StepCounterForm.Show(mainForm.dockPanel1);
        }

        private void geoMagneticRotationVectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.GeoMagneticRotationVectorForm.Show(mainForm.dockPanel1);
        }

        private void tiltDetectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.TiltDetectorForm.Show(mainForm.dockPanel1);
        }

        private void androidStationaryDetectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.AndroidStationaryDetectorForm.Show(mainForm.dockPanel1);
        }

        private void androidMotionDetectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.AndroidMotionDetectorForm.Show(mainForm.dockPanel1);
        }

        private void basicGesturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.BasicGesturesForm.Show(mainForm.dockPanel1);
        }

        private void facingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.FacingForm.Show(mainForm.dockPanel1);
        }

        private void AMDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.AMDForm.Show(mainForm.dockPanel1);
        }

        private void RMDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.RMDForm.Show(mainForm.dockPanel1);
        }

        private void pedometerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.PedometerForm.Show(mainForm.dockPanel1);
        }

        private void motionAcceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.MotionAccelForm.Show(mainForm.dockPanel1);
        }

        private void coarseMotionClassifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.CoarseMotionClassifierForm.Show(mainForm.dockPanel1);
        }

        private void IODToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.IODForm.Show(mainForm.dockPanel1);
        }

        private void DPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.DPCForm.Show(mainForm.dockPanel1);
        }

        private void multiShakeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.MultiShakeForm.Show(mainForm.dockPanel1);
        }

        private void persistentMotionDetectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.PersistentMotionDetectorForm.Show(mainForm.dockPanel1);
        }

        private void oem5TaptapGestureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.Oem5TaptapGestureForm.Show(mainForm.dockPanel1);
        }



        private void iHaveNotAchieveTheFormOfThisTSMenuItem(object sender, EventArgs e)
        {
            MessageBox.Show("Coder has not achieved the form for this sensor!", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }




        private void SettingForm_Load(object sender, EventArgs e)
        {

        }
    }
}
