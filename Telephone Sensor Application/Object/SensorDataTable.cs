using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephone_Sensor_Application.SensorDataService;

namespace Telephone_Sensor_Application
{
    public class SensorDataTable
    {
        DataTable _sensorsTable;
        public SensorDataTable()
        {
            SensorsTable = new DataTable("Sensors");
            SensorsTable.Columns.Add("Type");
            SensorsTable.Columns.Add("Timestamp/ms");
            SensorsTable.Columns.Add("X");
            SensorsTable.Columns.Add("Y");
            SensorsTable.Columns.Add("Z");

        }

        public void AddSensorDataInfo(SensorDataItem sditem)
        {
            DataRow row = SensorsTable.NewRow();
            row["Type"] = sditem.Type;
            row["Timestamp/ms"] = sditem.Timestamp;
            row["X"] = sditem.X;
            row["Y"] = sditem.Y;
            row["Z"] = sditem.Z;
            SensorsTable.Rows.Add(row);
        }

        public void Clear()
        {
            SensorsTable.Clear();
        }

        public DataTable SensorsTable { get => _sensorsTable; set => _sensorsTable = value; }
    }
}
