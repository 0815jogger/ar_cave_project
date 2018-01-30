using UnityEngine;
using Microsoft.Kinect;
using Windows.Kinect;

/*
namespace KinectSimpleGesture
{
    public interface IGestureSegment
    {
        GesturePartResult Update(Skeleton skeleton);
    }

    Body[] data = _bodyManager.GetData();

public class WaveSegment1 : IGestureSegment
    {
        public GameObject _bodySourceManager;
        private BodySourceManager _bodyManager;

        public GesturePartResult Update(Skeleton skeleton)
        {
            if (data == null)
            {
                return;
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

                // Hand dropped
                return GesturePartResult.Failed;
            }
        }
    }

    public class WaveSegment2 : IGestureSegment
    {
        public GesturePartResult Update(Skeleton skeleton)
        {
            foreach (var body in data)
            {
                if (body == null)
                {
                    continue;
                }
                // Hand above elbow
                if (data.Joints[JointType.HandRight].Position.Y >
                    data.Joints[JointType.ElbowRight].Position.Y)
                {
                    // Hand left of elbow
                    if (data.Joints[JointType.HandRight].Position.X <
                        data.Joints[JointType.ElbowRight].Position.X)
                    {
                        return GesturePartResult.Succeeded;
                    }
                }
                // Hand dropped
                return GesturePartResult.Failed;
            }
        }
    }
}
*/