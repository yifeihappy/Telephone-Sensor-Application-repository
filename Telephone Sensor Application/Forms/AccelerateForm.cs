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
using System.Windows.Forms.DataVisualization.Charting;
using Telephone_Sensor_Application.SensorDataService;
using WeifenLuo.WinFormsUI.Docking;

namespace Telephone_Sensor_Application.Forms
{
    public partial class AccelerateForm : DockContent
    {
        public static bool firstdata_b = true;
        public AccelerateForm()
        {
            InitializeComponent();
            //this.Dock = DockStyle.Fill;
        }

        private void AccelerateForm_Load(object sender, EventArgs e)
        {
            //Show data as point or line.
            LineTypeTSCB.Items.Add("FastLine");
            LineTypeTSCB.Items.Add("FastPoint");
            LineTypeTSCB.Items.Add("StepLine");
            LineTypeTSCB.Text = "FastLine";

            for(int i = 0; i < 5; i++)
            {
                LineWidthTSCB.Items.Add(i + 1);
            }
            LineWidthTSCB.Text = Convert.ToString(3);

            //SensorDataItem sd = new SensorDataItem();
            //for (int i = 0; i < 40; i++)
            //{
            //    sd.X = 10+i;
            //    sd.Y = 20 + i;
            //    sd.Z = 20 - i;
            //    sd.Timestamp = (ulong)(1000 * i);
            //    this.UpdateAccelerateGraph(sd);
            //}

        }

        public void UpdateAccelerateGraph(SensorDataItem sensorData)
        {
            if(firstdata_b)
            {
                Title titleAccelerate = new Title("Accelerate", Docking.Top);
                titleAccelerate.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
                titleAccelerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20, System.Drawing.FontStyle.Bold);
                charAccelerate.Titles.Add(titleAccelerate); 

                for(int i=0;i<3;i++)
                {
                    String axis = null;
                    double data = 0;
                    switch (i)
                    {
                        case 0:axis = "X";
                            data = sensorData.X;
                            break;
                        case 1:axis = "Y";
                            data = sensorData.Y;
                            break;
                        case 2:axis = "Z";
                            data = sensorData.Z;
                            break;

                    }
                    //Create a new curve
                    Series series = new Series(axis);
                    //Set chart type
                    series.ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), LineTypeTSCB.Text.Trim());
                    //Set curve width
                    series.BorderWidth = Convert.ToInt32(LineWidthTSCB.Text.Trim());
                    charAccelerate.Series.Add(series);

                    //Create a new legend
                    Legend legend = new Legend(axis);
                    //Set legend properities
                    legend.Title = "Acce";//?
                    legend.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold);
                    legend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Bold);

                    legend.LegendStyle = LegendStyle.Table;
                    legend.Alignment = System.Drawing.StringAlignment.Center;
                    legend.IsDockedInsideChartArea = false;
                    legend.Docking = Docking.Bottom;

                    legend.BorderDashStyle = ChartDashStyle.Dash;
                    legend.BorderColor = System.Drawing.Color.LightBlue;
                    legend.BorderWidth = 3;

                    charAccelerate.Legends.Add(legend);
                    //Set Docking of the legend chart to the Default Chart Area
                    charAccelerate.Legends[axis].DockedToChartArea = "ChartAreaAccelerate";

                    series.Points.AddXY(sensorData.Timestamp / 1000, data);
                }
                firstdata_b = false;//init is finished.
            }
            else
            {
                for(int i=0;i<3;i++)
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
                    charAccelerate.Series[axis].Points.AddXY(sensorData.Timestamp / 1000, data);
                }
            }
        }

    }
}
