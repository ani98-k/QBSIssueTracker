using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace QBSIssueTracker.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            IosMethods._heigth = (int)UIScreen.MainScreen.Bounds.Height;
            IosMethods._width = (int)UIScreen.MainScreen.Bounds.Width;
            
            
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
