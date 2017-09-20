using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephone_Sensor_Application.Forms
{
    public class SensorData
    {
        private double x;
        private double y;
        private double z;
        private ulong timestamp;

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public double Z { get => z; set => z = value; }
        public ulong Timestamp { get => timestamp; set => timestamp = value; }
    }
}
