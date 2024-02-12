namespace TaskSchedulerApp;

public class TimeMachine {
    public delegate void DateChangedEventHandler(DateOnly today);
    public static event DateChangedEventHandler? DateChanged;
    public static DateOnly Today { get; private set; } = DateOnly.FromDateTime(DateTime.Today);
    public static void GotoNextDay() {
        Today = Today.AddDays(1);
        DateChanged?.Invoke(Today);
    }


}
