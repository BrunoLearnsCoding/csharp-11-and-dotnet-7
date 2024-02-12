using Mini_Project_Task_Scheduler_by_Callbacks.Data;
using Mini_Project_Task_Scheduler_by_Callbacks.Models;

namespace Mini_Project_Task_Scheduler_by_Callbacks;

public class TaskScheduler
{
    private DateTime _now;
    private TaskRepository _repository;
    public TaskScheduler(TaskRepository repository)
    {
        _repository = repository;
    }

    public void OnTimeChanged(DateTime currentDateTime)
    {
        _now = currentDateTime;
        _repository.ProcessImminentTasks(currentDateTime, PrintOut);
    }

    private void PrintOut(TaskModel task) {
        System.Console.WriteLine($"{task.Description} is due. {_now}");
    }
}
