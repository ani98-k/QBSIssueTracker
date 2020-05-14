using System;
using System.Collections.Generic;
using System.Text;

namespace QBSIssueTracker
{
    public interface IIosMethods
    {
        int GetDeviceWidthPixels();
        int GetDeviceHeigthPixels();
        int GetDeviceWidth();
        int GetDeviceHeigth();
        void CloseApp();
    }
}
