using System.Windows;

namespace TaskManagerApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddTask_Clik(object sender, EventArgs e)
        {
            var text = TaskTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(text))
            {
                TaskListBox.Items.Add(text);
                TaskTextBox.Clear();
            }
        }
    }
}
