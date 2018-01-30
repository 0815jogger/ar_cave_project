using Windows.Kinect;

public class WaveRecognizer
{
    public enum HandPositon { Left, Right, None };
    private BodySourceManager bodySoureManager;

    public WaveRecognizer(BodySourceManager bodySoureManager)
    {
        this.bodySoureManager = bodySoureManager;
    }

    public HandPositon GetHandPosition()
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
}
