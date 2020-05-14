using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QBSIssueTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditIssueView : ContentView
    {
        private Page page;
        public string issueNumber;
        public static AddIssueViewModel Issue { get; set; }
        public Boolean CanEdit { get; set; }
        private StackLayout _mainContent;
        public EditIssueView()
        {
            InitializeComponent();
            this.ClassId = "EditIssueView";
            issueNumber = "Issue #165161";
            IssueNumberLbl.Text = issueNumber;

        }
        public EditIssueView(AddIssueViewModel issueView,StackLayout mainLayout)
        {
            
            //Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            InitializeComponent();
            
            this.ClassId = "EditIssueView";
            //issueNumber = "Issue #165161";
            //IssueNumberLbl.Text = issueNumber;
            Issue = issueView;
           
            view.IssueId = Issue.IssueId;
            commentEditor.Completed += view.EditIssueView_CommentsCommentPropChanged;
            PlusIconGrd.GestureRecognizers.Add(view.PlusGestureRecognizer);
            SaveBtn.CommandParameter = MenuPageDetail.MenuPageDetailStatic;
            view.MainPage = MenuPageDetail.MenuPageDetailStatic;

            _mainContent = mainLayout;
          
        }

        private async void CalendarGrd_Tapped(object sender, EventArgs e)
        {
            MainStackLayout.IsEnabled = false;
            MainSaveCancleGrd.IsEnabled = false;
            EditIssueViewScroll.IsEnabled = false;
            
            calendarPopUp.IsVisible = true;
            calendarPopUp.IsEnabled = true;
           
            TapGestureRecognizer mainLayout_Tapped = new TapGestureRecognizer();
            mainLayout_Tapped.Tapped += (s, e1) =>
            {
                
                calendarPopUp.IsVisible = false;
                calendarPopUp.IsEnabled = false;
                EditIssueViewScroll.IsEnabled = true;
                MainSaveCancleGrd.IsEnabled = true;
                MainStackLayout.IsEnabled = true;
              
                MainGridLayout.GestureRecognizers.Clear();
              
            };


           
            MainGridLayout.GestureRecognizers.Add(mainLayout_Tapped);
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
           await CrossMedia.Current.Initialize();
           var mediaOption = new PickMediaOptions() { PhotoSize=PhotoSize.Small };
            var selectedImage = await CrossMedia.Current.PickPhotosAsync(mediaOption);
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync<StoragePermission>();

            if (storageStatus == PermissionStatus.Granted && selectedImage!=null)
            {

                for (int i = 0; i < selectedImage.Count; i++)
                {
                    //AttachmentsImgLayer
                    //    .Children
                    //    .Add
                    //    (new Image
                    //    {
                    //        Source =
                    //    ImageSource.FromStream(() => selectedImage.ElementAt(i).GetStream())
                    //    });
                }
            }
            else
            {

            }

        }

        private async void CalendarPopUpSaveButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var _issueAPI = repView.GetIssuesAPI();
                CanEdit = await _issueAPI.EditIssueBySupport(view.IssueId,
                    new Models.Issues
                    {
                        IssueId=view.IssueId,
                        IssuesTitle = view.IssuesTitle,
                        IssuesProjectsId = view.IssuesProjectsId,
                        IssuesPriorityId = view.IssuesPriorityId,
                        IssuesSeverityId = repView.GetIssueSeverityId(SeverityPicker.Title),
                        IssuesDescription = view.IssuesDescription,
                        IssuesExpectedBehavior = view.IssuesExpectedBehavior,
                        IssuesStatusesId = repView.GetIssueStatusId(StatusesPicker.Title),
                        IssuesCategoriesId=repView.GetIssueCategoryId(CategoryPicker.Title)
                    }, Application.Current.Properties["token"].ToString());
            }
            catch (Exception)
            {

                CanEdit = false;
            }
        }

        private void CalendarPopUpCancelButton_Clicked(object sender, EventArgs e)
        {
            calendarPopUp.IsEnabled = false;
            calendarPopUp.IsVisible = false;
            EditIssueViewScroll.IsEnabled = true;
            MainSaveCancleGrd.IsEnabled = true;
            MainStackLayout.IsEnabled = true;

            MainGridLayout.GestureRecognizers.Clear();
        }

        private void CancelBtn_Clicked(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            MenuPageDetail.MenuPageDetailStatic.IsEnabled = false;
            _mainContent.Children.Clear();
            _mainContent.Children.Add(new MainView(_mainContent));
            this.IsEnabled = true;
            MenuPageDetail.MenuPageDetailStatic.IsEnabled = true;
        }
    }
}