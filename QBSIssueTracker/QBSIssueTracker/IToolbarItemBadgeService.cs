using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace QBSIssueTracker
{
    public interface IToolbarItemBadgeService
    {
        //Page: Current page
        //Item: Actual toolbar item in which will add the badge
        //Value: Actual number of the badge(Is a string so you can set numbers and texts, but just tested with 2 digits numbers :P).
        //BackgroundColor: To set the badge background color
        //TextColor: To set the badge text color
        void SetBadge(Page page, ToolbarItem item, string value, Color backgroundColor, Color textColor);
    }
}
