using UnityEngine;
using Windows.Kinect;

public class arCaveScaleBehaviour : MonoBehaviour
{
    private KinectSensor _Sensor;
    private BodyFrameReader _Reader;
    private Body[] _Data = null;
    float firstdeep = -1;
    public BodySourceManager _bodySourceManager;

    // Update is called once per frame
    public void CaveScale(GameObject gameObject)
    {
        Debug.Log("Hi there");
        if (_bodySourceManager == null)
        {
            return;
        }

        Body[] data = _bodySourceManager.GetData();
        if (data == null)
        {
            return;
        }

        foreach (var body in data)
        {
            if (body == null)
            {
                continue;
            }

            if (body.HandRightState == HandState.Open)
            {
                float sizex = (float)(body.Joints[JointType.HandRight].Position.X * 0.1);
                float sizey = (float)(body.Joints[JointType.HandRight].Position.Y * 0.1);
                float sizez = (float)(body.Joints[JointType.HandRight].Position.Z * 0.1);

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
