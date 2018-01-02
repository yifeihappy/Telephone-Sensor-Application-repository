using System;
using System.Windows.Forms.DataVisualization.Charting;
using Telephone_Sensor_Application.SensorDataService;
using WeifenLuo.WinFormsUI.Docking;

namespace Telephone_Sensor_Application.Forms
{
    public partial class FormXD : DockContent
    {
        public bool firstdata_b = true;
        private string sensorName = null;
        private string formName = null;
        public FormXD(string formName, string sensorName)
        {
            InitializeComponent();
            this.sensorName = sensorName;
            this.formName = formName;
        }

        private void Form3D_Load(object sender, EventArgs e)
        {
            //Show data as point or line.
            toolStripComboBoxLineType.Items.Add("FastLine");
            toolStripComboBoxLineType.Items.Add("FastPoint");
            toolStripComboBoxLineType.Items.Add("StepLine");
            toolStripComboBoxLineType.Text = "FastLine";

            for (int i = 0; i < 5; i++)
            {
                toolStripComboBoxLineWidth.Items.Add(i + 1);
            }
            toolStripComboBoxLineWidth.Text = Convert.ToString(3);
            this.TabText = formName;
        }


        public void UpdateGraph(SensorDataItemXD sensorDataXD)
        {
            if (firstdata_b)
            {
                Title title = new Title(sensorName, Docking.Top);
                title.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
                title.Font = new System.Drawing.Font("Microsoft Sans Serif", 20, System.Drawing.FontStyle.Bold);
                chart1.Titles.Add(title);

                for (int i = 0; i < sensorDataXD.Dimension; i++)
                {
                    String axis = null;
                    double data = 0;
                    switch (i)
                    {
                        case 0:
                            axis = "X";
                            break;
                        case 1:
                            axis = "Y";
                            break;
                        case 2:
                            axis = "Z";
                            break;
                        case 3:
                            axis = "A";
                            break;
                        case 4:
                            axis = "B";
                            break;
                        case 5:
                            axis = "C";
                            break;
                        case 6:
                            axis = "D";
                            break;
                        case 7:
                            axis = "E";
                            break;
                        case 8:
                            axis = "F";
                            break;
                        case 9:
                            axis = "G";
                            break;
                        case 10:
                            axis = "H";
                            break;
                        case 11:
                            axis = "I";
                            break;
                        case 12:
                            axis = "J";
                            break;
                        case 13:
                            axis = "K";
                            break;
                        case 14:
                            axis = "L";
                            break;
                        case 15:
                            axis = "M";
                            break;
                    }
                    data = sensorDataXD.SensorsArr[i];
                    //Create a new curve
                    Series series = new Series(axis);
                    //Set chart type
                    series.ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), toolStripComboBoxLineType.Text.Trim());
                    //Set curve width
                    series.BorderWidth = Convert.ToInt32(toolStripComboBoxLineWidth.Text.Trim());
                    chart1.Series.Add(series);

                    //Create a new legend
                    Legend legend = new Legend(axis);
                    //Set legend properities
                    legend.Title = sensorName;
                    legend.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold);
                    legend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Bold);

                    legend.LegendStyle = LegendStyle.Table;
                    legend.Alignment = System.Drawing.StringAlignment.Center;
                    legend.IsDockedInsideChartArea = false;
                    legend.Docking = Docking.Bottom;

                    legend.BorderDashStyle = ChartDashStyle.Dash;
                    legend.BorderColor = System.Drawing.Color.LightBlue;
                    legend.BorderWidth = 3;

                    chart1.Legends.Add(legend);
                    //Set Docking of the legend chart to the Default Chart Area
                    chart1.Legends[axis].DockedToChartArea = "ChartArea1";

                    series.Points.AddXY(sensorDataXD.Timestamp, data);
                }
                firstdata_b = false;//init is finished.
            }
            else
            {
                for (int i = 0; i < sensorDataXD.Dimension; i++)
                {
                    String axis = null;
                    double data = 0;
                    switch (i)
                    {
                        case 0:
                            axis = "X";
                            break;
                        case 1:
                            axis = "Y";
                            break;
                        case 2:
                            axis = "Z";
                            break;
                        case 3:
                            axis = "A";
                            break;
                        case 4:
                            axis = "B";
                            break;
                        case 5:
                            axis = "C";
                            break;
                        case 6:
                            axis = "D";
                            break;
                        case 7:
                            axis = "E";
                            break;
                        case 8:
                            axis = "F";
                            break;
                        case 9:
                            axis = "G";
                            break;
                        case 10:
                            axis = "H";
                            break;
                        case 11:
                            axis = "I";
                            break;
                        case 12:
                            axis = "J";
                            break;
                        case 13:
                            axis = "K";
                            break;
                        case 14:
                            axis = "L";
                            break;
                        case 15:
                            axis = "M";
                            break;
                    }
                    data = sensorDataXD.SensorsArr[i];
                    chart1.Series[axis].Points.AddXY(sensorDataXD.Timestamp, data);
                }
            }
        }

        public void Clear()
        {
            chart1.Titles.Clear();
            chart1.Series.Clear();
            chart1.Legends.Clear();
            firstdata_b = true;
        }
    }
}
