using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public enum Color
    {
        Orange,
        Yellow,
        Pink,
        Green
    }

    public Color playerColor;
    public int tileIndex;
}
