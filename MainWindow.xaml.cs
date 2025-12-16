using System.Windows;
using TaskManagerApp.Models;
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

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            var text = TaskTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(text))
            {
                viewModel.AddTask(text);
                TaskTextBox.Clear();
            }
        }

        private  void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if(TaskListBox.SelectedItem is TaskItem selectedTask)
            {
                viewModel.DeleteTask();
            }
        }

        private void TaskTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void TaskListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            viewModel.SelectedTask = (TaskItem)TaskListBox.SelectedItem!;
        }
    }
}
