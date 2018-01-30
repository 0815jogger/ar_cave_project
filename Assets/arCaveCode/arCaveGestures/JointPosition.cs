using UnityEngine;
using Windows.Kinect;

public class JointPosition : MonoBehaviour 
{
    public Windows.Kinect.JointType _jointType;
    public BodySourceManager _bodySourceManager;
    public arCaveTranslateBehaviour _translate;
    public float multiplier = 10f;
    public float firstdeep = -1;
    public GameObject mcVoxel;
    private WaveRecognizer waveRecognizer;
    private int modus = 0;
    private int countWaves = 0;
    public string gestureText = "Detected Gesture: ";
    GUIStyle largeFont;


    // Use this for initialization
    void Start () 
    {
        waveRecognizer = new WaveRecognizer(_bodySourceManager);
	}


    void OnGUI()
    {
        largeFont = new GUIStyle();
        largeFont.fontSize = 20;
        largeFont.normal.textColor = Color.red;
        GUI.Label(new Rect(10, 10, 140, 20), gestureText, largeFont);
    }

	
	// Update is called once per frame
	void Update () 
    {
        gestureText += modus.ToString();
        switch(modus)
        {
            case 0:
                waveRecognizer.Update();
                if (waveRecognizer.isActivated())
                {
                    waveRecognizer.Reset();
                    modus = 1;
                }
                break;
            case 1:
            default:
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
                break;
        }
        
	}
}

