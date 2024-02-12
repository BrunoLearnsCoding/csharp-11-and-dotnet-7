namespace TaskSchedulerApp.Models;

public class TaskModel {
    public EventHandler? TaskIsDue;
    public EventHandler? TaskIsOverDue;

    public string Title { get; set; }
    public DateOnly? DueDate { get; set; }
    public bool IsNotCompleted {get => IsCompleted;}
    public bool IsCompleted {get; set;} = true;


    public TaskModel(string title) {
        ArgumentNullException.ThrowIfNullOrEmpty(title);
        Title = title;
        TimeMachine.DateChanged += OnDateChanged;
    }

    private void OnDateChanged(DateOnly today)
    {
        WriteLine($"Task '{Title}' is notified by the time machine.");
        if (today == DueDate) {
            TaskIsDue?.Invoke(this, new EventArgs());
        }
        if (IsNotCompleted && today > DueDate) {
            TaskIsOverDue?.Invoke(this, new EventArgs());
        }
    }
}

