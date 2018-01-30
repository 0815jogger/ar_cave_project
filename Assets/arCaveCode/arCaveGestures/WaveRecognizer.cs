using Windows.Kinect;

public class WaveRecognizer
{
    private enum HandPositon { Left, Right, None };
    private BodySourceManager bodySoureManager;
    private int count;
    private HandPositon lastPositon;
    private const int WAVES_TIL_ACTIVATED = 7;

    public WaveRecognizer(BodySourceManager bodySoureManager)
    {
        this.bodySoureManager = bodySoureManager;
        Reset();
    }

    private HandPositon GetHandPosition()
    {
        Body[] data = bodySoureManager.GetData();
        if (data == null)
        {
            return HandPositon.None;
        }

        foreach (Body body in data)
        {
            if (body == null)
            {
                continue;
            }

            // Hand above elbow
            if (body.Joints[JointType.HandRight].Position.Y >
                body.Joints[JointType.ElbowRight].Position.Y)
            {
                // Hand right of elbow
                if (body.Joints[JointType.HandRight].Position.X >
                    body.Joints[JointType.ElbowRight].Position.X)
                {
                    return HandPositon.Right;
                }
                return HandPositon.Left;
            }

        }
        // Hand dropped
        return HandPositon.None;
    }

    public void Update()
    {
        HandPositon position = GetHandPosition();
        if (position == WaveRecognizer.HandPositon.None)
        {
            count = 0;
        }
        else
        {
            if (position != lastPositon)
            {
                count++;
            }
        }
        lastPositon = position;   
    }

    public bool isActivated()
    {
        return count >= WAVES_TIL_ACTIVATED;
    }

    public void Reset()
    {
        count = 0;
        lastPositon = HandPositon.None;
    }
}
