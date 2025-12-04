using System.Windows;

namespace TaskManagerApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddTask_Click(object sender, EventArgs e)
        {
            var text = TaskTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(text))
            {
                TaskListBox.Items.Add(text);
                TaskTextBox.Clear();
            }
        }

        private void TaskTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
