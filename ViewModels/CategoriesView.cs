using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ViewModels
{
    public class CategoriesView:INotifyPropertyChanged
    {
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
        private string categoriesTitle;

        public string CategoriesTitle
        {
            get { return categoriesTitle; }
            set
            {
                if (categoriesTitle!=value)
                {
                    categoriesTitle = value;
                    OnPropertyChanged("CategoriesTitle");
                }

            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
