using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephone_Sensor_Application
{
    enum SensorType
    {
        //public static final String STRING_TYPE_TEMPERATURE = "android.sensor.temperature",
         TYPE_ACCELEROMETER = 1,
         TYPE_ACCELEROMETER_UNCALIBRATED = 35,
         TYPE_ALL = -1,
         TYPE_AMBIENT_TEMPERATURE = 13,
         TYPE_DEVICE_PRIVATE_BASE = 65536,
         TYPE_GAME_ROTATION_VECTOR = 15,
         TYPE_GEOMAGNETIC_ROTATION_VECTOR = 20,
         TYPE_GRAVITY = 9,
         TYPE_GYROSCOPE = 4,
         TYPE_GYROSCOPE_UNCALIBRATED = 16,
         TYPE_HEART_BEAT = 31,
         TYPE_HEART_RATE = 21,
         TYPE_LIGHT = 5,
         TYPE_LINEAR_ACCELERATION = 10,
         TYPE_LOW_LATENCY_OFFBODY_DETECT = 34,
         TYPE_MAGNETIC_FIELD = 2,
         TYPE_MAGNETIC_FIELD_UNCALIBRATED = 14,
         TYPE_MOTION_DETECT = 30
    }
}
