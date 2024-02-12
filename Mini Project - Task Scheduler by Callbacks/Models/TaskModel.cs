namespace Mini_Project_Task_Scheduler_by_Callbacks.Models;

public class TaskModel {
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime ScheduledTime {get; set;}
    public bool IsDue {get; set;} = false;
    public bool IsNotDue => !IsDue;


    public TaskModel(string name, string description, DateTime scheduleTime) {
        ArgumentNullException.ThrowIfNullOrEmpty(name);
        ArgumentNullException.ThrowIfNullOrEmpty(description);
        Name = name;
        Description = description;
        ScheduledTime = scheduleTime;
    }

}
