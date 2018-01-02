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
            SensorsTable.Columns.Add("Dimension");
            SensorsTable.Columns.Add("X");
            SensorsTable.Columns.Add("Y");
            SensorsTable.Columns.Add("Z");
            SensorsTable.Columns.Add("A");
            SensorsTable.Columns.Add("B");
            SensorsTable.Columns.Add("C");
            SensorsTable.Columns.Add("D");
            SensorsTable.Columns.Add("E");
            SensorsTable.Columns.Add("F");
            SensorsTable.Columns.Add("G");
            SensorsTable.Columns.Add("H");
            SensorsTable.Columns.Add("I");
            SensorsTable.Columns.Add("J");
            SensorsTable.Columns.Add("K");
            SensorsTable.Columns.Add("L");
            SensorsTable.Columns.Add("M");
        }

        public void AddSensorDataInfo(SensorDataItemXD sditemXD)
        {
            DataRow row = SensorsTable.NewRow();
            row["Type"] = sditemXD.Type;
            row["Timestamp/ms"] = sditemXD.Timestamp;
            row["Dimension"] = sditemXD.Dimension;

            row["X"] = sditemXD.SensorsArr[0];
            row["Y"] = sditemXD.SensorsArr[1];
            row["Z"] = sditemXD.SensorsArr[2];
            row["A"] = sditemXD.SensorsArr[3];
            row["B"] = sditemXD.SensorsArr[4];
            row["C"] = sditemXD.SensorsArr[5];
            row["D"] = sditemXD.SensorsArr[6];
            row["E"] = sditemXD.SensorsArr[7];
            row["F"] = sditemXD.SensorsArr[8];
            row["G"] = sditemXD.SensorsArr[9];
            row["H"] = sditemXD.SensorsArr[10];
            row["I"] = sditemXD.SensorsArr[11];
            row["J"] = sditemXD.SensorsArr[12];
            row["K"] = sditemXD.SensorsArr[13];
            row["L"] = sditemXD.SensorsArr[14];
            row["M"] = sditemXD.SensorsArr[15];
            SensorsTable.Rows.
                
                
                Add(row);
        }

        public void Clear()
        {
            SensorsTable.Clear();
        }

        public DataTable SensorsTable { get => _sensorsTable; set => _sensorsTable = value; }
    }
}
