using Windows.Kinect;

public class WaveRecognizer : Recognizer
{
    private enum HandPositon { Left, Right, None };
    private BodySourceManager bodySoureManager;
    private int count;
    private HandPositon lastPositon;
    private const int WAVES_TIL_ACTIVATED = 4;

    public WaveRecognizer(BodySourceManager bodySourceManager) : base(bodySourceManager)
    {
        Reset();
    }

    private HandPositon GetHandPosition()
    {
        Body body = this.GetBody();
        if (body == null)
        {
            return HandPositon.None;
        }
        if (body.Joints[JointType.HandLeft].Position.Y >
            body.Joints[JointType.ElbowLeft].Position.Y)
        {
            // Hand right of elbow
            if (body.Joints[JointType.HandLeft].Position.X >
                body.Joints[JointType.ElbowLeft].Position.X)
            {
                return HandPositon.Right;
            }
            return HandPositon.Left;
        }
        return HandPositon.None;
    }

    public override bool IsActive()
    {
        return count >= WAVES_TIL_ACTIVATED;
    }

    public override void Reset()
    {
        count = 0;
        lastPositon = HandPositon.None;
    }

    public override void Update()
    {
        HandPositon position = GetHandPosition();
        if (position == HandPositon.None)
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
}
