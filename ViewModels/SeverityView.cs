using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ViewModels
{
    public class SeverityView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private decimal id;

        public decimal Id
        {
            get { return id; }
            set
            {
                if (id!=value)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }

            }
        }
        private string severityTitle;

        public string SeverityTitle
        {
            get { return severityTitle; }
            set
            {
                if (severityTitle!=value)
                {
                    severityTitle = value;
                    OnPropertyChanged("SeverityTitle");
                }
                
            }
        }


        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
