using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace QBSIssueTracker.SizeConverter
{
    class HeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var Size = value.ToString();
            var defSize = Int32.Parse(Size);
            var asdf = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
            if (DeviceDisplay.MainDisplayInfo.Height/DeviceDisplay.MainDisplayInfo.Density<500)
            {
                var sizeChanging = (int)defSize / 3;
                var val = System.Convert.ToDouble(value) - 0.75*sizeChanging;
                return System.Convert.ToDouble(val) ;
            }
            return System.Convert.ToDouble(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
