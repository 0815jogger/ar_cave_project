using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class JointPosition : MonoBehaviour 
{
    public Windows.Kinect.JointType _jointType;
    public BodySourceManager _bodySourceManager;
    public arCaveTranslateBehaviour _translate;
    public float multiplier = 10f;
    public float firstdeep = -1;
    public GameObject mcVoxel;

    // Use this for initialization
    void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (_bodySourceManager == null)
        {
            return;
        }

        Body[] data = _bodySourceManager.GetData();
        if (data == null)
        {
            return;
        }

        // get the first tracked body...
        foreach (var body in data)
        {
            if (body == null)
            {
                continue;
            }

            if (body.IsTracked)
            {
                if (body.Joints[JointType.HandLeft].Position.Y > body.Joints[JointType.Head].Position.Y)
                {
                    Debug.Log("Hey, where's your hand ??");
                    _translate.CaveTranslate(this.gameObject);

                    /*
                    if (body.HandRightState == HandState.Open)
                    {
                        float horizontal =
                            (float)(body.Joints[JointType.HandRight].Position.X
                            * 0.01);

                        float vertical =
                            (float)(body.Joints[JointType.HandRight].Position.Y
                            * 0.01);


                        if (firstdeep == -1)
                        {
                            firstdeep =
                                (float)(body.Joints[JointType.HandRight].Position.Z
                                * 0.01);
                            Debug.Log(firstdeep);
                            //System.Console.WriteLine(firstdeep);
                        }
                        //float deep = 0;

                        float deep =
                            (float)(body.Joints[JointType.HandRight].Position.Z
                            * 0.01) - firstdeep;

                        this.gameObject.transform.position = new Vector3
                            (
                                this.gameObject.transform.position.x + horizontal,
                                this.gameObject.transform.position.y + vertical,
                                this.transform.position.z - deep
                            );
                        //var pos = body.Joints[_jointType].Position;
                        //this.gameObject.transform.position = new Vector3(pos.X * multiplier, pos.Y * multiplier, pos.Z * multiplier);
                    } */
                }
                else
                {
                    Debug.Log("Ahh, few!");
                }

                //this.gameObject.transform.position = new Vector3
                // this.gameObject.transform.localPosition =  body.Joints[_jointType].Position;

                // this code is for recognizing the Position of left or right hand for example
                //var pos = body.Joints[_jointType].Position;
                //this.gameObject.transform.position = new Vector3(pos.X * multiplier, pos.Y * multiplier, pos.Z * multiplier);
                
                break;
            }
        }
	}
}

