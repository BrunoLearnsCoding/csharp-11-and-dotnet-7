
using System.Diagnostics;
using System.Net.WebSockets;

namespace Mini_Project_Task_Scheduler_by_Callbacks;

public delegate void TimeChangedEventHandler(DateTime dateTime);

public class TimeService
{

    public event TimeChangedEventHandler? TimeChanged;

    public void StartSimulation()
    {
        {
            DateTime now = DateTime.Now;
            for (int i = 0; i < 6000; i++)
            {
                Thread.Sleep(1);
                now = now.AddMinutes(1);
                TimeChanged?.Invoke(now);
            }
        }
    }
}