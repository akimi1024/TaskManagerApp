using System.Windows;
using TaskManagerApp.ViewModels;

namespace TaskManagerApp
{
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
            viewModel.LoadTasks();
        }
    }
}
