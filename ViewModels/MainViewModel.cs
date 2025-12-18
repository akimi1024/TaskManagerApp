using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using System.Windows.Shapes;
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
                DeleteTaskCommand.RaiseCanExecuteChanged();
                OnPropertyChanged("SelectedTask");
                OnPropertyChanged("CanDelete");
            }
        }

        private string _NewTaskTitle;
        public string NewTaskTitle
        {
            get => _NewTaskTitle;
            set
            {
                _NewTaskTitle = value;
                OnPropertyChanged(nameof(NewTaskTitle));
                AddTaskCommand.RaiseCanExecuteChanged();
            }
        }
        public bool CanDelete => SelectedTask != null;

        public RelayCommand AddTaskCommand { get; }

        public RelayCommand DeleteTaskCommand { get; }

        public MainViewModel()
        {
            AddTaskCommand = new RelayCommand(
                _ => AddTask(NewTaskTitle),
                _ => !string.IsNullOrWhiteSpace(NewTaskTitle)
            );
            DeleteTaskCommand = new RelayCommand(_ => DeleteTask(), _ => CanDelete);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddTask(string title)
        {
            Tasks.Add(new TaskItem { Title =  title});
            NewTaskTitle = string.Empty;
            SaveTasks();
        }

        public void DeleteTask()
        {
            Tasks.Remove(SelectedTask!);
            SelectedTask = null;
            SaveTasks();
        }

        public void SaveTasks()
        {
            
            
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            string directoryPath = System.IO.Path.Combine(filePath, "TaskManagerApp");

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
                
            string jsonString = System.Text.Json.JsonSerializer.Serialize(Tasks);


            System.IO.File.WriteAllText(System.IO.Path.Combine(directoryPath, "tasks.json"), jsonString);
        }

        public void LoadTasks()
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            
            string directoryPath = System.IO.Path.Combine(filePath, "TaskManagerApp");

            string fullPath = System.IO.Path.Combine(directoryPath, "tasks.json");
            if (System.IO.File.Exists(fullPath))
            {
                string jsonString = System.IO.File.ReadAllText(fullPath);
                var loadedTasks = System.Text.Json.JsonSerializer.Deserialize<ObservableCollection<TaskItem>>(jsonString);
                if (loadedTasks != null)
                {
                    Tasks.Clear();
                    foreach (var task in loadedTasks)
                    {
                        Tasks.Add(task);
                    }
                }
            }
        }
    }
}
