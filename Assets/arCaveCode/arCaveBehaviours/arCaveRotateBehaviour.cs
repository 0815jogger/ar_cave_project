using UnityEngine;
using Windows.Kinect;

public class ArCaveRotateBehaviour : MonoBehaviour
{
    public void CaveRotate(GameObject gameObject, Body body)
    {
        float anglex = (float)(body.Joints[JointType.HandRight].Position.Y);
        float angley = - (float)(body.Joints[JointType.HandRight].Position.X);
        float anglez = 0; // (float)(body.Joints[JointType.HandRight].Position.X);

        gameObject.transform.rotation = Quaternion.Euler
            (
                gameObject.transform.rotation.x + anglex * 200,
                gameObject.transform.rotation.y + angley * 200,
                gameObject.transform.rotation.z + anglez * 200
            );
    }
}
