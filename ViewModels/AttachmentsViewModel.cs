using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.IO;

namespace ViewModels
{
    public class AttachmentsViewModel : INotifyPropertyChanged
    {
        private string attachmentsLink;

        public string AttachmentsLink
        {
            get { return attachmentsLink; }
            set { attachmentsLink = value; OnPropertyChanged("AttachmentsLink"); }
        }
        private Xamarin.Forms.ImageSource fullUrl;

        public Xamarin.Forms.ImageSource FullUrl
        {
            get { return fullUrl; }
            set { fullUrl = value; OnPropertyChanged("FullUrl"); }
        }
         private string fullUrl1;

        public string FullUrl1
        {
            get { return fullUrl1; }
            set { fullUrl1 = value; OnPropertyChanged("FullUrl"); }
        }

        private string attachmentsUsername;

        public string AttachmentsUsername
        {
            get { return attachmentsUsername; }
            set { attachmentsUsername = value; OnPropertyChanged("AttachmentsUsername"); }
        }
        private Xamarin.Forms.Image attachmentImage;

        public Xamarin.Forms.Image AttachmentImage
        {
            get { return attachmentImage; }
            set { attachmentImage = value; OnPropertyChanged("IssueImage"); }
        }
        private string attachmentsDate;

        public string AttachmentsDate
        {
            get { return attachmentsDate; }
            set { attachmentsDate = value; OnPropertyChanged("AttachmentsDate"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}