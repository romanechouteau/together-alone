using System.Collections;
using System.Collections.Generic;
using freenect;
using UnityEngine;

public class KinectConnector : MonoBehaviour
{
    void Start()
    {
        print(Kinect.DeviceCount);
    }

}
