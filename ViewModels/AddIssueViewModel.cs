using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ViewModels
{
    public class AddIssueViewModel : INotifyPropertyChanged
    {
        private Issues issues { get; set; }
        private IssueListViewModel issueListViewModel { get; set; }
       
        public AddIssueViewModel()
        {
           
            issues = new Issues();

        }
        public AddIssueViewModel(Issues issues)
        {
            issues = issues;
        }

        private decimal issueId;
        public decimal IssueId
        {
            get { return issueId; }
            set { issueId=value;
                 OnPropertyChanged("IssueId");}
        }
        private Color statusColor;
        public Color StatusColor { get { return statusColor; }
            set { statusColor = value; OnPropertyChanged("StatusColor"); } }
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

        private List<Attachments> attachmentsView;

        public List<Attachments> AttachmentsView
        {
            get { return attachmentsView; }
            set { attachmentsView = value; OnPropertyChanged("AttachmentsView"); }
        }
        private List<Comments> comments;

        public List<Comments> Comments
        {
            get { return comments; }
            set { comments = value; OnPropertyChanged("Comments"); }
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
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
