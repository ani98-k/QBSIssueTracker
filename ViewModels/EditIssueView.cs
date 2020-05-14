using Microsoft.AspNetCore.Http;
using Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using QBSIssueTrackerAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ViewModels
{
    

    public class EditIssueView :INotifyPropertyChanged
    {
        private readonly IssuesAPI _issuesAPI;
        private readonly CommentsAPI _commentsAPI;
        private HttpClientHandler _hndlr;
        protected HttpClient _httpClient;
        public Page MainPage;
        protected string _baseUrl = "https://localhost:44341/api/";
        
        public EditIssueView()
        {
            

            _issuesAPI = new IssuesAPI();
            _commentsAPI = new CommentsAPI();
            _hndlr = new HttpClientHandler();
            _hndlr.UseDefaultCredentials = true;

            _httpClient = new HttpClient(_hndlr);
            IssueIdChanged += EditIssueView_IssueIdChanged;
            CancelCommand = new Command(CancelBtnCommand);
            SaveCommand = new Command(SaveBtnCommand);
            CommentsCommentPropChanged += EditIssueView_CommentsCommentPropChanged;
            PanAndPancilTapped = new TapGestureRecognizer();
            PanAndPancilTapped.Tapped += PanAndPancilTapped_Tapped;
            PlusGestureRecognizer = new TapGestureRecognizer();
            PlusGestureRecognizer.Tapped += OnPlusIconTapped;
            AttachmentsImages = new System.Collections.ObjectModel.ObservableCollection<MediaFile>();
            Attachments = new System.Collections.ObjectModel.ObservableCollection<AttachmentsViewModel>();
        }

        private async void PanAndPancilTapped_Tapped(object sender, EventArgs e)
        {
            
        }

        public async void CancelBtnCommand(object view)
        {
            StackLayout mainView = view as StackLayout;
            
            mainView.Children.Clear();
            

        }
        public async void SaveBtnCommand(object page)
        {
            var pg = page as ContentPage;
            var comments = new List<Comments>();
            
            comments.Add(new Models.Comments
            {
                CommentedDate = DateTime.Now,
               // CommenterUserId = Guid.Parse("0"),
               // CommenterUserName = Application.Current.Properties["Username"].ToString(),
                CommentsComment = this.CommentsComment
            });
          //  var commentAdded = false;
            try
            {
                var commentAdded = await _issuesAPI.EditIssue(IssueId, comments.ToArray(), Application.Current.Properties["token"].ToString());
                if (commentAdded)
                {
                    this.Comments.Add(comments[0]);
                }
                else
                {

                    await pg.DisplayAlert("Comment", "Your comment can't be added try again later", "Ok");
                    // 
                }
                foreach (var item in AttachmentsImages)
                {
                    var issueImageSend = await _issuesAPI.SentAttanchments(item, IssueId, Application.Current.Properties["token"].ToString());
                    if (!issueImageSend)
                    {
                      await  pg.DisplayAlert("Image",$"Image can't be added {System.IO.Path.GetFileName(item.Path)}","Ok");
                    }
                }
            }
            catch (System.Net.Http.HttpRequestException ex)
            {

                await pg.DisplayAlert("Internet", "Chack your internet connection", "Ok");
            }
            catch (Exception ex)
            {
                await pg.DisplayAlert("Exeption", ex.Message, "Ok");
            }
           
            
        }
        public async void EditIssueView_CommentsCommentPropChanged(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        public TapGestureRecognizer PlusGestureRecognizer;
        private async void OnPlusIconTapped(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            var mediaOption = new PickMediaOptions() { PhotoSize = PhotoSize.Small };
            var selectedImage = await CrossMedia.Current.PickPhotosAsync(mediaOption);
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync<StoragePermission>();
           
            if (storageStatus == PermissionStatus.Granted && selectedImage != null)
            {

               
                Attachments.Clear();
                for (int i = 0; i < selectedImage.Count; i++)
                {
                   
                    Attachments.Add(new AttachmentsViewModel
                    {
                        
                        AttachmentsLink = System.IO.Path.GetFileName(selectedImage.ElementAt(i).Path),
                        AttachmentImage = new Image
                        {
                            Source =
                         ImageSource.FromStream(() => selectedImage.ElementAt(i).GetStream())
                        },
                        
                       // AttachmentsUsername ="By: "+Application.Current.Properties["UserName"].ToString(),
                        AttachmentsUsername ="By: "+"Qbs.support",
                        AttachmentsDate=DateTime.Now.ToString(),
                        FullUrl1= selectedImage.ElementAt(i).Path
                        
                    });
                    AttachmentsImages.Add(selectedImage.ElementAt(i));
                 //  var issueSend=await _issuesAPI.SentAttanchments(selectedImage.ElementAt(1), IssueId, Application.Current.Properties["token"].ToString());
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
        private async void EditIssueView_IssueIdChanged(object sender, EventArgs e)
        {
            try
            {
                var issue = await _issuesAPI.GetIssues(Application.Current.Properties["token"].ToString(),this.IssueId);
                ChangeThisProps(issue);
                var comments = await _commentsAPI.GetComments(Application.Current.Properties["token"].ToString(), this.IssueId);
                foreach (var comment in comments)
                {
                    Comments.Add(new Models.Comments
                    {   CommentedDate = comment.CommentedDate,
                        CommenterUserId=comment.CommenterUserId,
                        CommenterUserName=comment.CommenterUserName,
                        CommentsComment=comment.CommentsComment,
                    });
                }
                var attachments = new List<Attachments>();
                Task attachmentsTask = GetAllAttacments(issue.AttachmentsView);
              
                await Task.WhenAll(attachmentsTask);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        private async Task GetAllAttacments(List<Models.Attachments> attachments)
        {
            foreach (var item in attachments)
            {
                var atachmentsView = new AttachmentsViewModel
                {
                    AttachmentsLink = item.AttachmentsLink,
                    AttachmentsUsername = item.AttachmentsUsername,
                    AttachmentsDate=item.AttachmentsDate.Value.ToString()
                    
                    // IssueImage = await _issuesAPI.GetAttachments(Application.Current.Properties["token"].ToString(), item.AttachmentsLink)
                };
                //atachmentsView.AttachmentImage = new Xamarin.Forms.Image
                //{
                //    Source = ImageSource.FromUri(new Uri(_baseUrl + $"getAttachments?attacmentUrl={item.AttachmentsLink}"))
                //};
                atachmentsView.FullUrl1 = _baseUrl + $"getAttachments?attacmentUrl={item.AttachmentsLink}";
                Attachments.Add(atachmentsView) ;
            }
        }

        private decimal issueId;
        public decimal IssueId
        {
            get { return issueId; }
            set
            {
                if (issueId!=value)
                {
                    issueId = value;
                    OnPropertyChanged("IssueId");
                 //   IssueIdChanged?.Invoke(this, new EventArgs());
                }
                

            }
        }
        private Color statusColor;
        public Color StatusColor
        {
            get { return statusColor; }
            set { statusColor = value; OnPropertyChanged("StatusColor"); }
        }
        private decimal issuesCategoriesId;

        public decimal IssuesCategoriesId
        {
            get { return issuesCategoriesId; }
            set { issuesCategoriesId = value; OnPropertyChanged("IssuesCategoriesId"); }
        }
        private decimal issuesProjectsId;

        public decimal IssuesProjectsId
        {
            get { return issuesProjectsId; }
            set { issuesProjectsId = value; OnPropertyChanged("IssuesProjectId"); }
        }
        private decimal issuesStatusesId;

        public decimal IssuesStatusesId
        {
            get { return issuesStatusesId; }
            set { issuesStatusesId = value; OnPropertyChanged("IssuesStatusesId"); }
        }
        private decimal? issuesSeverityId;

        public decimal? IssuesSeverityId
        {
            get { return issuesSeverityId; }
            set { issuesSeverityId = value; OnPropertyChanged("IssuesSeverityId"); }
        }
        private decimal? issuesPriorityId;

        public decimal? IssuesPriorityId
        {
            get { return issuesPriorityId; }
            set { issuesPriorityId = value; OnPropertyChanged("IssuesPriorityId"); }
        }
        private string issuesTitle;

        public string IssuesTitle
        {
            get { return issuesTitle; }
            set { issuesTitle = value; OnPropertyChanged("IssuesTitleId"); }
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
        private string issuesCreatedBy;

        public string IssuesCreatedBy
        {
            get { return issuesCreatedBy; }
            set { issuesCreatedBy = value;
                  OnPropertyChanged(nameof(IssuesCreatedBy));
            }
        }
        private DateTime issuesCreatedDate;

        public DateTime IssuesCreatedDate
        {
            get { return issuesCreatedDate; }
            set { issuesCreatedDate = value;
                OnPropertyChanged("IssuesCreatedDate");
            }
        }

        private string issuesLastModifiedBy;

        public string IssuesLastModifiedBy
        {
            get { return issuesLastModifiedBy; }
            set { issuesLastModifiedBy = value;
                OnPropertyChanged("IssuesLastModifiedBy");
            }
        }
        private DateTime? issuesLastModifiedDate;

        public DateTime? IssuesLastModifiedDate
        {
            get { return issuesLastModifiedDate; }
            set { issuesLastModifiedDate = value; }
        }

        //private List<Attachments> attachmentsView;

        //public List<Attachments> AttachmentsView
        //{
        //    get { return attachmentsView; }
        //    set { attachmentsView = value; OnPropertyChanged("AttachmentsView"); }
        //}
        public System.Collections.ObjectModel.ObservableCollection<AttachmentsViewModel> Attachments { get; set; }
        public System.Collections.ObjectModel.ObservableCollection<MediaFile> AttachmentsImages { get; set; }
        //private List<Comments> comments;

        //public List<Comments> Comments
        //{
        //    get { return comments; }
        //    set { comments = value; OnPropertyChanged("Comments"); }
        //}
        public System.Collections.ObjectModel.ObservableCollection<Comments> Comments { get; set; }
        private string commentsComment;

        public string CommentsComment
        {
            get { return commentsComment; }
            set {
                if (commentsComment!=value)
                {
                    commentsComment = value;
                   // CommentsCommentPropChanged?.Invoke(this, new EventArgs());
                    OnPropertyChanged("CommentsComment");
                }

            }
        }


        private string issueCategoriesTitle;
        public string IssueCategoriesTitle
        {
            get { return issueCategoriesTitle; }
            set { issueCategoriesTitle = value; OnPropertyChanged(nameof(IssueCategoriesTitle)); }
        }
        private string issuesPriorityTitle;

        public string IssuesPriorityTitle
        {
            get { return issuesPriorityTitle; }
            set { issuesPriorityTitle = value; OnPropertyChanged("IssuesPriorityTitle"); }
        }
        private string issuesProjectsTitle;

        public string IssuesProjectsTitle
        {
            get { return issuesProjectsTitle; }
            set { issuesProjectsTitle = value; OnPropertyChanged("IssuesProjectsTitle"); }
        }
        private bool? issuesProjectsIsActive;

        public bool? IssuesProjectsIsActive
        {
            get { return issuesProjectsIsActive; }
            set { issuesProjectsIsActive = value; OnPropertyChanged("IssuesProjectsIsActive"); }
        }
        private string issuesSeverityTitle;

        public string IssuesSeverityTitle
        {
            get { return issuesSeverityTitle; }
            set { issuesSeverityTitle = value; OnPropertyChanged("IssuesSeverityTitle"); }
        }
        private string issuesStatusesTitle;

        public string IssuesStatusesTitle
        {
            get { return issuesStatusesTitle; }
            set { issuesStatusesTitle = value; OnPropertyChanged("IssuesStatusesTitle"); }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public System.Windows.Input.ICommand CancelCommand { get; private set; }
        public System.Windows.Input.ICommand SaveCommand { get; private set; }
        public TapGestureRecognizer PanAndPancilTapped;
        public event EventHandler CommentsCommentPropChanged;
        public event EventHandler IssueIdChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        public void ChangeThisProps(Issues issues)
        {
            this.IssuesCategoriesId = issues.IssuesCategoriesId;
            IssuesStatusesId = issues.IssuesStatusesId;
            IssuesCreatedBy = issues.IssuesCreatedBy;
            IssuesCreatedDate = issues.IssuesCreatedDate;
            IssuesLastModifiedBy = issues.IssuesLastModifiedBy;
            IssuesLastModifiedDate = issues.IssuesLastModifiedDate;


            IssuesDescription = issues.IssuesDescription;
            IssuesExpectedBehavior = issues.IssuesExpectedBehavior;
            IssuesPriorityId = issues.IssuesPriorityId;
            IssuesProjectsId = issues.IssuesProjectsId;
            IssuesSeverityId = issues.IssuesSeverityId;
            IssuesTitle = issues.IssuesTitle;
            IssueCategoriesTitle = issues.IssueCategoriesTitle;

            IssuesProjectsIsActive = issues.IssuesProjectsIsActive;
            IssuesProjectsTitle = issues.IssuesProjectsTitle;

            IssuesStatusesTitle = issues.IssuesStatusesTitle;
           
            IssuesSeverityTitle = issues.IssuesSeverityTitle;
           
            IssuesPriorityTitle = issues.IssuesPriorityTitle;
          
        }
    }

}
            
           
          
            
           
