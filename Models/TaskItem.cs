namespace TaskManagerApp.Models
{
    public class TaskItem
    {
        public required string Title { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
