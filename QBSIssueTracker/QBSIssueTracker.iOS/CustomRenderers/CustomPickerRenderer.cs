using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using QBSIssueTracker.CusromRenderers;
using QBSIssueTracker.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(WithoutUnderlinePicker), typeof(CustomPickerRenderer))]
namespace QBSIssueTracker.iOS.CustomRenderers
{
    class CustomPickerRenderer:PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            var view = e.NewElement as Picker;
            this.Control.BorderStyle = UITextBorderStyle.None;
        }
    }
}