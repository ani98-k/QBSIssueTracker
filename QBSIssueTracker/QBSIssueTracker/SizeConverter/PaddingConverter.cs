using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace QBSIssueTracker.SizeConverter
{
    class PaddingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var Size = value.ToString();
            try
            {
                var defSize = Int32.Parse(Size);

                var i = DeviceDisplay.MainDisplayInfo.Height;
                var dencity = DeviceDisplay.MainDisplayInfo.Density;
                if (Device.Idiom == TargetIdiom.Phone)
                {


                    if (DeviceDisplay.MainDisplayInfo.Height/DeviceDisplay.MainDisplayInfo.Density < 450)
                    {
                        var sizeChanging = (int)defSize / 2;
                        return new Thickness((defSize - 1.8*sizeChanging ));

                    }
                    else if (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density < 550)
                    {
                        var sizeChanging = (int)defSize / 2;
                        return new Thickness((defSize - 1.4*sizeChanging));
                    }
                    else if (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density < 600)
                    {
                        var sizeChanging = (int)defSize / 2;
                        return new Thickness((defSize - sizeChanging - 1.3*defSize ));
                    }
                    else if (DeviceDisplay.MainDisplayInfo.Height < 1500)
                    {
                        var sizeChanging = (int)defSize / 2;
                        return new Thickness((defSize - sizeChanging));
                    }
                    else if (DeviceDisplay.MainDisplayInfo.Density > 3)
                    {
                        var sizeChanging = (int)defSize / 4;
                        return new Thickness((defSize - sizeChanging));
                    }
                }
                else if (Device.Idiom == TargetIdiom.Tablet)
                {

                    if (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density < 650)
                    {
                        var sizeChanging = (int)defSize / 2;
                        return new Thickness((defSize - 1.8 * sizeChanging));

                    }
                    else if (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density < 750)
                    {
                        var sizeChanging = (int)defSize / 2;
                        return new Thickness((defSize - 1.5 * sizeChanging));
                    }
                    else if (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density < 1050)
                    {
                        var sizeChanging = (int)defSize / 2;
                        return new Thickness((defSize - 1.2*sizeChanging ));
                    }
                    else if (DeviceDisplay.MainDisplayInfo.Height < 1500)
                    {
                        var sizeChanging = (int)defSize / 2;
                        return new Thickness((defSize - sizeChanging));
                    }
                    else if (DeviceDisplay.MainDisplayInfo.Density > 3)
                    {
                        var sizeChanging = (int)defSize / 4;
                        return new Thickness((defSize - sizeChanging));
                    }
                }
                    return new Thickness(double.Parse(value.ToString()));
                
            }
            catch (Exception)
            {

                var sizes = Size.Split(new char[] {',' },StringSplitOptions.RemoveEmptyEntries);
                var leftPadding = System.Convert.ToDouble(sizes[0]);
                var topPadding = System.Convert.ToDouble(sizes[1]);
                var rightPadding = System.Convert.ToDouble(sizes[2]);
                var bottomPadding = System.Convert.ToDouble(sizes[2]);
                if (Device.Idiom == TargetIdiom.Phone)
                {


                    if (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density < 430)
                    {
                        //return new Thickness
                        //    ((leftPadding - 1.3*leftPadding / 2), (topPadding - 1.3*topPadding / 2), rightPadding - 1.3*rightPadding / 2, leftPadding - 1.3*leftPadding / 2);
                        return new Thickness(0, 0, 0, 0);
                    }
                    else if (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density < 550)
                    {

                        return new Thickness
                            ((leftPadding - 1.6*leftPadding / 2), (topPadding - 1.6*topPadding / 2), rightPadding - 1.6*rightPadding / 2, leftPadding - 1.6*leftPadding / 2);

                    }
                    else if (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density <700)
                    {

                        return new Thickness
                            ((leftPadding - leftPadding / 2), (topPadding - topPadding / 2), rightPadding - rightPadding / 2, leftPadding - leftPadding / 2);

                    }
                }
                else if (Device.Idiom == TargetIdiom.Tablet)
                {


                    if (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density < 550)
                    {
                        //return new Thickness
                        //    ((leftPadding - 1.3*leftPadding / 2), (topPadding - 1.3*topPadding / 2), rightPadding - 1.3*rightPadding / 2, leftPadding - 1.3*leftPadding / 2);
                        return new Thickness(0, 0, 0, 0);
                    }
                    else if (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density < 750)
                    {

                        return new Thickness
                            ((leftPadding - 1.6*leftPadding / 2), (topPadding - 1.6*topPadding / 2), rightPadding - 1.6*rightPadding / 2, leftPadding - 1.6*leftPadding / 2);

                    }
                    else if (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density <1050)
                    {

                        return new Thickness
                            ((leftPadding - leftPadding / 2), (topPadding - topPadding / 2), rightPadding - rightPadding / 2, leftPadding - leftPadding / 2);

                    }
                }
                return new Thickness(leftPadding, topPadding, rightPadding, bottomPadding);
            }

            //else if (DeviceDisplay.MainDisplayInfo.Height>2000)
            //{
            //    var sizeChanging = (int)defSize / 2;
            //    return new Thickness((defSize + sizeChanging));
            //}

           
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
