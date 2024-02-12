using Todo_Lite_Class_Library;
using Todo_Lite_Class_Library.Models;

public class ConsoleUI : IUserInput
{
    internal void Run(TaskManager taskManager)
    {
        do
        {
            var selection = GetUserSelectionFromMainMenu();
            switch (selection)
            {
                case 1:
                    DisplayProjectCreationPage(taskManager);
                    break;
                case 2:
                    DisplayTaskCreationPage(taskManager);
                    break;
                case 3:
                    DisplayProjectListPage(taskManager);
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
            }
        } while (true);
    }
    private int GetUserSelectionFromMainMenu()
    {
        int selection = 0;
        ForegroundColor = ConsoleColor.Cyan;
        do
        {
            Clear();
            WriteLine("[1] Create a project.");
            WriteLine("[2] Create a task.");
            WriteLine("[3] View all projects");
            WriteLine("[4] View due tasks.");
            WriteLine("[5] Quit");
            var keyInfo = ReadKey();

            if (int.TryParse(keyInfo.KeyChar.ToString(), out selection) == false | selection > 5)
            {
                WriteLine();
                WriteLine("Wrong selection. Please try again.");
                Write("Press any key to continue...");
                ReadKey();
                continue;
            }
            break;

        } while (true);
        return selection;
    }
    public string GetUserInput(string message)
    {
        Write(message);
        var output = ReadLine();
        return string.IsNullOrEmpty(output) ? string.Empty : output;
    }

    private void DisplayTaskCreationPage(TaskManager taskManager)
    {
        do
        {
            ClearScreen();
            var selectedProject = GetProjectFromUser(taskManager.AllProjects());
            if (selectedProject == null)
            {
                return;
            }
            var result = taskManager.CreateTaskFor(selectedProject);
            if (result.Succeeded)
            {
                DisplaySuccessMessage("The task was successfully created.");
                return;
            }
            else
            {
                DisplayValidationErrors(result.ValidationErrors);
            }
            PressAnyKeyToContinue();

        } while (true);

    }
    private void DisplayProjectCreationPage(TaskManager taskManager)
    {
        ClearScreen();
        var result = taskManager.CreateAProject();
        if (result.Succeeded)
        {
            DisplaySuccessMessage("The project is successfully created.");
        }
        else
        {
            DisplayValidationErrors(result.ValidationErrors);
        }
        PressAnyKeyToContinue();
    }

    private ProjectModel? GetProjectFromUser(IList<ProjectModel> projects)
    {
        if (projects.Count == 0)
        {
            WriteLine("There is no project to select.");
            PressAnyKeyToContinue();
            return null;
        }
        for (int i = 0; i < projects.Count; i++)
        {
            WriteLine($"[{i + 1}] - {projects[i].Title}");
        }
        var input = GetUserInput("Select a project number or empty to cancel: ");
        if (input == string.Empty || int.TryParse(input, out int selection) == false || selection > projects.Count || selection < 1)
        {
            WriteLine("No project were selected.");
            WriteLine();
            PressAnyKeyToContinue();
            return null;
        }
        return projects[selection - 1];
    }

    private void DisplayProjectListPage(TaskManager taskManager)
    {
        ClearScreen();

        foreach (var project in taskManager.AllProjects())
        {
            WriteLine($"{project.Title} : {project.Description}");
        }
        if (taskManager.AllProjects().Count() == 0)
        {
            WriteLine("There is no project in the list.");
        }
        PressAnyKeyToContinue();

    }

    private static void DisplaySuccessMessage(string message)
    {
        ForegroundColor = ConsoleColor.Green;
        WriteLine();
        WriteLine(message);
        ForegroundColor = ConsoleColor.Cyan;

    }

    private static void DisplayValidationErrors(List<string> validationErrors)
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine();
        foreach (var error in validationErrors)
        {
            WriteLine(error);
        }
        ForegroundColor = ConsoleColor.Cyan;

    }

    private static void PressAnyKeyToContinue()
    {
        WriteLine();
        Write("Press any key to continue...");
        ReadKey();
    }
    private void ClearScreen()
    {
        Clear();
    }
}