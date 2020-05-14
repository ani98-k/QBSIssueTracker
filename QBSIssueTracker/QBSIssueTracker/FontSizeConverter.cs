using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace QBSIssueTracker
{
    public class FontSizeConverter:IValueConverter
    {
        private int _deviceHeight;
        private int _deviceWidth;
        private Int32 _defSize;
      

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var defSize = value.ToString();
            _defSize = Int32.Parse(defSize);
            if (Device.OS == TargetPlatform.Android)
            {
                _deviceHeight = DependencyService.Get<IAndroidMethods>().GetDeviceHeigth();
                _deviceWidth = DependencyService.Get<IAndroidMethods>().GetDeviceWidth();
            }
            else if (Device.OS == TargetPlatform.iOS)
            {
                _deviceHeight = DependencyService.Get<IIosMethods>().GetDeviceHeigth();
                _deviceWidth = DependencyService.Get<IIosMethods>().GetDeviceWidth();
            }
            if (_deviceHeight < 500)
            {

              
                return 12;
            }
            else if (_deviceHeight<600)
            {
                return 16;
            }
            else
            {
                return Int32.Parse(value.ToString());
            }
            
            
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
