using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using QBSIssueTracker.CusromRenderers;
using QBSIssueTracker.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(WithoutUnderlinePicker), typeof(CustomPickerRenderer))]
namespace QBSIssueTracker.Droid.CustomRenderers
{
    class CustomPickerRenderer:PickerRenderer
    {
        private Context _context;
        public CustomPickerRenderer(Context context):base(context)
        {
            _context = context;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetStroke(0, Android.Graphics.Color.Transparent);
                Control.SetBackground(gd);
            }
        }
    }
}