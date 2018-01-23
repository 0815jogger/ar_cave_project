using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class arCaveScaleBehaviour : MonoBehaviour
{

    private KinectSensor _Sensor;
    private BodyFrameReader _Reader;
    private Body[] _Data = null;
    float firstdeep = -1;


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
        if (_Reader != null)
        {
            var frame = _Reader.AcquireLatestFrame();

            if (frame != null)
            {
                if (_Data == null)
                {
                    _Data = new Body[_Sensor.BodyFrameSource.BodyCount];
                }

                frame.GetAndRefreshBodyData(_Data);

                frame.Dispose();
                frame = null;

                int idx = -1;
                for (int i = 0; i < _Sensor.BodyFrameSource.BodyCount; i++)
                {
                    if (_Data[i].IsTracked)
                    {
                        idx = i;
                    }
                }
                if (idx > -1)
                {
                    if (_Data[idx].HandRightState == HandState.Open)
                    {
                        float sizex = (float)(_Data[idx].Joints[JointType.HandRight].Position.X * 0.1);
                        float sizey = (float)(_Data[idx].Joints[JointType.HandRight].Position.Y * 0.1);
                        float sizez = (float)(_Data[idx].Joints[JointType.HandRight].Position.Z * 0.1);

                        this.gameObject.transform.localScale = new Vector3
                            (
                                this.gameObject.transform.localScale.x + sizex,
                                this.gameObject.transform.localScale.y + sizex,
                                this.gameObject.transform.localScale.z + sizex
                            );
                    }
                }
            }
        }
    }
}
