using UnityEngine;
using Windows.Kinect;

public class arCaveTranslateBehaviour : MonoBehaviour
{
    private KinectSensor _Sensor;
    private BodyFrameReader _Reader;
    private Body[] _Data = null;
    float firstdeep = -1;
    public BodySourceManager _bodySourceManager; 

    public void CaveTranslate(GameObject gameObject)
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
                float horizontal =
                    (float)(body.Joints[JointType.HandRight].Position.X
                    * 0.1);

                float vertical =
                    (float)(body.Joints[JointType.HandRight].Position.Y
                    * 0.1);


                if (firstdeep == -1)
                {
                    firstdeep =
                        (float)(body.Joints[JointType.HandRight].Position.Z
                        * 0.1);
                    Debug.Log(firstdeep);
                    //System.Console.WriteLine(firstdeep);
                }
                //float deep = 0;

                float deep =
                    (float)(body.Joints[JointType.HandRight].Position.Z
                    * 0.1) - firstdeep;


                gameObject.transform.position = new Vector3
                    (
                        gameObject.transform.position.x + horizontal,
                        gameObject.transform.position.y + vertical,
                        transform.position.z - deep
                    );
            }
        }
    }
}
