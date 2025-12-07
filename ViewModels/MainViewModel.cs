using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using TaskManagerApp.Models;

namespace TaskManagerApp.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<TaskItem> Tasks { get; } = new ObservableCollection<TaskItem>();

        public MainViewModel()
        {
        }

        public void AddTask(string title)
        {
            Tasks.Add(new TaskItem { Title =  title});
        }

        public void DeleteTask(TaskItem task)
        {
            Tasks.Remove(task);
        }

        //public bool IsTaskSelection()
        //{
            
        //}
    }
}
