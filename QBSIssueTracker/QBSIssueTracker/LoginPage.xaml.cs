using QBSIssueTrackerAPI;
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
    public partial class LoginPage : ContentPage
    {
        private RegisterUserAPI _registerUserAPI;
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _registerUserAPI = new RegisterUserAPI();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            try
            {
                var token = await _registerUserAPI.Login(new Models.LogeIn
                {
                    UserName = userNameEntry.Text,
                    Password = passwordEntry.Text
                });
                try
                {
                    Application.Current.Properties.Add("token", token);
                    Application.Current.Properties.Add("UserName",userNameEntry.Text);
                }
                catch (Exception)
                {

                    
                }
                
                await this.Navigation.PushModalAsync(new NavigationPage(new MenuPage()));
            }
            catch (Exception ex)
            {
                userNameEntry.Text = ex.ToString();
               // userNameEntry.Text = "";
                passwordEntry.Text = "";
            }
          //  var token1 = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoicWJzLnN1cHBvcnQiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImE0NDc2ZGYzLTEyMDktNDM2Ni1iNTgxLWZkYTVmMzAwZDg3YiIsInN1YiI6InFicy5zdXBwb3J0IiwianRpIjoiZDJmZjBhMDctMjAxMS00ZmJmLTk2NDYtYmU2YTNkNGE0NWNhIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQXNwbmV0VXNlcnMiLCJuYmYiOjE1NzUxMDk1NzQsImV4cCI6MTU3NzcwMTU3NCwiaXNzIjoibG9jYWxob3N0IiwiYXVkIjoibG9jYWxvaG9zdCJ9.2nclxbGXg4E49VzWyTIJWZahKFf7zpszxzwt2eTsaGw";
          //  Application.Current.Properties.Add("token1", token1);
            await this.Navigation.PushModalAsync(new NavigationPage(new MenuPage()));
            this.IsEnabled = true;
        }
        private  void ExitButton_Clicked(object sender, EventArgs e)
        {
            if (Device.OS == TargetPlatform.Android)
            {
                DependencyService.Get<IAndroidMethods>().CloseApp();
            }
            else if (Device.OS == TargetPlatform.iOS)
            {
                DependencyService.Get<IIosMethods>().CloseApp();
            }
        }
        protected override bool OnBackButtonPressed()
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
}