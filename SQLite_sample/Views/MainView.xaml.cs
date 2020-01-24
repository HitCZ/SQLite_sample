using SQLite_sample.ViewModels;
using System.Windows;

namespace SQLite_sample.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainViewModel ViewModel
        {
            get => DataContext as MainViewModel;
            set => DataContext = value;
        }

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainViewModel();
            ViewModel.LoadPeople();
        }

        private void AddPerson_OnClick(object sender, RoutedEventArgs e) => ViewModel.SavePerson();

        private void RefreshList_OnClick(object sender, RoutedEventArgs e) => ViewModel.LoadPeople();
    }
}
