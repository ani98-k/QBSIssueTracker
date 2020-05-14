using Badge.Plugin;

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
    public partial class MenuPageDetail : ContentPage
    {
        public static Page MenuPageDetailStatic;
        public TapGestureRecognizer ToolbarmenuImage_tapGestureRecognizer;
        private TapGestureRecognizer _masterPlusIcon_tapGestureRecognizer;
        private TapGestureRecognizer _masterHomeButton_tapGestureRecognizer;
        public ListView IssueList { get; set; }

        public MenuPageDetail()
        {
            InitializeComponent();
            MenuPageDetailStatic = this;
            NavigationPage.SetHasNavigationBar(this, false);
            ToolbarmenuImage_tapGestureRecognizer = new TapGestureRecognizer();
            _masterPlusIcon_tapGestureRecognizer = new TapGestureRecognizer();
            _masterHomeButton_tapGestureRecognizer = new TapGestureRecognizer();
            _masterPlusIcon_tapGestureRecognizer.Tapped += MasterPlusIcon_tapGestureRecognizer_Tapped;
            _masterHomeButton_tapGestureRecognizer.Tapped += (s, e) =>
            {
               var menuPage= GetLastPageOfModalStack();
                MainContent.Children.Clear();
                MainContent.Children.Add(new MainView(MainContent));
                MainContent.ClassId = "This is the Main view";
                if (menuPage is MenuPage)
                {
                   var menu= menuPage as MenuPage;
                    menu.IsPresented = false;
                    
                }
                
            };
            
            ToolbarmenuImage.GestureRecognizers.Add(ToolbarmenuImage_tapGestureRecognizer);
            //  MainContent.Children.Add(new MainView().Content);
            //  MainContent.Children.Add(new EditIssueView().Content);
            MainContent.Children.Add(new MainView(MainContent));
            var mainView = MainContent.Children.GetEnumerator();
            mainView.MoveNext();
            var issueList = mainView.Current;
            IssueList = (issueList as MainView).IssueList;
            searchButton.CommandParameter = IssueList;
          //  MainContent.ClassId = "This is the Main view";

        }

        private static Page GetLastPageOfModalStack()
        {
            var enumerator = Application.Current.MainPage.Navigation.ModalStack.GetEnumerator();

            var lastPage = enumerator.Current;
            var navigationPage = lastPage as NavigationPage;
            while (enumerator.MoveNext())
            {
                lastPage = enumerator.Current;
                navigationPage = lastPage as NavigationPage;
                if (navigationPage.RootPage is MenuPage)
                {
                    lastPage = enumerator.Current;
                    return navigationPage.RootPage;
                }
                
            }
          
            
            return navigationPage.RootPage;
        }

        private void MasterPlusIcon_tapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var menuPage = GetLastPageOfModalStack();
            MainContent.Children.Clear();
            MainContent
                 .Children
                 .Add(new AddIssueView(MainContent.HeightRequest, MainContent.WidthRequest,this.MainContent));
          //  MainContent.ClassId = "Another Page";
            if (menuPage is MenuPage)
            {
                var menu = menuPage as MenuPage;
                menu.IsPresented = false;

            }
        }

        public TapGestureRecognizer GetMasterHomeBtnTapGestureRecognizer()
        {
            return _masterHomeButton_tapGestureRecognizer;
        }
        public TapGestureRecognizer GetMasterPlusIconTapGestureRecognizer()
        {
            return _masterPlusIcon_tapGestureRecognizer;
        }
        private void SeartchToolbar_Clicked(object sender, EventArgs e)
        {
            var thisBtn = sender as Image;
            thisBtn.IsEnabled = false;
            MainContent.IsEnabled = false;

            SearchView.IsVisible = true;
            SearchView.IsEnabled = true;

            TapGestureRecognizer mainLayout_Tapped = new TapGestureRecognizer();
            mainLayout_Tapped.Tapped += (s, e1) =>
            {
                SearchView.IsVisible = false;
                SearchView.IsEnabled = false;
                MainGridLayout.GestureRecognizers.Clear();
                MainContent.IsEnabled = true;
            };
            MainGridLayout.GestureRecognizers.Add(mainLayout_Tapped);
            thisBtn.IsEnabled = true;
          //  
        }
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            notView.IsVisible = true;
        }
        protected override bool OnBackButtonPressed()
        {


            //    if (MainContent.Children.Contains(new MainView(MainContent).Content))
            //    {
            //        return !base.OnBackButtonPressed();
            //    }
            //    else
            //    {
            //        MainContent.Children.Clear();
            //        MainContent.Children.Add(new MainView(MainContent).Content);
            //        return !base.OnBackButtonPressed();
            //    }
            var asdf= MainContent.Children.GetEnumerator();
            var lastPage = asdf.Current;
            var currentView = lastPage as ContentView;
            while (asdf.MoveNext())
            {
                lastPage = asdf.Current;
                currentView = lastPage as ContentView;
              

            }
            if (currentView.ClassId != "This is the Main view")
            {

                MainContent.Children.Clear();
                MainContent.Children.Add(new MainView(MainContent));
                MainContent.ClassId = "This is the Main view";
                return !base.OnBackButtonPressed();
               
            }
            else
            {
                if (Device.OS == TargetPlatform.Android)
                {
                    DependencyService.Get<IAndroidMethods>().CloseApp();
                }
                else if (Device.OS == TargetPlatform.iOS)
                {
                    DependencyService.Get<IIosMethods>().CloseApp();
                }
                return !base.OnBackButtonPressed();
            }

        }

        private void SearchViewCancelBtn_Clicked(object sender, EventArgs e)
        {
            SearchView.IsVisible = false;
            SearchView.IsEnabled = false;
            //   MainGridLayout.GestureRecognizers.Clear();
            MainContent.IsEnabled = true;
        }
    }
}