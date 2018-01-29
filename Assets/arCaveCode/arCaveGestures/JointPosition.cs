using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class JointPosition : MonoBehaviour 
{
    public Windows.Kinect.JointType _jointType;
    public GameObject _bodySourceManager;
    private BodySourceManager _bodyManager;
    private ArCaveTranslateBehaviour _translateBehaviour;
    public float multiplier = 10f;
    public float firstdeep = -1;

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

        _bodyManager = _bodySourceManager.GetComponent<BodySourceManager>();
        if (_bodyManager == null)
        {
            return;
        }

        Body[] data = _bodyManager.GetData();
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
                    //_translateBehaviour.CaveTranslate(this.gameObject);

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

                        this.gameObject.transform.position = new Vector3
                            (
                                this.gameObject.transform.position.x + horizontal,
                                this.gameObject.transform.position.y + vertical,
                                this.transform.position.z - deep
                            );
                        //var pos = body.Joints[_jointType].Position;
                        //this.gameObject.transform.position = new Vector3(pos.X * multiplier, pos.Y * multiplier, pos.Z * multiplier);
                    }
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
