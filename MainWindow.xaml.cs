using System.Collections.ObjectModel;
using System.Windows;
using TaskManagerApp.Models;

namespace TaskManagerApp
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<TaskItem> taskItems = [];

        public MainWindow()
        {
            InitializeComponent();
            TaskListBox.ItemsSource = taskItems;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            var text = TaskTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(text))
            {
                // Add the new task to the list
                taskItems.Add(new TaskItem { Title = text });
                TaskTextBox.Clear();
            }
        }

        private  void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if(TaskListBox.SelectedItem is TaskItem selectedTask)
            {
                taskItems.Remove(selectedTask);

                DeleteButton.IsEnabled = false;
            }
        }

        private void TaskTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void TaskListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var hasSelection = TaskListBox.SelectedItem != null;
            DeleteButton.IsEnabled = hasSelection;
        }
    }
}
