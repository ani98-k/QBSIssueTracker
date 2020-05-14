using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ViewModels
{
    public class AddIssueView: System.ComponentModel.INotifyPropertyChanged
    {
        public Page MainPage;
        public Xamarin.Forms.Frame XamlAttachmentsFrm { get; set; }
        private QBSIssueTrackerAPI.IssuesAPI _issuesAPI;
        public TapGestureRecognizer AttachmentsTapGesture { get; set; }
        public System.Collections.ObjectModel.ObservableCollection<string> ProjectsTitles { get; set; }
        public System.Collections.ObjectModel.ObservableCollection<ProjectsView> Projects { get; set; }
        public System.Collections.ObjectModel.ObservableCollection<string> CategoriesTitle { get; set; }
        public System.Collections.ObjectModel.ObservableCollection<CategoriesView> Categories { get; set; }
        public System.Collections.ObjectModel.ObservableCollection<SeverityView> Severities { get; set; }
        public System.Collections.ObjectModel.ObservableCollection<string> SeveritiesTitle { get; set; }
        public List<Plugin.Media.Abstractions.MediaFile> AttachmentsImages { get; set; }

        public System.Windows.Input.ICommand AddButtonCommand { get; private set; }

        public System.Windows.Input.ICommand CancelButtonCommand;

        private System.Collections.ObjectModel.ObservableCollection<AttachmentsViewModel> attachments;
        public System.Collections.ObjectModel.ObservableCollection<AttachmentsViewModel> Attachments
        {
            get { return attachments; }
            set { attachments = value; OnPropertyChanged("Attachments");}
        }

        private string projectTitle;
        public string ProjectTitle
        {
            get { return projectTitle; }
            set { projectTitle = value; OnPropertyChanged("ProjectTitle"); ProjectsTitles.Add(projectTitle); }
        }
        private string categoryTitle;

        public string CategoryTitle
        {
            get { return categoryTitle; }
            set { categoryTitle = value; OnPropertyChanged("CategoriesTitle"); CategoriesTitle.Add(categoryTitle); }
        }
        private string severityTitle;

        public string SeverityTitle
        {
            get { return severityTitle; }
            set { severityTitle = value; OnPropertyChanged("SeverityTitle"); SeveritiesTitle.Add(severityTitle); }
        }

        private string issuesTitle;
        public string IssuesTitle
        {
            get { return issuesTitle; }
            set { issuesTitle = value; OnPropertyChanged("IssuesTitle"); }
        }
        private string issuesDescription;
        public string IssuesDescription
        {
            get { return issuesDescription; }
            set { issuesDescription = value; OnPropertyChanged("IssuesDesctiption"); }
        }
        private string issuesExpectedBehavior;
        public string IssuesExpectedBehavior
        {
            get { return issuesExpectedBehavior; }
            set { issuesExpectedBehavior = value; OnPropertyChanged("IssuesExpectedBehavior"); }
        }
        private string commentsComment;

        public string CommentsComment
        {
            get { return commentsComment; }
            set { commentsComment = value; OnPropertyChanged(propName: "CommentsComment"); }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        public AddIssueView()
        {
            _issuesAPI = new QBSIssueTrackerAPI.IssuesAPI();
            ProjectsTitles = new System.Collections.ObjectModel.ObservableCollection<string>();
            CategoriesTitle = new System.Collections.ObjectModel.ObservableCollection<string>();
            SeveritiesTitle = new System.Collections.ObjectModel.ObservableCollection<string>();
            Projects = new System.Collections.ObjectModel.ObservableCollection<ProjectsView>();
            Categories = new System.Collections.ObjectModel.ObservableCollection<CategoriesView>();
            Severities = new System.Collections.ObjectModel.ObservableCollection<SeverityView>();
            Attachments = new System.Collections.ObjectModel.ObservableCollection<AttachmentsViewModel>();
            AttachmentsTapGesture = new TapGestureRecognizer();
            AddButtonCommand = new Command(OnAddButtonTapped);
            CancelButtonCommand = new Command(OnCancelButtonTapped);
            AttachmentsTapGesture.Tapped += AttachmentsTapGesture_Tapped;
            System.Threading.Tasks.Task.Run(async () =>
            {
                await SetProjects();
                await SetCategories();
                await SetSeverities();
            });
        }

        private void OnCancelButtonTapped(object obj)
        {
            var mainComtent = obj as StackLayout;
            MainPage.IsEnabled = false;
            mainComtent.Children.Clear();
           
            MainPage.IsEnabled = true;
        }

        private async void OnAddButtonTapped(object obj)
        {
            try
            {
                var issue = new Models.Issues
                {
                    AttachmentsView = new List<Models.Attachments>(),

                    IssueCategoriesTitle = this.CategoryTitle,
                    IssuesCategoriesId = GetIssueCategoryId(this.CategoryTitle),
                    IssuesProjectsTitle = this.ProjectTitle,
                    IssuesProjectsId = GetIssueProjectId(this.ProjectTitle),
                    IssuesSeverityTitle = this.SeverityTitle,
                    IssuesSeverityId = GetIssueSeverityId(this.SeverityTitle),
                    IssuesCreatedBy = Application.Current.Properties["Username"].ToString(),
                    IssuesCreatedDate = DateTime.UtcNow,
                    IssuesDescription = this.IssuesDescription,
                    IssuesExpectedBehavior = this.IssuesExpectedBehavior,
                    IssuesTitle = this.IssuesTitle,
                    IssuesPriorityTitle = " ",
                    IssuesStatusesTitle = " ",
                    IssuesLastModifiedBy = Application.Current.Properties["Username"].ToString(),
                    IssuesLastModifiedDate = DateTime.UtcNow,
                    IssuesProjectsIsActive = true,
                    IssuesStatusesId = 2
                };
                if (CommentsComment!=null || CommentsComment.Length!=0)
                {
                    var comments = new List<Models.Comments>
                    { new Models.Comments
                        {
                            CommentedDate =DateTime.UtcNow,
                            CommentsComment=this.CommentsComment,
                            CommenterUserId=new Guid(),
                            CommenterUserName=Application.Current.Properties["Username"].ToString()
                        }
                    };
                    issue.Comments = comments;
                }
                decimal issueId= await _issuesAPI.AddIssue(Xamarin.Forms.Application.Current.Properties["token"].ToString(),issue);
                if (AttachmentsImages!=null || AttachmentsImages.Count!=0)
                {
                    foreach (var item in AttachmentsImages)
                    {
                        await SentAttachments(issueId, item);

                    }
                }

            }
            catch(NullReferenceException ex)
            {
                await MainPage.DisplayAlert(" ", "You need to fill all necessary fields", "Ok");
            }
            catch (Exception)
            {

                await MainPage.DisplayAlert(" ", "Can't Add Issue", "Ok");
            }
        }

        private async System.Threading.Tasks.Task SentAttachments(decimal issueId, Plugin.Media.Abstractions.MediaFile item)
        {
            try
            {
                await _issuesAPI.SentAttanchments(item, issueId, Application.Current.Properties["token"].ToString());
            }
            catch (Exception ex)
            {

               await MainPage.DisplayAlert(" ","Can't send "+ System.IO.Path.GetFileName(item.Path),"Ok");
            }
        }

        private decimal GetIssueProjectId(string title)
        {
            var project = Projects.FirstOrDefault(x => x.ProjectsTitle.Equals(title));
            return project.Id;
        }
        private decimal GetIssueCategoryId(string title)
        {
            var project = Categories.FirstOrDefault(x => x.CategoriesTitle.Equals(title));
            return project.Id;
        }
        private decimal GetIssueSeverityId(string title)
        {
            var project = Severities.FirstOrDefault(x => x.SeverityTitle.Equals(title));
            return project.Id;
        }

        public async void AttachmentsTapGesture_Tapped(object sender, EventArgs e)
        {
            
            XamlAttachmentsFrm.IsVisible = true;
            await Plugin.Media.CrossMedia.Current.Initialize();
            var mediaOption = new Plugin.Media.Abstractions.PickMediaOptions()
            { PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small };
            var selectedImage = await Plugin.Media.CrossMedia.Current.PickPhotosAsync(mediaOption);
            var storageStatus = await Plugin
                .Permissions.CrossPermissions.Current
                    .CheckPermissionStatusAsync<Plugin.Permissions.StoragePermission>();
            
            if (storageStatus == Plugin.Permissions.Abstractions.PermissionStatus.Granted && selectedImage != null)
            {
                if (AttachmentsImages==null)
                {
                    AttachmentsImages = selectedImage;
                }
                else
                {
                    AttachmentsImages.AddRange(selectedImage);
                }
                foreach (var item in selectedImage)
                {
                    Attachments.Add(new AttachmentsViewModel
                    {
                        AttachmentsDate=DateTime.UtcNow.ToString(),
                        AttachmentsLink = System.IO.Path.GetFileName(item.Path),
                        // AttachmentsUsername=Application.Current.Properties["UserName"].ToString(),
                        AttachmentsUsername="Qbs.support",
                        FullUrl1=item.Path
                    });
                }
            }
        }

        private async System.Threading.Tasks.Task SetProjects()
        {
            try
            {
              var projects= await _issuesAPI
                        .GetProjectsAsync(Xamarin.Forms.Application.Current.Properties["token"].ToString());
                foreach (var project in projects)
                {   
                    if (project.ProjectsIsActive==true)
                    {
                        ProjectTitle = project.ProjectsTitle;
                        Projects.Add(new ProjectsView
                        {
                            Id=project.Id,
                            ProjectsTitle=project.ProjectsTitle,
                            ProjectsIsActive=project.ProjectsIsActive
                        });
                    }
                }
            }
            catch (System.Net.Http.HttpRequestException ex)
            {

              //  await MainPage.DisplayAlert("Internet", "Chack your internet connection", "Ok");
            }
            catch (Exception ex)
            {

              //  await MainPage.DisplayAlert("Exeption",ex.Message+"/n  "+Convert.ToString(ex.Data),"Ok");
            }
        }
        private async System.Threading.Tasks.Task SetCategories()
        {
            try
            {
                var categories = await _issuesAPI
                    .GetCategoriesAsync(Xamarin.Forms.Application.Current.Properties["token"].ToString());
                foreach (var category in categories)
                {
                    CategoryTitle = category.CategoriesTitle;
                    Categories.Add(new CategoriesView
                    {
                        CategoriesTitle = category.CategoriesTitle,
                        Id=category.Id
                    });
                }
            }
            catch (System.Net.Http.HttpRequestException ex)
            {

              //  await MainPage.DisplayAlert("Internet", "Chack your internet connection", "Ok");
            }
            catch (Exception ex)
            {

               // await MainPage.DisplayAlert("Exeption", ex.Message + "/n  " + Convert.ToString(ex.Data), "Ok");
            }
        }
        private async System.Threading.Tasks.Task SetSeverities()
        {
            try
            {
                var severities = await _issuesAPI
                    .GetSeveritiesAsync(Xamarin.Forms.Application.Current.Properties["token"].ToString());
                foreach (var item in severities)
                {
                    SeverityTitle = item.SeverityTitle;
                    Severities.Add(new SeverityView
                    {
                        Id=item.Id,
                        SeverityTitle=item.SeverityTitle
                    });
                }
            }
            catch (System.Net.Http.HttpRequestException ex)
            {

               // await MainPage.DisplayAlert("Internet", "Chack your internet connection", "Ok");
            }
            catch (Exception ex)
            {

               // await MainPage.DisplayAlert("Exeption", ex.Message + "/n  " + Convert.ToString(ex.Data), "Ok");
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propName));
        }
    }
}
