using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class arCaveInitialScript : MonoBehaviour
{

    private KinectSensor _Sensor;
    private BodyFrameReader _Reader;


    // Use this for initialization
    void Start()
    {
        _Sensor = KinectSensor.GetDefault();

        if (_Sensor != null)
        {
            _Reader = _Sensor.BodyFrameSource.OpenReader();

            if (!_Sensor.IsOpen)
            {
                _Sensor.Open();
            }
        }
    }

    void OnApplicationQuit()
    {
        if (_Reader != null)
        {
            _Reader.Dispose();
            _Reader = null;
        }

        if (_Sensor != null)
        {
            if (_Sensor.IsOpen)
            {
                _Sensor.Close();
            }
            _Sensor = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
