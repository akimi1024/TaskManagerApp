using System.Collections.ObjectModel;
using System.ComponentModel;
using TaskManagerApp.Models;

namespace TaskManagerApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TaskItem> Tasks { get; } = new ObservableCollection<TaskItem>();
        private TaskItem? _SelectedTask;
        public TaskItem? SelectedTask { 
            get => _SelectedTask; 
            set 
            { 
                _SelectedTask = value;
                OnPropertyChanged("SelectedTask");
                OnPropertyChanged("CanDelete");
            }
        }
        public bool CanDelete => SelectedTask != null;


        public MainViewModel()
        {
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddTask(string title)
        {
            Tasks.Add(new TaskItem { Title =  title});
        }

        public void DeleteTask()
        {
            Tasks.Remove(SelectedTask!);
            SelectedTask = null;
        }
    }
}
