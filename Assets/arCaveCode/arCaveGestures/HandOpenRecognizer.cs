using Windows.Kinect;

public class HandOpenRecognizer : Recognizer
{
    public HandOpenRecognizer(BodySourceManager bodySourceManager) : base(bodySourceManager)
    {
    }

    public override bool IsActive()
    {
        Body body = GetBody();
        if (body == null)
        {
            return false;
        }
        return body.HandRightState == HandState.Open;
    }

    public override void Reset()
    {
    }

    public override void Update()
    {
    }
}