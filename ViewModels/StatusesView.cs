using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ViewModels
{
    public class StatusesView : INotifyPropertyChanged
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
        private string statusesTitle;
                    
        public string StatusesTitle
        {
            get { return statusesTitle; }
            set
            {
                if (statusesTitle!=value)
                {
                    statusesTitle = value;
                    OnPropertyChanged("StatusesTitle");
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
