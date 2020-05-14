using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QBSIssueTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddIssueView : ContentView
    {
        private StackLayout MainLayout;
        public AddIssueView()
        {
            this.ClassId = "AddIssueView";
            InitializeComponent();
            MainBindingView.MainPage = MenuPageDetail.MenuPageDetailStatic;

        }
        public AddIssueView(Double heightRequast, Double widthRecuast,StackLayout mainLayout)
        {
            this.ClassId = "AddIssueView";
            this.HeightRequest = heightRequast;
            this.WidthRequest = widthRecuast;
            MainLayout = mainLayout;
            InitializeComponent();
            MainBindingView.MainPage = MenuPageDetail.MenuPageDetailStatic;
            MainBindingView.XamlAttachmentsFrm = AttachmentsFrm;
            AttachmentsFrmForTap.GestureRecognizers.Add(MainBindingView.AttachmentsTapGesture);

        }

        private void CancelBtn_Clicked(object sender, EventArgs e)
        {
            MenuPageDetail.MenuPageDetailStatic.IsEnabled = false;
            MainLayout.Children.Clear();
            MainLayout.Children.Add(new MainView(MainLayout));
            MenuPageDetail.MenuPageDetailStatic.IsEnabled = true;
        }
    }
}