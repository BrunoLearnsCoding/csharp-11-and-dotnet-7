using System.Diagnostics;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Battleship_Class_Library;


internal class GameBoard
{
    internal IDictionary<string, BoardCell> Cells { get; init; } = new Dictionary<string, BoardCell>();
    internal GameBoard()
    {
        string[] cellnames = { "A1", "A2", "A3", "A4", "A5", "B1", "B2", "B3", "B4", "B5", "C1", "C2", "C3", "C4", "C5", "D1", "D2", "D3", "D4", "D5", "E1", "E2", "E3", "E4", "E5" };
        foreach (var name in cellnames)
        {
            Cells.Add(name, new BoardCell(name));
        }
    }
    internal bool HasCellWithName(string? cellName)
    {
        if (cellName is null) return false;
        if (Cells.ContainsKey(cellName))
        {
            return true;
        }
        return false;
    }
    internal bool HasNoCellWithName(string? cellName)
    {
        return !HasCellWithName(cellName);
    }


    internal void DestroyShipInTargetCell(string targetCell)
    {
        var cell = Cells[targetCell].Owner!.ShipLocations.Find(x => x.CellName == targetCell);
        Cells[targetCell].Owner.ShipLocations.Remove()
        Cells[targetCell].Owner = null;
    }

    internal void PlaceRandomShip(PlayerModel player)
    {
        for (int i = 0; i <= 2; i++)
        {
            var randomLocation = GetAnUnoccupiedRandonLocationOnBoard();
            Cells[randomLocation].Owner = player;
            System.Console.WriteLine(randomLocation);
        }

    }
    private string GetAnUnoccupiedRandonLocationOnBoard()
    {
        string output;
        string[] letterMap = new string[] { "A", "B", "C", "D", "E", "F" };
        while (true)
        {
            int r1 = Random.Shared.Next(0, 5);
            int r2 = Random.Shared.Next(1, 6);
            string candidate = letterMap[r1] + r2.ToString();
            if (Cells[candidate].Owner != null) continue;
            output = candidate;
            break;
        }
        return output;
    }

}