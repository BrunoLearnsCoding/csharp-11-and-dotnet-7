using System.Globalization;
using TaskSchedulerApp.Models;

namespace TaskSchedulerApp;

class Program
{
    static void Main(string[] args)
    {
        SetCulture("en-us");
        var monitor = new TaskMonitor();


        var task = new TaskModel("Call Mr. Benjamin Button");
        task.DueDate = TimeMachine.Today.AddDays(1);

        var otherTask = new TaskModel("Visit Mr. Goerge at 10:00");
        otherTask.DueDate = TimeMachine.Today;
        
        
        monitor.RegisterTask(task);
        monitor.RegisterTask(otherTask);

        WriteLine($"Today is {TimeMachine.Today}");

        TimeMachine.GotoNextDay();

        TimeMachine.GotoNextDay();
        otherTask.IsCompleted = true;
        TimeMachine.GotoNextDay();
        TimeMachine.GotoNextDay();






    }

    private static void OnTaskCreated(object? sender, EventArgs arg )
    {
        if (sender is null) return;
        var task = sender as TaskModel;
        Console.WriteLine(task?.Title);
    }

    private static void SetCulture(string culture)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(culture);

    }
}
