using UnityEngine;
using Windows.Kinect;

public class JointPosition : MonoBehaviour 
{
    public BodySourceManager _bodySourceManager;

    private arCaveTranslateBehaviour _translate = new arCaveTranslateBehaviour();
    private arCaveRotateBehaviour _rotate = new arCaveRotateBehaviour();
    private arCaveScaleBehaviour _scale = new arCaveScaleBehaviour();

    private WaveRecognizer waveRecognizer;
    private HandOpenRecognizer handOpenRecognizer;

    private int modus = 0;
    string[] modusText = { "...", "Translation", "Rotation", "Scale" };
    public string gestureText = "Mode: ";
    public string gestureMode;

    GUIStyle largeFont;


    // Use this for initialization
    void Start () 
    {
        gestureMode = gestureText + modusText[modus];
        waveRecognizer = new WaveRecognizer(_bodySourceManager);
        handOpenRecognizer = new HandOpenRecognizer(_bodySourceManager);
	}


    void OnGUI()
    {
        largeFont = new GUIStyle();
        largeFont.fontSize = 20;
        largeFont.normal.textColor = Color.red;
        //GUI.Label(new Rect(10, 10, 140, 20), gestureMode, largeFont);
        GUI.Label(new Rect(500, 70, 140, 20), gestureMode, largeFont);
    }


    // Update is called once per frame
    void Update()
    {
        waveRecognizer.Update();
        if (waveRecognizer.IsActive())
        {
            waveRecognizer.Reset();
            modus = (modus + 1) % 4;
            gestureMode = gestureText + modusText[modus];
        }


        if (handOpenRecognizer.IsActive())
        {
            Body body = handOpenRecognizer.GetBody();
            switch (modus)
            {
                case 1:
                    _translate.CaveTranslate(this.gameObject, body);
                    break;
                case 2:
                    _rotate.CaveRotate(this.gameObject, body);
                    break;
                case 3:
                    _scale.CaveScale(this.gameObject, body);
                    break;
            }
        }
        
	}
}

