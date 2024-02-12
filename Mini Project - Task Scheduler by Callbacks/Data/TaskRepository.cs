using Mini_Project_Task_Scheduler_by_Callbacks.Models;

namespace Mini_Project_Task_Scheduler_by_Callbacks.Data;

public delegate void ProcessTasks(TaskModel task);
public class TaskRepository
{
    private List<TaskModel> _tasks = new List<TaskModel>();

    public void ProcessImminentTasks(DateTime now, ProcessTasks process)
    {
        foreach (TaskModel task in _tasks)
        {
            if (task.ScheduledTime.Date == now.Date && task.ScheduledTime.Hour == now.Hour && task.IsNotDue) 
            {
                task.IsDue = true;
                process(task);
            }
        }
    }
    public TaskRepository()
    {
        Populate();
    }

    private void Populate()
    {
        _tasks = GenerateDummyTasks(100);
    }


    private List<TaskModel> GenerateDummyTasks(int count)
    {
        List<TaskModel> tasks = new List<TaskModel>();
        Random random = new Random();

        List<string> sampleDescriptions = new List<string>
        {
            "Complete project report",
            "Review code changes",
            "Attend team meeting",
            "Prepare presentation",
            "Debug software issues",
            "Implement new feature",
            "Optimize database queries",
            "Test application performance",
            "Write unit tests",
            "Deploy software update",
            "Conduct code review",
            "Create user documentation",
            "Resolve customer support tickets",
            "Collaborate with cross-functional teams",
            "Design system architecture",
            "Analyze data trends",
            "Secure application against vulnerabilities",
            "Train team members on new technology",
            "Plan sprint goals",
            "Document API endpoints",
            "Enhance user interface"
            // Add more sample descriptions as needed
        };
        for (int i = 0; i < count; i++)
        {
            TaskModel task = new TaskModel
            (
                name: $"Task{i + 1}",
                description: GetRandomDescription(sampleDescriptions),
                scheduleTime: DateTime.Now.AddHours(random.Next(0, 100))
            );
            // System.Console.WriteLine(task.ScheduledTime);

            tasks.Add(task);
        }

        return tasks;

    }

    private string GetRandomDescription(List<string> descriptions)
    {
        Random random = new Random();
        return descriptions[random.Next(descriptions.Count)] + random.Next(500000).ToString();
    }


}

