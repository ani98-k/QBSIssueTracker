using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QBSIssueTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentView
    {
        public string ForMainViewChack;
        List<String> IssueStateList;
        StackLayout _mainContent;
        public ListView IssueList { get { return this.issueList; } set { this.issueList = value; } }
        public MainView(StackLayout Mainview)
        {
          
            
            InitializeComponent();
            _mainContent = Mainview;
            issueList.ItemSelected += IssueList_ItemSelected;
            this.ClassId= "This is the Main view";
            ForMainViewChack = "This is the Main view";
            IssueStateList = new List<string>();
            IssueStateList.Add("#45E561|Ecsncnecoieeiwccwicc nvnvwenvewe vvvv|Open");
            IssueStateList.Add("#0099FF|TMT Isue|Solved");
            IssueStateList.Add("#41246A|TMT Isue|Solved");
            IssueStateList.Add("#45FFA2|TMT Isue|Solved");
            IssueStateList.Add("#45EEEE|Tdfghjkl dd|Solved");
            IssueStateList.Add("#45E561|TMT ascd|In progres");
            IssueStateList.Add("#45E561|TMT ascd|In progres");
            IssueStateList.Add("#45E561|TMT ascd|In progres");
            IssueStateList.Add("#45E561|TMT ascd|In progres");
            IssueStateList.Add("#45E561|TMT ascd|In progres");
            IssueStateList.Add("#45E561|TMT ascd|In progres");
            IssueStateList.Add("#45E561|TMT ascd|In progres");
           // IssueLIstController();
        }

        private void IssueList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var issue = e.SelectedItem as AddIssueViewModel;
            this._mainContent.Children.Clear();
            this._mainContent.Children.Add(new EditIssueView(issue,_mainContent));
        }

        public void IssueLIstController()
        {
           // IssueStateView.Children.Clear();
        
            var rowCounts = 0;
            Grid gridConteiner = new Grid();
            //gridConteiner.BindingContext = IssueStateView;
            //gridConteiner.SetBinding(Grid.HeightProperty, "Value");
            gridConteiner.BackgroundColor = Color.FromHex("#F3F3F3");
            gridConteiner.Margin = new Thickness(0);
            gridConteiner.RowSpacing = 2.5;
            gridConteiner.Padding = new Thickness(0);
            gridConteiner.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            gridConteiner.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(12, GridUnitType.Star) });
            gridConteiner.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
            gridConteiner.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(4, GridUnitType.Star) });
           
                for (int i = 0; i < IssueStateList.Count; i++)
                {
                    var IssueStateListSplited = IssueStateList[i].Split(new char[] { '|' },
                    StringSplitOptions.RemoveEmptyEntries);
                    var row = new RowDefinition { Height = new GridLength(2, GridUnitType.Star) };
                    gridConteiner.RowDefinitions.Add(row);
                    gridConteiner.Children.Add(new StackLayout { BackgroundColor = Color.FromHex(IssueStateListSplited[0]) }, left: 0, rowCounts);
                    gridConteiner.Children.Add(new Label { Style = IssueStateStyle, BackgroundColor = Color.Transparent, Text = IssueStateListSplited[1] }, 1, rowCounts);
                    gridConteiner.Children.Add(new Label { BackgroundColor = Color.Transparent, Style=IssueStateStyle ,Text = IssueStateListSplited[2] }, 3, rowCounts);
                    rowCounts++;
                }
            TapGestureRecognizer tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += (s, e1) =>
             {
                 _mainContent.Children.Clear();
                 _mainContent.Children.Add(new EditIssueView());
             };
            gridConteiner.GestureRecognizers.Add(tapGesture);
            //  MainGrid.Children.Add(gridConteiner,0,5);
         //   IssueStateView.Content = gridConteiner;
           // IssueStateView.Children.Add(gridConteiner);
        }

        private void PickerGrd_Tapped(object sender, EventArgs e)
        {
            PickerGrd.Opacity = 0.25;
            PickerView.IsVisible = true;
            PickerView.IsEnabled = true;
            PickerGrd.Opacity = 1;
            TapGestureRecognizer mainLayout_Tapped = new TapGestureRecognizer();
            mainLayout_Tapped.Tapped += (s, e1) => 
            {
                PickerView.IsVisible = false;
                PickerView.IsEnabled = false;
                MainLayout.GestureRecognizers.Clear();
            };
            MainLayout.GestureRecognizers.Add(mainLayout_Tapped);
        }
        
        private void PickerItem_Tapped(object sender, EventArgs e)
        {
            PickerView.IsEnabled = false;
            var grd = sender as Grid;
        
            PickedPickerItemLogeImg.Source = (grd.Children.First(x => x is Image) as Image).Source;
            PickedPickerItemText.Text = (grd.Children.First(x => x is Label) as Label).Text;
            PickerView.IsVisible = false;
            MainLayout.GestureRecognizers.Clear();
            Device.BeginInvokeOnMainThread(() => 
            {
                IssueLIstController();
            });
            
        }
    }
}