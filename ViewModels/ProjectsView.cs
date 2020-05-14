using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ViewModels
{
    public  class ProjectsView: INotifyPropertyChanged
    {
        private decimal id;

        public decimal Id
        {
            get { return id; }
            set {
                if (id!=value)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
                
            }
        }
        private string projectsTitle;

        public string ProjectsTitle
        {
            get { return projectsTitle; }
            set
            {
                if (projectsTitle!=value)
                {
                    projectsTitle = value;
                    OnPropertyChanged("ProjectsTitle");
                }

            }
        }
        private Boolean? projectsIsActive;

       

        public Boolean? ProjectsIsActive
        {
            get { return projectsIsActive; }
            set
            {
                if (ProjectsIsActive!=value)
                {
                    projectsIsActive = value;
                    OnPropertyChanged("ProjectsIsActive");
                }

            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
