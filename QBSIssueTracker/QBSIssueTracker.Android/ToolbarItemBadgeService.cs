﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Android.Graphics.Drawables;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.CurrentActivity;
using QBSIssueTracker.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.Dependency(typeof(ToolbarItemBadgeService))]
namespace QBSIssueTracker.Droid
{
    class ToolbarItemBadgeService : IToolbarItemBadgeService
    {
        public void SetBadge(Page page, ToolbarItem item, string value, Color backgroundColor, Color textColor)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                
                // var toolbar1 = CrossCurrentActivity.Current.Activity.FindViewById(Resource.Id.toolbar);
               
               var toolbar = CrossCurrentActivity.Current.Activity.FindViewById(Resource.Id.toolbar) as Android.Support.V7.Widget.Toolbar;
                //  var toolbar = page.ToolbarItems as Android.Support.V7.Widget.Toolbar;
                
                if (toolbar != null)
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        var idx = page.ToolbarItems.IndexOf(item);
                        if (toolbar.Menu.Size() > idx)
                        {

                            var menuItem = toolbar.Menu.GetItem(idx);

                            BadgeDrawable.SetBadgeText(CrossCurrentActivity.Current.Activity, menuItem, value, backgroundColor.ToAndroid(), textColor.ToAndroid());
                        }
                    }
                }

            });
        }
    }
}