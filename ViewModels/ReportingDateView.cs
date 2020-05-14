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
    public class ReportingDateView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IssuesAPI _issuesAPI;
     //   public ObservableCollection<ProjectsView> Projects { get; set; }
        public ObservableCollection<StatusesView> Statuses { get; set; }
        public ObservableCollection<string> StatusesTitle { get; set; }
        public ObservableCollection<SeverityView> Severity { get; set; }
        public ObservableCollection<string> SeverityTitle { get; set; }
        public ObservableCollection<CategoriesView> Categories { get; set; }
        public ObservableCollection<string> CategoriesTitle { get; set; }
        public event EventHandler OnSaveButtonClicked;
        private Boolean? isAccessedTo;
        public IssuesAPI GetIssuesAPI()
        {
            return _issuesAPI;
        }
        public Boolean? IsAccessedTo
        {
            get { return isAccessedTo; }
            set
            {
                if (isAccessedTo!=value)
                {
                    isAccessedTo = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("IsAccessedTo"));
                }
            }
        }
       public decimal GetIssueStatusId(string title)
       {
            
            foreach (var item in Statuses)
            {
                if (item.StatusesTitle.Equals(title))
                {
                    return item.Id;
                }
                else { return 0; }
            }
            return 0;
       }
       public decimal GetIssueSeverityId(string title)
       {
            
            foreach (var item in Severity)
            {
                if (item.SeverityTitle.Equals(title))
                {
                    return item.Id;
                }
                else { return 0; }
            }
            return 0;
       }
       public decimal GetIssueCategoryId(string title)
       {
            
            foreach (var item in Categories)
            {
                if (item.CategoriesTitle.Equals(title))
                {
                    return item.Id;
                }
                else { return 0; }
            }
            return 0;
       }

        public ReportingDateView()
        {
            _issuesAPI = new IssuesAPI();
            OnSaveButtonClicked += ReportingDateView_OnSaveButtonClicked;
            Statuses = new ObservableCollection<StatusesView>();
            StatusesTitle = new ObservableCollection<string>();
            StatusesTitle.Add("In progress");
            StatusesTitle.Add("In progress");
            StatusesTitle.Add("In progress");
            StatusesTitle.Add("In progress");
            StatusesTitle.Add("In progress");
            Statuses.Add(new StatusesView { Id = 1, StatusesTitle = "InProgress" });
            Statuses.Add(new StatusesView { Id = 1, StatusesTitle = "InProgess" });
            Statuses.Add(new StatusesView { Id = 1, StatusesTitle = "ress" });
            Statuses.Add(new StatusesView { Id = 1, StatusesTitle = "In" });
            Severity = new ObservableCollection<SeverityView>();
            SeverityTitle = new ObservableCollection<string>();
            Categories = new ObservableCollection<CategoriesView>();
            CategoriesTitle = new ObservableCollection<string>();
            Task.Run(async ()=> 
            {
                try
                {
                    var statuses =
                    await _issuesAPI.GetIssueStatuses(Application.Current.Properties["token"].ToString());
                    foreach (var status in statuses)
                    {
                        StatusesTitle.Add(status.StatusesTitle);
                        Statuses.Add(new StatusesView { Id = status.Id, StatusesTitle = status.StatusesTitle });
                    }
                    var severities = await _issuesAPI.GetSeveritiesAsync(Application.Current.Properties["token"].ToString());
                    foreach (var item in severities)
                    {
                        SeverityTitle.Add(item.SeverityTitle);
                        Severity.Add(new SeverityView { Id = item.Id, SeverityTitle = item.SeverityTitle });
                    }
                    var categories = await _issuesAPI.GetCategoriesAsync(Application.Current.Properties["token"].ToString());
                    foreach (var item in categories)
                    {
                        CategoriesTitle.Add(item.CategoriesTitle);
                        Categories.Add(new CategoriesView { Id = item.Id, CategoriesTitle = item.CategoriesTitle });
                    }
                }
                catch (Exception)
                {

                  //  throw;
                }
                
            });
        }

        private void ReportingDateView_OnSaveButtonClicked(object sender, EventArgs e)
        {
           
        }
    }
}
