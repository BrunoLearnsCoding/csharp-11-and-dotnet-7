namespace Battleship_Class_Library;

public class PlayerModel {
    public string Name {get; init;}
    internal PlayerModel(string name)
    {
        Name = name;
    }
    internal List<BoardCell> ShipLocations {get; set;} = new List<BoardCell>();

}