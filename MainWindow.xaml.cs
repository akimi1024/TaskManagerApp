using System.Windows;
using TaskManagerApp.Models;

namespace TaskManagerApp
{
    public partial class MainWindow : Window
    {
        private List<TaskItem> taskItems = [];

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

                // Refresh the ListBox to show the new task
                TaskListBox.Items.Refresh();
            }
        }

        private  void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if(TaskListBox.SelectedItem is TaskItem selectedTask)
            {
                taskItems.Remove(selectedTask);
                TaskListBox.Items.Refresh();
            }
        }

        private void TaskTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
