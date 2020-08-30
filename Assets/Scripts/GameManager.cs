using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool _gameActive = true; //Variable determines if the game is ready to play
    public Board board;
    public Player[] players; //Array that tracks all of the players
    public GameObject tilePrefab; //Variable that represents the Tile prefab
    public Pawn pawnPrefab; //Variable that represents the Pawn prefab

    private int _playerTurn = 0; //Variable used to count the player's turns
    private int _round = 1; //Variabkle used to count the rounds
   
    // Awake is called when the game runs
    void Awake()
    {
        if(GameManager.instance != null) //Clears the game when it is restarted
        {
            Destroy(this.gameObject);
            return;
        }
        
        GameManager.instance = this;
    }

    void Start()
    {
        for(int i = 0; i < board.tiles.Length; i++) //Builds the board based on the number of tiles
        {
            GameObject newTile = Instantiate(tilePrefab);
            
            board.tiles[i].transform = newTile.transform;

            TextMesh textMesh = newTile.GetComponentInChildren<TextMesh>();
            textMesh.text = (i+1).ToString("00");

            int row = i/10;
            int col = i%10;

            newTile.name = "Tile" + i + "Row" + row + "Col" + col;

            if((row%2) == 0)
            {
                newTile.transform.position = new Vector3(col*14, 0, row*14);
            }
        
            else
            {
                newTile.transform.position = new Vector3((9-(col))*14, 0, row*14);
            }
        }

        for(int i = 0; i < players.Length; i++)
        {
            Pawn pawn = Instantiate(pawnPrefab);
            pawn.meshRenderer.material = players[i].material;
            players[i].pawnReference = pawn;
        }
    }

    public void TakeTurn() //How the turn works
    {
        int dieRoll = RollDie();
        Debug.Log("Player " + (this._playerTurn + 1) + " rolls " + dieRoll);

        Player currentPlayer = this.players[this._playerTurn];

        int currentLoc = currentPlayer.tileIndex;

        currentPlayer.tileIndex += dieRoll;

        //Check the tile for chute or ladder
        Tile destinationTile = this.board.tiles[currentPlayer.tileIndex];

        Tile startTile = this.board.tiles[currentLoc];

        currentPlayer.pawnReference.Movement(startTile.transform.position, destinationTile.transform.position);

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

    public int RollDie() //Function that provides a 1d6 result
    {
        return Random.Range(1, 6);
    }
}
