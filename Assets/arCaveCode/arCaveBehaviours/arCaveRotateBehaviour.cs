using UnityEngine;
using Windows.Kinect;

public class arCaveRotateBehaviour : MonoBehaviour
{
    public void CaveRotate(GameObject gameObject, Body body)
    {
        float anglex = (float)(body.Joints[JointType.HandRight].Position.X);
        float angley = (float)(body.Joints[JointType.HandRight].Position.Y);
        float anglez = (float)(body.Joints[JointType.HandRight].Position.Z);

        gameObject.transform.rotation = Quaternion.Euler
            (
                gameObject.transform.rotation.x + anglex * 100,
                gameObject.transform.rotation.y + angley * 100,
                gameObject.transform.rotation.z + anglez * 100
            );
    }
}
