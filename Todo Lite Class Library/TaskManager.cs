using System.ComponentModel;
using System.Data;
using Todo_Lite_Class_Library.Models;

namespace Todo_Lite_Class_Library;

public interface IUserInput
{
    string GetUserInput(string message);
}

public class TaskManager
{
    private IUserInput ui;
    private List<ProjectModel> projectList = new List<ProjectModel>();
    public (bool Succeeded, List<string> ValidationErrors) CreateAProject()
    {
        var errorMessages = new List<string>();
        bool succeeded = false;
        string title = ui.GetUserInput("Please enter the project's title: ");
        string description = ui.GetUserInput("Please enter the project's description: ");
        if (string.IsNullOrEmpty(title))
        {
            errorMessages.Add("Title could not be empty");
        }
        if (string.IsNullOrEmpty(description))
        {
            errorMessages.Add("Description could not be empty");
        }
        if (errorMessages.Count == 0)  
        {
            projectList.Add(new ProjectModel(title, description));
            succeeded = true;
        }
        return (succeeded, errorMessages);
    }

    public (bool Succeeded, List<string> ValidationErrors) CreateTaskFor(ProjectModel project) {
        ArgumentNullException.ThrowIfNull(project);
        var errorMessages = new List<string>();
        bool succeeded = false;
        string title = ui.GetUserInput("Please enter the task's description: ");
        if (string.IsNullOrEmpty(title))
        {
            errorMessages.Add("Title could not be empty");
        }
        if (errorMessages.Count == 0)  
        {
            project.AddTask(new TaskModel(title));
            succeeded = true;
        }

        return (succeeded, errorMessages);

    }

    public IList<ProjectModel> AllProjects()
    {
        return projectList.AsReadOnly();
    }

    public TaskManager(IUserInput ui)
    {
        ArgumentNullException.ThrowIfNull(ui);
        this.ui = ui;
    }

}