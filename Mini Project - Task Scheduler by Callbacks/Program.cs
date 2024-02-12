using System.Globalization;
using Mini_Project_Task_Scheduler_by_Callbacks.Data;
using Mini_Project_Task_Scheduler_by_Callbacks.Models;

namespace Mini_Project_Task_Scheduler_by_Callbacks;

class Program
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
        var repository = new TaskRepository();
        var timeService = new TimeService();
        var scheduler = new TaskScheduler(repository);
        timeService.TimeChanged += scheduler.OnTimeChanged;
        timeService.StartSimulation();

    }
}
