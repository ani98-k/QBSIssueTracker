using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;

using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using QBSIssueTracker;
using QBSIssueTracker.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidMethods))]
namespace QBSIssueTracker.Droid
{
    class AndroidMethods : IAndroidMethods
    {
        public static int _width;
        public static int _heigth;
        public static int WidthPixels { get; set; }
        public static int HeightPixels { get; set; }
        public AndroidMethods()
        {
        }

        public void CloseApp()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }

        public int GetDeviceHeigth()
        {
            return _heigth;
        }

        public int GetDeviceHeigthPixels()
        {
            return HeightPixels;
        }

        public int GetDeviceWidth()
        {

            return _width;
        }

        public int GetDeviceWidthPixels()
        {
            return WidthPixels;
        }

        public void OnSleep()
        {
            throw new NotImplementedException();
        }

        public void SendToBackground()
        {
            throw new NotImplementedException();
        }
    }
}