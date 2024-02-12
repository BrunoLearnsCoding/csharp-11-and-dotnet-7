using System.ComponentModel;

namespace Battleship_Class_Library;

internal class BoardCell {
    internal string CellName { get; init; }
    internal PlayerModel? Owner {get; set;}
    internal BoardCell(string cellName)
    {
        CellName = cellName;
    }
    internal bool HasNoOwner => Owner == null;
    internal void SetOwner(PlayerModel player) {
        Owner = player;
    }

}