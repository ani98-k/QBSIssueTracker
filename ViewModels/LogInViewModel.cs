using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ViewModels
{
    public class LogInViewModel : INotifyPropertyChanged
    {
        private string userName;
        private string password;

        public string Password
        {
            get { return password; }
            set
            {   password = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Password"));
            }
        }


        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UserName"));
            }
        }

        public LogInViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
