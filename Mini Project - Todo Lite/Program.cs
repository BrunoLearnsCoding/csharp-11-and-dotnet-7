

namespace Mini_Project___Todo_Lite;

using System;
using Todo_Lite_Class_Library.Models;
using Todo_Lite_Class_Library;

class Program
{
    static void Main(string[] args)
    {
        var ui = new ConsoleUI();
        var taskManager = new TaskManager(ui);
        ui.Run(taskManager);
    }


}

