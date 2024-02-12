using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.CommandLine;
namespace Configuration_in_.NET;

class Program
{
    static void Main(string[] args)
    {
        // Add a package reference to Microsoft.Extensions.Configuration       ** IMPORTANT **


        // Creates an instance of ConfigurationBuilder
        var builder = new ConfigurationBuilder();


        // Adds an instance of CommandLineConfigurationProvider to the builder
        builder.AddCommandLine(args);

        // Add an instance of InMemoryConfigurationProvider to the builder
        builder.AddInMemoryCollection(new Dictionary<string, string?>() {
            ["LogLevel"] = "Information",
            ["AllowdHosts"] = "*",
            ["lang"] = "es"                
        });

        // The precedence of adding configuration providers matters, because the instance of 
        // IConfiguraionRoot, which will be created by ConfigurationBuilder.Build(), keeps unique keys 
        // and the keys that are added to the builder later can override the keys of previous sources.

        var configuration = builder.Build();
        
        // If you pass a command-line argument lang=en, this will be overriden 
        // by the same key in the InMemoryConfigurationProvider which is added later to the builder.
        
        System.Console.WriteLine(configuration["lang"]);
        System.Console.WriteLine(configuration["loglevel"]);


        System.Console.WriteLine(builder.Sources.First());
        


    }
}
