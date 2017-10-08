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
                        case SensorType.TYPE_GRAVITY:
                            ts.Click += new EventHandler(gravityToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_MAGNETIC_FIELD:
                            ts.Click += new EventHandler(magneticToolStripMenuItem_Click);
                            break;
                        case SensorType.TYPE_GYROSCOPE:
                            ts.Click += new EventHandler(gyroscopeToolStripMenuItem_Click);
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

        private void gravityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.gravityForm.Show(mainForm.dockPanel1);
        }

        private void gyroscopeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.gyroscopeForm.Show(mainForm.dockPanel1);
        }

        private void magneticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.magneticForm.Show(mainForm.dockPanel1);
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
