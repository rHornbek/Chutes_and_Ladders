using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public enum Color //A list of player colors, used to differentiate each of the players
    {
        Orange,
        Yellow,
        Pink,
        Green
    }

    public Color playerColor; //Sets the Player Color vaiable
    public int tileIndex; //Sets the variable used to determine the unique position of the tile (space)

    public Material material; //A variable that allows us to dynamically set different colors to each player
    public Pawn pawnReference; //A variable used to spawn the Pawn asset
}
