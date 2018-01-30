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
    private HandOpenRecognizer handOpenRecognizer;
    private int modus = 0;
    public string gestureText = "Detected Gesture: ";
    public string gestureMode;
    GUIStyle largeFont;


    // Use this for initialization
    void Start () 
    {
        gestureMode = gestureText + modus.ToString();
        waveRecognizer = new WaveRecognizer(_bodySourceManager);
        handOpenRecognizer = new HandOpenRecognizer(_bodySourceManager);
	}


    void OnGUI()
    {
        largeFont = new GUIStyle();
        largeFont.fontSize = 20;
        largeFont.normal.textColor = Color.red;
        GUI.Label(new Rect(10, 10, 140, 20), gestureMode, largeFont);
    }

	
	// Update is called once per frame
	void Update () 
    {
        
        switch(modus)
        {
            case 0:
                waveRecognizer.Update();
                if (waveRecognizer.IsActive())
                {
                    waveRecognizer.Reset();
                    modus = 1;
                    gestureMode = gestureText + modus.ToString();
                }
                break;
            case 1:
            default:
                if (handOpenRecognizer.IsActive())
                {
                    Body body = handOpenRecognizer.GetBody();
                    _translate.CaveTranslate(this.gameObject, body);
                }
                break;
        }
        
	}
}

