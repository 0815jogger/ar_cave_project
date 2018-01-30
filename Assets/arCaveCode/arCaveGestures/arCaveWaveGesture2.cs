using System;
using UnityEngine;

namespace KinectSimpleGesture
{
    public class arCaveWaveGesture : MonoBehaviour
    {
        private int count = 0;
        
        public BodySourceManager bodySourceManager;
        private WaveRecognizer waveRecognizer;
        private WaveRecognizer.HandPositon lastPositon = WaveRecognizer.HandPositon.None;


        public void Start()
        {
            this.waveRecognizer = new WaveRecognizer(bodySourceManager);
        }

        public void Update()
        {
            Debug.Log(count);
            // if (count < 7)
            if (count < int.MaxValue)
            {
                WaveRecognizer.HandPositon position = waveRecognizer.GetHandPosition();
                if (position == WaveRecognizer.HandPositon.None)
                {
                    count = 0;
                } else
                {
                    if (position != lastPositon)
                    {
                        count++;
                    }
                }
                lastPositon = position;
            } /*else
            {
                Debug.Log("Hallo :)");
                count = 0;
            }*/
        }

        public void Reset()
        {
            count = 0;
        }
    }
}