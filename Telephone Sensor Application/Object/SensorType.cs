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
         TYPE_ALL = -1,
         TYPE_ACCELEROMETER = 1,
         TYPE_MAGNETIC_FIELD = 2,
         TYPE_ORIENTATION = 3,
         TYPE_GYROSCOPE = 4,
         TYPE_LIGHT = 5,
         TYPE_PRESSURE = 6,
         TYPE_TEMPERATURE = 7,
         TYPE_PROXIMITY = 8,
         TYPE_GRAVITY = 9,
         TYPE_LINEAR_ACCELERATION = 10,
         TYPE_ROTATION_VECTOR = 11,
         TYPE_RELATIVE_HUMIDITY = 12,
         TYPE_AMBIENT_TEMPERATURE = 13,
         TYPE_MAGNETIC_FIELD_UNCALIBRATED = 14,
         TYPE_GAME_ROTATION_VECTOR = 15,
         TYPE_GYROSCOPE_UNCALIBRATED = 16,
         TYPE_SIGNIFICANT_MOTION = 17,
         TYPE_STEP_DETECTOR = 18,
         TYPE_STEP_COUNTER = 19,
         TYPE_GEOMAGNETIC_ROTATION_VECTOR = 20, 
         TYPE_HEART_RATE = 21,
         TYPE_Tilt_Detector = 22,//
         TYPE_POSE_6DOF = 28,
         TYPE_STATIONARY_DETECT = 29,
         TYPE_MOTION_DETECT = 30,
         TYPE_HEART_BEAT = 31,
         TYPE_LOW_LATENCY_OFFBODY_DETECT = 34,
         TYPE_ACCELEROMETER_NCALIBRATED = 35,
         TYPE_DEVICE_PRIVATE_BASE = 65536,
         TYPE_AMD = 33171006,
         TYPE_RMD = 33171007,
         TYPE_BASIC_GESTURES = 33171000,
         TYPE_FACING = 33171002,
         TYPE_PEDOMETER = 33171009,
         TYPE_MOTION_ACCEL = 33171011,
         TYPE_COARSE_MOTION_CLASSIFIER = 33171012,
         TYPE_IOD = 33171021,
         TYPE_DPC = 33171022,
         TYPE_MUTILSHAKE = 33171023,
         TYPE_PERSISTENT_MOTION_DETECTOR = 33171024,
         TYPE_OEM5_TAPTAP_GESTURE = 33171027
    }
}
