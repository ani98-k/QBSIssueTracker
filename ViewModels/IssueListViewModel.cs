using QBSIssueTrackerAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ViewModels
{
    public class IssueListViewModel: INotifyPropertyChanged
    {
        private readonly IssuesAPI _issuesAPI;
        private ObservableCollection<AddIssueViewModel> _issues;
        public ObservableCollection<AddIssueViewModel> Issues
        { get { return _issues; } set { _issues = value; OnPropertyChanged("Issues"); } }

        public Color StatusColor { get; set; }
        public ICommand SearchCommand { get; private set; }
        private string entryContext = " ";

        public event PropertyChangedEventHandler PropertyChanged;

        public string EntryContext
        {
            get { return entryContext; }
            set { entryContext = value; OnPropertyChanged("EntryContext"); }
        }
        public  IssueListViewModel()
        {
            if (Issues==null)
            {
                Issues = new ObservableCollection<AddIssueViewModel>();
            }

            Task.Run(async () => 
            {
                try
                {
                    var issues = new List<Models.Issues>();
                    issues.Add(new Models.Issues { IssueId = 7, IssuesTitle = "asdf", IssuesStatusesTitle = "Open" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "In progress" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Invalid" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "In progress" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Close" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Open" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Close" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "In progress" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Close" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Open" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Open" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Solved" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Close" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Close" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Close" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Close" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Close" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Close" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Close" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Close" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Close" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Close" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Close" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Close" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Close" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Close" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Close" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Close" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Close" });
                    issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Close" });
                    //var issues = await _issuesAPI
                    //.GetIssues(Application.Current.Properties["token"].ToString());
                    foreach (var issue in issues)
                    {
                        var i = new AddIssueViewModel
                        {
                            IssueId = issue.IssueId,
                            //IssuesCategoriesId = issue.IssuesCategoriesId,
                            //IssuesDescription = issue.IssuesDescription,
                            //IssuesExpectedBehavior = issue.IssuesExpectedBehavior,
                            //IssuesPriorityId = issue.IssuesPriorityId,
                            //IssuesProjectsId = issue.IssuesProjectsId,
                            //IssuesSeverityId = issue.IssuesSeverityId,
                            //AttachmentsView = issue.AttachmentsView,
                            //Comments = issue.Comments,
                            //IssuesStatusesId = issue.IssuesStatusesId,
                            IssuesStatusesTitle = issue.IssuesStatusesTitle,
                            IssuesTitle = issue.IssuesTitle
                        };
                        i.StatusColor = IssueStatusColor(i.IssuesStatusesTitle);
                        Issues.Add(i);
                    }

                }
                catch (Exception)
                {

                    
                }
            });

            SearchCommand = new Command(async () =>
            {
                    try
                    {
                        if (TokenAPI.CheckTokenValidation(Application.Current.Properties["token"].ToString()))
                        {
                            Issues.Clear();
                        //var issues = await _issuesAPI
                        //.SearchIssues(Application.Current.Properties["token"].ToString(), EntryContext);
                        var issues = new List<Models.Issues>();
                        issues.Add(new Models.Issues { IssuesTitle = "asdf3", IssuesStatusesTitle = "Invalid" });
                        issues.Add(new Models.Issues { IssuesTitle = "asdf3", IssuesStatusesTitle = "In progress" });
                        issues.Add(new Models.Issues { IssuesTitle = "a2", IssuesStatusesTitle = "Close" });
                        issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Open" });
                        issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Close" });
                        issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "In progress" });
                        issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Close" });
                        foreach (var issue in issues)
                            {
                                var i = new AddIssueViewModel
                                {
                                    IssueId = issue.IssueId,
                                    //IssuesCategoriesId = issue.IssuesCategoriesId,
                                    //IssuesDescription = issue.IssuesDescription,
                                    //IssuesExpectedBehavior = issue.IssuesExpectedBehavior,
                                    //IssuesPriorityId = issue.IssuesPriorityId,
                                    //IssuesProjectsId = issue.IssuesProjectsId,
                                    //IssuesSeverityId = issue.IssuesSeverityId,
                                    //AttachmentsView = issue.AttachmentsView,
                                    //Comments = issue.Comments,
                                    //IssuesStatusesId = issue.IssuesStatusesId,
                                    IssuesStatusesTitle = issue.IssuesStatusesTitle,
                                    IssuesTitle = issue.IssuesTitle
                                };
                                i.StatusColor = IssueStatusColor(i.IssuesStatusesTitle);
                                Issues.Add(i);

                            }
                        }
                    }
                    catch (Exception)
                    {

                       
                    }              
            });
        }
        public Color IssueStatusColor(string status)
        {
            switch (status)
            {
                case "Open":
                    return Color.FromHex("#45E560");
                case "In progress":
                    return Color.FromHex("#E5CD45");
                case "Solved":
                    return Color.FromHex("#45CBE5");
                case "Closed":
                    return Color.FromHex("#456DE5");
                case "Invalid":
                    return Color.FromHex("#808080");
                default:
                   return Color.Aqua;
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

    }
}
