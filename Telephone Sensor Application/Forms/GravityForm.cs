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
    public partial class GravityForm : DockContent
    {
        private bool firstdata_b = true;
        public GravityForm()
        {
            InitializeComponent();
        }

        private void GravityForm_Load(object sender, EventArgs e)
        {
            //Show data as point or line.

            toolStripComboBoxLineType.Items.Add("FastLine");
            toolStripComboBoxLineType.Items.Add("FastPoint");
            toolStripComboBoxLineType.Items.Add("StepLine");
            toolStripComboBoxLineType.Text = "FastLine";

            for(int i=0;i<5;i++)
            {
                toolStripComboBoxLineWidth.Items.Add(Convert.ToString(i + 1));
            }
            toolStripComboBoxLineWidth.Text = Convert.ToString(3);
        }


        public void UpdateGravityGraph(SensorDataItem sensorData)
        {
            if (firstdata_b)
            {
                Title titleGravity = new Title("Accelerate", Docking.Top);
                titleGravity.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
                titleGravity.Font = new System.Drawing.Font("Microsoft Sans Serif", 20, System.Drawing.FontStyle.Bold);
                chartGravity.Titles.Add(titleGravity);

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
                    chartGravity.Series.Add(series);

                    //Create a new legend
                    Legend legend = new Legend(axis);
                    //Set legend properities
                    legend.Title = "Gravity";//?
                    legend.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold);
                    legend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Bold);

                    legend.LegendStyle = LegendStyle.Table;
                    legend.Alignment = System.Drawing.StringAlignment.Center;
                    legend.IsDockedInsideChartArea = false;
                    legend.Docking = Docking.Bottom;

                    legend.BorderDashStyle = ChartDashStyle.Dash;
                    legend.BorderColor = System.Drawing.Color.LightBlue;
                    legend.BorderWidth = 3;

                    chartGravity.Legends.Add(legend);
                    //Set Docking of the legend chart to the Default Chart Area
                    chartGravity.Legends[axis].DockedToChartArea = "ChartAreaGravity";

                    series.Points.AddXY(sensorData.Timestamp / 1000, data);
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
                    chartGravity.Series[axis].Points.AddXY(sensorData.Timestamp / 1000, data);
                }
            }
        }
        public void Clear()
        {
            chartGravity.Titles.Clear();
            chartGravity.Series.Clear();
            chartGravity.Legends.Clear();
            firstdata_b = true;
        }
    }
}
