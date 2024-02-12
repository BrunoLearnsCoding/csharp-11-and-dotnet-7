namespace Todo_Lite_Class_Library.Models;

public class TaskModel {
    public string Title { get; set; } 
    internal bool SeemsToBeTemporary = false;

    public TaskModel(string title) {
        ArgumentException.ThrowIfNullOrEmpty(title);
        Title = title;
        if (title.Length < 5) {
            SeemsToBeTemporary = true;
        }
    }
    
    

}