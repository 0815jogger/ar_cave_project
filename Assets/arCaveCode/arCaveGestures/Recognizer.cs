using Windows.Kinect;

public abstract class Recognizer
{
    private BodySourceManager bodySourceManager;
    public Recognizer(BodySourceManager bodySourceManager)
    {
        this.bodySourceManager = bodySourceManager;
    }

    protected Body GetBody()
    {
        Body[] data = this.bodySourceManager.GetData();
        if (data == null)
        {
            return null;
        }

        foreach (Body body in data)
        {
            if (body != null && body.IsTracked)
            {
                return body;
            }
        }
        return null;
    }

    public abstract bool IsActive();
    public abstract void Reset();

    public abstract void Update();
}
