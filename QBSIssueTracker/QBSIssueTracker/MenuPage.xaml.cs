using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QBSIssueTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : MasterDetailPage
    {
        private int _deviceHeight;
        private int _deviceWidth;
      
        public MenuPage()
        {
            InitializeComponent();
            // IsPresented = true;
            NavigationPage.SetHasNavigationBar(this, false);
            menuPageDetail.ToolbarmenuImage_tapGestureRecognizer.Tapped+= (s, e) => {
                // handle the tap
                IsPresented = true;
            };
            var toolbarPlusIcon = MasterPage.GetMasterPlusImage();
            var masterHomeBtn = MasterPage.GetMasterHomeImage();
            var masterIssueListBtn = MasterPage.GetMasterIssueListImage();
            masterHomeBtn.GestureRecognizers.Add(menuPageDetail.GetMasterHomeBtnTapGestureRecognizer());
            masterIssueListBtn.GestureRecognizers.Add(menuPageDetail.GetMasterHomeBtnTapGestureRecognizer());
            toolbarPlusIcon.GestureRecognizers.Add(menuPageDetail.GetMasterPlusIconTapGestureRecognizer());
            //MasterPage.ListView.ItemSelected += ListView_ItemSelected;


        }
       


        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MenuPageMasterMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private void MasterDetailPage_Appearing(object sender, EventArgs e)
        {
        }
       
    }
}