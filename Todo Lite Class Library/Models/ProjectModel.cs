namespace Todo_Lite_Class_Library.Models;

public class ProjectModel {
    public string Title { get; set; }
    public string Description { get; set; }
    public List<TaskModel> Tasks = new List<TaskModel>();
    public ProjectModel(string title, string description)
    {
        ArgumentException.ThrowIfNullOrEmpty(title);
        ArgumentException.ThrowIfNullOrEmpty(description);
        Title = title;
        Description = description;
    }

    public void AddTask(TaskModel task) {
        Tasks.Add(task);

    }
    

}
