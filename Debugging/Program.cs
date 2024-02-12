using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace Debugging;

class Program
{
    static private TraceSwitch? traceSwitch;
    static void Main(string[] args)
    {
        // string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "log.txt");
        // Console.WriteLine(logPath);
        // TextWriterTraceListener logFile = new(File.CreateText(logPath));        
        // Trace.Listeners.Add(logFile);
        // Trace.AutoFlush = true;
        // ConfigureTrace();
        // Trace.WriteLine("Hello from Trace!");
        // Debug.WriteLine("Hello from Debug!");
        // Trace.WriteLineIf(traceSwitch!.TraceInfo, message: "Information: You are going to be informed!");
        // Trace.WriteLineIf(traceSwitch!.TraceError, "Error: An error occured!");

        Trace.WriteLine("default trace outpu");
        Debug.WriteLine("default trace outpu");

        WriteLine("Hello, Worlds!");
    }

    static private void ConfigureTrace()
    {
        string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "log.txt");
        TextWriterTraceListener logFile = new(File.CreateText(logPath));
        Trace.Listeners.Add(logFile);
        Trace.AutoFlush = true;

        WriteLine(Directory.GetCurrentDirectory());
        ConfigurationBuilder builder = new();
        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfigurationRoot configuration = builder.Build();  
        

        TraceSwitch traceSwitch = new TraceSwitch(
            displayName: "PacktSwitch",
            description: "Trace");
        try
        {
            configuration.GetSection("PacktSwitch").Bind(traceSwitch);

        }
        catch (Exception ex) {
            WriteLine(ex.GetType());
            WriteLine(ex.InnerException!.GetType());
            WriteLine(ex.InnerException.Message);
        }
        Program.traceSwitch = traceSwitch;


    }
}
