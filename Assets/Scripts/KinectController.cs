using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using freenect;
using UnityEngine;

public class KinectController : Singleton<KinectController>
{
    private Kinect myKinect = null;

    private Texture2D depthTex;
    public Material PlaneMaterial;
    private bool isRunning = true;
    private Thread t = null;

    public void Start()
    {
        depthTex = new Texture2D(256, 256, TextureFormat.PVRTC_RGBA4, false);
        print(Kinect.DeviceCount + " Kinect(s) detected.");
        myKinect = new Kinect(0);
        if (Kinect.DeviceCount > 0)
        {
            if (!myKinect.IsOpen)
            {
                myKinect.Open();
                isRunning = true;
            }
            myKinect.LED.Color = LEDColor.Green;
            myKinect.Motor.Tilt = 1;

            // Setup event handlers

            // myKinect.DepthCamera.DataReceived += HandleKinectDepthCameraDataReceived;

            // Start cameras
            myKinect.VideoCamera.Start();
            // myKinect.DepthCamera.Start();


            // Start update thread
            // t = new Thread(delegate ()
            // {
            //     myKinect.VideoCamera.DataReceived += HandleKinectVideoCameraDataReceived;

            // });
            // t.Start();
            while (isRunning)
            {
                try
                {
                    // Update instance's status
                    myKinect.UpdateStatus();

                    // Let preview control render another frame
                    // this.previewControl.Render();

                    Kinect.ProcessEvents();
                }
                catch (ThreadInterruptedException e)
                {
                    print(e);
                }
                catch (Exception ex)
                {
                    print(ex);
                }
            }
        }
        else
        {
            print("There's no Kinect plugged-in");
        }
    }

    public void OnDisable()
    {
        isRunning = false;

        if (myKinect != null)
        {
            myKinect.Close();
        }
    }
    private void HandleKinectDepthCameraDataReceived(object sender, BaseCamera.DataReceivedEventArgs e)
    {
        print("depth");

        depthTex.Reinitialize(e.Data.Width, e.Data.Height, TextureFormat.PVRTC_RGBA4, false);
        depthTex.LoadRawTextureData(e.Data.Data);
        depthTex.Apply();
        GetComponent<Renderer>().material.mainTexture = depthTex;
        // Actual data is in e.Data
    }

    private void HandleKinectVideoCameraDataReceived(object sender, BaseCamera.DataReceivedEventArgs e)
    {
        print("video");
        depthTex.Reinitialize(e.Data.Width, e.Data.Height, TextureFormat.PVRTC_RGBA4, false);
        depthTex.LoadImage(e.Data.Data);
        GetComponent<Renderer>().material.mainTexture = depthTex;
        // depthTex.Apply();
        // Actual data is in e.Data
    }
}
