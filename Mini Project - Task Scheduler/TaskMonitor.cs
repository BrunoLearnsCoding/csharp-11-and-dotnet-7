using TaskSchedulerApp.Models;

namespace TaskSchedulerApp;

public class TaskMonitor
{
    internal void RegisterTask(TaskModel task)
    {
        task.TaskIsDue += OnTaskIsDue;
        task.TaskIsOverDue = OnTaskIsOverDue;
    }
    public TaskMonitor()
    {
        TimeMachine.DateChanged += OnDateChanged;
    }

    private void OnDateChanged(DateOnly today)
    {
        var color = ForegroundColor;
        ForegroundColor = ConsoleColor.Green;
        WriteLine($"Task monitor is notified by time machine. Today is {today}");
        ForegroundColor = color;
    }

    private void OnTaskIsDue(object? sender, EventArgs args) {
        if (sender is null) return;
        var task = sender as TaskModel;
        PrintOut($"'{task?.Title}' is due.", ConsoleColor.DarkRed);
    }

    private void OnTaskIsOverDue(object? sender, EventArgs args) {
        if (sender is null) return;
        var task = sender as TaskModel;
        PrintOut($"'{task?.Title}' is over due.", ConsoleColor.Red);
    }

    private void PrintOut(string message, ConsoleColor color) {
        var prev = ForegroundColor;
        ForegroundColor = color;
        WriteLine(message);
        ForegroundColor = prev;

    }

}