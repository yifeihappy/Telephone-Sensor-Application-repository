using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Telephone_Sensor_Application.SensorDataService;
using WeifenLuo.WinFormsUI.Docking;

namespace Telephone_Sensor_Application.Forms
{
    public partial class MagneticForm : DockContent
    {
        public static bool firstdata_b = true;
        public MagneticForm()
        {
            InitializeComponent();
        }

        private void MagneticForm_Load(object sender, EventArgs e)
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


        }

        public void UpdateGraph(SensorDataItem sensorData)
        {
            if (firstdata_b)
            {
                Title title = new Title("MagneticForm", Docking.Top);
                title.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
                title.Font = new System.Drawing.Font("Microsoft Sans Serif", 20, System.Drawing.FontStyle.Bold);
                chart1.Titles.Add(title);

                for (int i = 0; i < 3; i++)
                {
                    String axis = null;
                    double data = 0;
                    switch (i)
                    {
                        case 0:
                            axis = "X";
                            data = sensorData.X;
                            break;
                        case 1:
                            axis = "Y";
                            data = sensorData.Y;
                            break;
                        case 2:
                            axis = "Z";
                            data = sensorData.Z;
                            break;

                    }
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
                    legend.Title = "Magnetic";//?
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

                    series.Points.AddXY(sensorData.Timestamp, data);
                }
                firstdata_b = false;//init is finished.
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    String axis = null;
                    double data = 0;
                    switch (i)
                    {
                        case 0:
                            axis = "X";
                            data = sensorData.X;
                            break;
                        case 1:
                            axis = "Y";
                            data = sensorData.Y;
                            break;
                        case 2:
                            axis = "Z";
                            data = sensorData.Z;
                            break;

                    }
                    chart1.Series[axis].Points.AddXY(sensorData.Timestamp, data);
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
