using System.Reflection.Metadata.Ecma335;

namespace Battleship_Class_Library;

public record ShotResult(bool Successful, string message);
public record Gunshot(string Shooter, string Target);

public class Game
{
    public static int NumberOfPlayers = 2;
    private static int NumberOfShips = 3;
    public PlayerModel? Winner { get; private set; }

    
    public bool IsOver { get; private set; } = false;
    public bool IsNotOver { get => !IsOver; }
    public List<PlayerModel> Players { get; init; } = new List<PlayerModel>();
    internal GameBoard Board { get; } = new GameBoard();
    public PlayerModel CurrentPlayer { get; private set; }
    internal PlayerModel GetNextPlayer() {
      var nextIndex = (Players.FindIndex(x=> x.Name == (CurrentPlayer.Name) + 1)) % NumberOfPlayers;
      if (nextIndex > Players.Count - 1) {
        return Players[0];
      }
      return Players[nextIndex];
    } 


    public Game(string[] players)
    {
        CreatePlayers(players);
        CreateShipsForEveryPlayer();
        CurrentPlayer = Players[0];

    }

    private void CreateShipsForEveryPlayer()
    {
        foreach (PlayerModel player in Players)
        {
            for (int i = 0; i < NumberOfShips; i++)
            {
                Board.PlaceRandomShip(player);      
            }
        }
    }

    private void CreatePlayers(string[] players)
    {
        foreach (var player in players)
        {
            Players.Add(new PlayerModel(player));
        }
    }

    public ShotResult TakeShot(Gunshot gunshot)
    {
        ShotResult result;
        var (playerName, target) = gunshot;
        var player = Players.Find(x => x.Name == playerName);
        if (IsOver) {
            throw new Exception("You can't take a shot when the game is over.");
        }
        if (CurrentPlayer != player)
        {
            throw new ArgumentException($"It's not {player!.Name}'s turn! Please make sure that opponents play one round.");
        }
        if (Board.HasNoCellWithName(target))
        {
            throw new ArgumentException($"There is no cell with the name {target}.");
        }
        if (Board.Cells[target].HasNoOwner)
        {
            result = new ShotResult(false, "We failed to destroy any enemy's battleships.");
            CurrentPlayer = GetNextPlayer();
            return result;
        }
        if (Board.Cells[target].Owner != player)
        {
            Board.DestroyShipInTargetCell(target);
            result = new ShotResult(true, "We destroyed the enemy'e ship captian!");


            CurrentPlayer = GetNextPlayer();
            return result;

        }
        result = new ShotResult(false, "We failed to destroy any enemy's battleships.");
        CurrentPlayer = GetNextPlayer();
        return result;
    }

    public bool IsShootableTarget(string target)
    {
        return Board.HasCellWithName(target);
    }

    public bool IsNotShootableTarget(string target)
    {
        return !IsShootableTarget(target);
    }


}

