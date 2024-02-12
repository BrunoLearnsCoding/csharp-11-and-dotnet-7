using System.Diagnostics;
using Microsoft.Extensions.Configuration;


/// <summary>
/// How to configure Trace 
/// This was the time I was configureing a project to use settings from a configuration file.
/// In the first step, you create a TextWriterTraceListener by passing a FileStream to its constructor and
/// and then add this new TextWriterTraceListener to Listeners' collection of Trace class. So you can write
/// anything to the underlying file using Debug and Trace classes.
/// 
/// In the second step, you create a ConfigurationBuilder and set its base path to the current directory.
/// Then you should add a json file which contains the settings needed for configuraing Trace switch level.
/// Then, you have to call the Build() method to create an object which implements IConfigurationRoot.
/// This object can read configuraion from the file using GetSection() and Bind() it to a TraceSwitch 
/// object which in turn could be assigned to a private class variable to be used later.
/// 
/// I designed a method to TryConfigureTrace() so that it returns a boolean value showing
/// if the method was successfull.
/// 
/// 
/// Some classes and interfaces were very usefull:
/// ConfigurationBuilder, IConfigurationRoot, ConfigurationSection, TextWriteTraceListener, TraceSwitch
/// 
/// Some classes were helpfull to manage files: 
/// Path, Directoty, File, Environment, 
/// 
/// This packages are needed to be added to any project which needs to manage configuration 
///     Microsoft.Extensions.Configuration.Binder
///     Microsoft.Extensions.Configuration.FileExtensions
///     Microsoft.Extensions.Configuration
///     Microsoft.Extensions.Configuration.Json
/// </summary>
internal class Program
{
    private static TraceSwitch? traceSwitch;

    private static void Main(string[] args)
    {

        ConfigureTrace();

        // Switching trace levels are defined in this document :
        // https://learn.microsoft.com/en-us/dotnet/framework/debug-trace-profile/trace-switches
        Trace.WriteLineIf(traceSwitch!.TraceWarning, "Hello TraceWarning");
        Trace.WriteLineIf(traceSwitch!.TraceInfo, "Hello TraceInfo");
        Trace.WriteLineIf(traceSwitch!.TraceError, "Hello TraceError");
        Trace.WriteLineIf(traceSwitch!.TraceVerbose, "Hello TraceVerbose");

    }

    private static void ConfigureTrace()
    {
        string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "log2.txt");
        TextWriterTraceListener logFile = new(File.Create(logPath));
        Trace.Listeners.Add(logFile);
        Trace.AutoFlush = true;
        string configFileName = "appsettings.json";
        ConfigurationBuilder builder = new();
        builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(configFileName, optional: true, reloadOnChange: true);

        // builder.SetBasePath(Directory.GetCurrentDirectory());
        // builder.AddJsonFile("appsettings.jsond", optional: true, reloadOnChange: true);

        IConfigurationRoot configuration;
        configuration = builder.Build();        // If 'optional' parameter of AddJsonFile is set to false, 
                                                // Build method will throw exeption if the file doesn't exsit.
        var sectionName = "TraceSwitch";
        var section = configuration.GetSection(sectionName);
        if (section.Exists())
        {
            TraceSwitch ts = new(displayName: "Trace Switch", description: "Desc");
            section.Bind(ts);

            Program.traceSwitch = ts;
            Trace.WriteLine($"Trace level was set to {ts.Level.ToString()} based on cofiguration file.");
        }
        else
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), configFileName);
            var message = $"""

                Trace level was set to verbose because a problem occured while configuring Trace.
                Check if the configuration file exists [{path}] and contains the required section '{sectionName}'.");
                """;
            Trace.WriteLine(message);
            Program.traceSwitch = new("Urgency", "Created because config file was not found.");
            traceSwitch.Level = TraceLevel.Verbose;
        }

    }
}