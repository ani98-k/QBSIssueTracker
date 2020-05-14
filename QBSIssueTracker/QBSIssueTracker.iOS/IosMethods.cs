using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Foundation;
using UIKit;

namespace QBSIssueTracker.iOS
{
    class IosMethods : IIosMethods
    {
        public static int _width;
        public static int _heigth;
        public static int WidthPixels { get; set; }
        public static int HeightPixels { get; set; }
        public void CloseApp()
        {
            Thread.CurrentThread.Abort();
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
    }
}