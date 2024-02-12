
using MathClassLib;
using Functions_with_debugging_and_testing;
using System.Diagnostics;
partial class Program
{


    private static void ConfigureTrace()
    {
        var logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "log.txt");
        TextWriterTraceListener logFile = new(File.Create(logPath));
        Trace.Listeners.Add(logFile);
        Trace.AutoFlush = true;


    }



}