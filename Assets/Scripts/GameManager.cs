using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool _gameActive = true;
    public Board board;
    public Player[] players;
    public GameObject tilePrefab;

    private int _playerTurn = 0;
    private int _round = 1;
   
    // Awake is called when the game runs
    void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        
        GameManager.instance = this;
    }

    void Start()
    {
        for(int i = 0; i < board.tiles.Length; i++)
        {
            GameObject newTile = Instantiate(tilePrefab);
            
            TextMesh textMesh = newTile.GetComponentInChildren<TextMesh>();
            textMesh.text = (i+1).ToString("00");

            int row = i/10;
            int col = i%10;

            newTile.name = "Tile" + i + "Row" + row + "Col" + col;

            if((row) == 0)
            {
                newTile.transform.position = new Vector3(col*14, 0, row*14);
            }
        
            else
            {
                newTile.transform.position = new Vector3((9-(col))*14, 0, row*14);
            }
        }
    }

    public void TakeTurn()
    {
        int dieRoll = RollDie();
        Debug.Log("Player " + (this._playerTurn + 1) + " rolls " + dieRoll);

        Player currentPlayer = this.players[this._playerTurn];

        currentPlayer.tileIndex += dieRoll;

        //Check the tile for chute or ladder
        Tile destinationTile = this.board.tiles[currentPlayer.tileIndex];

        if(destinationTile.moveEvent == true)
        {
            currentPlayer.tileIndex = destinationTile.endTile;
        }

        if(currentPlayer.tileIndex >= this.board.tiles.Length)
        {
            currentPlayer.tileIndex = this.board.tiles.Length;
            this._gameActive = false;
            Debug.Log("Player " + (this._playerTurn +1) + " wins");
            return;
        }

        this._playerTurn++;
       
       if(this._playerTurn >= this.players.Length)
       {
           this._playerTurn = 0;
           this._round++;
       }
    }

    public int RollDie()
    {
        return Random.Range(1, 6);
    }
}
