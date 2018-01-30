using UnityEngine;
using Windows.Kinect;

public class arCaveRotateBehaviour : MonoBehaviour
{
    private KinectSensor _Sensor;
    private BodyFrameReader _Reader;
    private Body[] _Data = null;
    public BodySourceManager _bodySourceManager;

    public void CaveRotate(GameObject gameObject)
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

            if (body.HandRightState != HandState.Closed)
            {
                float anglex = (float)(body.Joints[JointType.HandRight].Position.X);
                float angley = (float)(body.Joints[JointType.HandRight].Position.Y);
                float anglez = (float)(body.Joints[JointType.HandRight].Position.Z);

                this.gameObject.transform.rotation = Quaternion.Euler
                    (
                        gameObject.transform.rotation.x + anglex * 100,
                        gameObject.transform.rotation.y + angley * 100,
                        gameObject.transform.rotation.z + anglez * 100
                    );
            }
        }
    }
}
