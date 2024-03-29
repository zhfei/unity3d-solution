﻿//================================================================================================================================
//
//  Copyright (c) 2015-2023 VisionStar Information Technology (Shanghai) Co., Ltd. All Rights Reserved.
//  EasyAR is the registered trademark or trademark of VisionStar Information Technology (Shanghai) Co., Ltd in China
//  and other countries for the augmented reality technology developed by VisionStar Information Technology (Shanghai) Co., Ltd.
//
//================================================================================================================================

using easyar;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sample
{
    public class Sample : MonoBehaviour
    {
        public Button BackButton;
        public Text Status;
        public ARSession Session;
        public Camera MainCamera;

        private string deviceModel = string.Empty;
        private ImageTrackerFrameFilter tracker;
        private static Optional<DateTime> trialCounter;

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
        static void ImportSampleStreamingAssets()
        {
            FileUtil.ImportSampleStreamingAssets();
        }
#endif

        private void Awake()
        {
            var launcher = "AllSamplesLauncher";
            if (Application.CanStreamedLevelBeLoaded(launcher))
            {
                var button = BackButton.GetComponent<Button>();
                button.onClick.AddListener(() =>
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(launcher);
                });
            }
            else
            {
                BackButton.gameObject.SetActive(false);
            }

#if UNITY_ANDROID && !UNITY_EDITOR
            if (Application.platform == RuntimePlatform.Android)
            {
                try
                {
                    using (var buildClass = new AndroidJavaClass("android.os.Build"))
                    {
                        deviceModel = $"(Device = {buildClass.GetStatic<string>("DEVICE")}, Model = {buildClass.GetStatic<string>("MODEL")})";
                    }
                }
                catch (Exception e) { deviceModel = e.Message; }
            }
#endif
            tracker = Session.GetComponentInChildren<ImageTrackerFrameFilter>();

            Session.StateChanged += (state) =>
            {
                if (state == ARSession.SessionState.Ready)
                {
                    if (trialCounter.OnNone)
                    {
                        trialCounter = DateTime.Now;
                    }
                }
            };
        }

        private void Update()
        {
            Status.text = $"Device Model: {SystemInfo.deviceModel} {deviceModel}" + Environment.NewLine +
                "Frame Source: " + ((Session.Assembly != null && Session.Assembly.FrameSource) ? Session.Assembly.FrameSource.GetType().ToString().Replace("easyar.", "").Replace("FrameSource", "") : "-") + Environment.NewLine +
                "Tracking Status: " + Session.TrackingStatus + Environment.NewLine;

            if (Session.State == ARSession.SessionState.Assembling)
            {
                Status.text += "Please wait while checking all frame source availability...";
            }

            if (Session.State >= ARSession.SessionState.Ready)
            {
                if (Session.Assembly.FrameSource is CameraDeviceFrameSource)
                {
                    Status.text += Environment.NewLine +
                        "Motion tracking capability not available on this device." + Environment.NewLine +
                        "Fallback to image tracking." + Environment.NewLine;
                }
                else
                {
                    Status.text += Environment.NewLine +
                        "Motion Fusion: " + tracker.ResultType.EnableMotionFusion + Environment.NewLine +
                        (tracker.ResultType.EnableMotionFusion ? "Image must NOT move in real world." : "Image is free to move in real world.") + Environment.NewLine +
                    Environment.NewLine +
                    "    Image target scale must be set to physical image width." + Environment.NewLine +
                    "    Scale is preset to match long edge of A4 paper." + Environment.NewLine +
                    "    Suggest to print out images for test.";
                }
            }

            // avoid misunderstanding when using personal edition, not necessary in your own projects
            if (!string.IsNullOrEmpty(Engine.errorMessage()))
            {
                BackButton.GetComponent<Button>().interactable = false;
                trialCounter = DateTime.MinValue;
            }
            if (trialCounter.OnSome)
            {
                if (Session.State >= ARSession.SessionState.Ready && (FrameSource.IsCustomCamera(Session.Assembly.FrameSource) || trialCounter.Value == DateTime.MinValue))
                {
                    var time = Math.Max(0, (int)(trialCounter.Value - DateTime.Now).TotalSeconds + 100);
                    Status.text += $"\n\nEasyAR License for {Session.Assembly.FrameSource.GetType()} will timeout for current process within {time} seconds. (Personal Edition Only)";
                }
            }
        }

        public void SwitchMotionFusion(bool on)
        {
            tracker.ResultType = new ImageTrackerFrameFilter.ResultParameters { EnablePersistentTargetInstance = on, EnableMotionFusion = on };
        }
    }
}
