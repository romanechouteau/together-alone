using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using freenect;
using UnityEngine;

public class KinectConnector : MonoBehaviour
{
    void Start()
    {
        print(Kinect.DeviceCount + " Kinects detected.");

        if (Kinect.DeviceCount > 0)
        {
            Kinect myKinect = new Kinect(0);
            if (!myKinect.IsOpen)
            {
                myKinect.Open();
            }
            myKinect.LED.Color = LEDColor.Red;
            myKinect.Motor.Tilt = 1.0;
        }
        else
        {
            print("There's no Kinect plugged-in");
        }
    }
}
