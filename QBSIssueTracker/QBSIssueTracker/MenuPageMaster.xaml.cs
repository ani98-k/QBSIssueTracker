using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QBSIssueTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPageMaster : ContentPage
    {
        public ListView ListView;

        public MenuPageMaster()
        {
            InitializeComponent();
            
            BindingContext = new MenuPageMasterViewModel();
           // ListView = MenuItemsListView;
           
        }
        public Grid GetMasterPlusImage()
        {
            
            return plusIconGrd;
        }
        public Grid GetMasterHomeImage()
        {
            return HomeImgGrd;
        }
        public Grid GetMasterIssueListImage()
        {
            return IssueListGrd;
        }
        class MenuPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MenuPageMasterMenuItem> MenuItems { get; set; }
            
            public MenuPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MenuPageMasterMenuItem>(new[]
                {
                    new MenuPageMasterMenuItem { Id = 0, Title = "Page 1" },
                    new MenuPageMasterMenuItem { Id = 1, Title = "Page 2" },
                    new MenuPageMasterMenuItem { Id = 2, Title = "Page 3" },
                    new MenuPageMasterMenuItem { Id = 3, Title = "Page 4" },
                    new MenuPageMasterMenuItem { Id = 4, Title = "Page 5" },
                });
            }
           
            private void PlusIcon_Tapped(object sender, EventArgs e)
            {
                
            }
           
            private  void SupportGrd_Tapped(object sender, EventArgs e)
            {
              
            }
            

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("http://support.qbs-me.com"));
        }

        private void QBS_Tapped(object sender, EventArgs e)
        {
            //
        }
        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("http://www.qbs.jo"));
        }
    }
}