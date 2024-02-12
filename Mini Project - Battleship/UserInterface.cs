using System.Diagnostics;
using Battleship_Class_Library;

namespace Mini_Project___Battleship;



public class UserInterface
{
    private Game? game;

    public void Start()
    {
        // DisplayWelcomePage();
        string[] players = GetPlayersInfo();
        game = new Game(players);

        do {
            RecordPlayerShot(game.CurrentPlayer);
        } while (game.IsNotOver);

        DisplayCongratulationsPage(game.Winner);
    }

    private void RecordPlayerShot(PlayerModel player)
    {
        DrawGameborad();
        var target = GetTarget(player);
        var result = game!.TakeShot(new Gunshot(Shooter: player.Name, Target: target));
        DisplayMessage(result.message);
        DisplayMessage("Press any key to continue...");
        Console.ReadKey();
    }

    private void DisplayMessage(string message)
    {
        System.Console.WriteLine(message);
    }

    private void DisplayCongratulationsPage(PlayerModel? winner)
    {
        System.Console.WriteLine($"Congradulation {winner!.Name}! You won.");
    }

    private void DrawGameborad()
    {
        System.Console.WriteLine("");
        for (int i = 1; i <= 5; i++)
        {
            //TOD Complete the DrawGameboard method
        }
    }

    private string GetTarget(PlayerModel player)
    {
        string? target;
        while (true)
        {
            System.Console.Write($"Order captain! [{player.Name}]");
            target = System.Console.ReadLine();
            if (target is null || game!.IsNotShootableTarget(target))
            {
                DisplayMessage("Not a valid target. Please try again.");
                continue;
            }
            break;
        }
        return target;
    }

    public void DisplayWelcomePage()
    {
        //        System.Console.Clear();
        var welcomeMessage = """
            Welcome to the Battleship!
            Are you ready to fight and conquer the oceans?
            """;
        System.Console.WriteLine(welcomeMessage);


    }
    public string[] GetPlayersInfo()
    {
        System.Console.WriteLine();
        var noOfPlayers = Game.NumberOfPlayers;
        var message = $"The game has {noOfPlayers} players. Choose proper names please.";
        DisplayMessage(message);
        var players = new string[noOfPlayers];
        for (int i = 0; i < noOfPlayers; i++)
        {
            players[i] = AskForPlayerName(players);
        }
        return players;

    }

    public string AskForPlayerName(string[]? namesTaken = null)
    {
        string? name;
        while (true)
        {
            Console.Write("Choose a name, captain:");
            name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                System.Console.WriteLine("The name could not be empty! Please try again.");
                continue;
            }
            if (namesTaken is not null)
            {
                if (namesTaken.Contains(name))
                {
                    System.Console.WriteLine("This name is already taken by your opponent. Try again.");
                    continue;
                }
            }
            break;
        }
        return name;
    }


}