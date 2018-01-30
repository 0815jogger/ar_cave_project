using UnityEngine;
using Windows.Kinect;

public class arCaveScaleBehaviour : MonoBehaviour
{
    // Update is called once per frame
    public void CaveScale(GameObject gameObject, Body body)
    {
        float sizex = (float)(body.Joints[JointType.HandRight].Position.X * 0.1);
        float sizey = (float)(body.Joints[JointType.HandRight].Position.Y * 0.1);
        float sizez = (float)(body.Joints[JointType.HandRight].Position.Z * 0.1);

        gameObject.transform.localScale = new Vector3
            (
                gameObject.transform.localScale.x + sizex,
                gameObject.transform.localScale.y + sizex,
                gameObject.transform.localScale.z + sizex
            );
    }
}
