using Windows.Kinect;

namespace KinectSimpleGesture
{
    public interface IGestureSegment
    {
        GesturePartResult Update(BodySourceManager bodySourceManager);
    }


public class WaveSegment1 : IGestureSegment
    {
        
        public GesturePartResult Update(BodySourceManager _bodySourceManager)
        {
            Body[] data = _bodySourceManager.GetData();
            if (data == null)
            {
                return GesturePartResult.Failed;
            }

            foreach (var body in data)
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
                        return GesturePartResult.Succeeded;
                    }
                }

            }
            // Hand dropped
            return GesturePartResult.Failed;
        }
    }

    public class WaveSegment2 : IGestureSegment
    {
        public GesturePartResult Update(BodySourceManager _bodySourceManager)
        {
            Body[] data = _bodySourceManager.GetData();

            if (data == null)
            {
                return GesturePartResult.Failed;
            }

            foreach (var body in data)
            {
                if (body == null)
                {
                    continue;
                }
                // Hand above elbow
                if (body.Joints[JointType.HandRight].Position.Y >
                    body.Joints[JointType.ElbowRight].Position.Y)
                {
                    // Hand left of elbow
                    if (body.Joints[JointType.HandRight].Position.X <
                        body.Joints[JointType.ElbowRight].Position.X)
                    {
                        return GesturePartResult.Succeeded;
                    }
                }
            }
            // Hand dropped
            return GesturePartResult.Failed;
        }
    }
}
