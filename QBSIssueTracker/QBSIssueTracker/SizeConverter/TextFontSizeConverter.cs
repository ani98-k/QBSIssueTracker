using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace QBSIssueTracker.SizeConverter
{
    class TextFontSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var Size = value.ToString();
            var defSize = Int32.Parse(Size);
            var xHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
            var xWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
            if (Device.Idiom==TargetIdiom.Phone)
            {


                if (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density < 430)
                {
                    var sizeChanging = (int)defSize / 3;
                    var val = System.Convert.ToDouble(value) - 1.5 * sizeChanging;
                    return System.Convert.ToDouble(val);
                }
                else if (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density < 550)
                {
                    var sizeChanging = (int)defSize / 3;
                    var val = System.Convert.ToDouble(value) - 1.5 * sizeChanging;
                    return System.Convert.ToDouble(val);
                }
                else if (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density < 600)
                {
                    var sizeChanging = (int)defSize / 5;
                    var val = System.Convert.ToDouble(value) - 1.2 * sizeChanging;
                    return System.Convert.ToDouble(val);
                }
                var p = parameter as Label;
                var val1 = System.Convert.ToDouble(Size);
                return val1;
            }
            else if (Device.Idiom==TargetIdiom.Tablet)
            {
                if (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density < 500)
                {
                    var sizeChanging = (int)defSize / 3;
                    var val = System.Convert.ToDouble(value) - 1.5 * sizeChanging;
                    return System.Convert.ToDouble(val);
                }
                else if (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density < 750)
                {
                    var sizeChanging = (int)defSize / 3;
                    var val = System.Convert.ToDouble(value) - 1.3 * sizeChanging;
                    return System.Convert.ToDouble(val);
                }
                else if (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density < 1050)
                {
                    var sizeChanging = (int)defSize / 5;
                    var val = System.Convert.ToDouble(value) - 1.2 * sizeChanging;
                    return System.Convert.ToDouble(val);
                }
                var p = parameter as Label;
                var val2 = System.Convert.ToDouble(Size);
                return val2;
            }
            var val3 = System.Convert.ToDouble(Size);
            return val3;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
