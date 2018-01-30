using UnityEngine;
using Windows.Kinect;

public class arCaveTranslateBehaviour : MonoBehaviour
{
    float firstdeep = -1;

    public void CaveTranslate(GameObject gameObject, Body body)
    {
        Debug.Log("Hi there");
        float horizontal =
            (float)(body.Joints[JointType.HandRight].Position.X
            * 0.05);

        float vertical =
            (float)(body.Joints[JointType.HandRight].Position.Y
            * 0.05);


        if (firstdeep == -1)
        {
            firstdeep =
                (float)(body.Joints[JointType.HandRight].Position.Z
                * 0.05);
            Debug.Log(firstdeep);
        }

        float deep =
            (float)(body.Joints[JointType.HandRight].Position.Z
            * 0.05) - firstdeep;


        gameObject.transform.position = new Vector3
            (
                gameObject.transform.position.x + horizontal,
                gameObject.transform.position.y + vertical,
                transform.position.z - deep
            );
    }
}
