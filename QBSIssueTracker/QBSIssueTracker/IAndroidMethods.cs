namespace QBSIssueTracker
{
    public interface IAndroidMethods
    {
        int GetDeviceWidth();
        int GetDeviceWidthPixels();
        int GetDeviceHeigthPixels();
        int GetDeviceHeigth();
        void CloseApp();
        void SendToBackground();
        void OnSleep();
    }
}