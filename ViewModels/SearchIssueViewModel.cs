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
    public class SearchIssueViewModel: INotifyPropertyChanged
    {
        private readonly IssuesAPI _issuesAPI;
        private readonly TokenAPI _tokenAPI;

        public event PropertyChangedEventHandler PropertyChanged;
        public Color StatusColor { get; set; }
        public ObservableCollection<AddIssueViewModel> Issues { get; set; }
        private string entryContext=" ";

        public string EntryContext
        {
            get { return entryContext; }
            set { entryContext = value; OnPropertyChanged("EntryContext"); }
        }


        public ICommand SearchCommand { get; private set; }
        public SearchIssueViewModel()
        {
            Issues = new ObservableCollection<AddIssueViewModel>();  
            SearchCommand = new Command(async (parameter) =>
            {
                try
                {
                    //  TokenAPI.CheckTokenValidation(Application.Current.Properties["token"].ToString())
                    if (true)
                    {
                        //var issues = await _issuesAPI
                        //.SearchIssues(Application.Current.Properties["token"].ToString(), entryContext);
                        var issues = new List<Models.Issues>();
                        issues.Add(new Models.Issues { IssuesTitle = "asdf3", IssuesStatusesTitle = "Invalid" });
                        issues.Add(new Models.Issues { IssuesTitle = "asdf3", IssuesStatusesTitle = "In progress" });
                        issues.Add(new Models.Issues { IssuesTitle = "a2", IssuesStatusesTitle = "Close" });
                        issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Open" });
                        issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Close" });
                        issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "In progress" });
                        issues.Add(new Models.Issues { IssuesTitle = "asdf2", IssuesStatusesTitle = "Close" });
                        var listView = parameter as ListView;
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
                        listView.ItemsSource = Issues;
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
