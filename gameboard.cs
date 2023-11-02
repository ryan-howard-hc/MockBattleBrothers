using UnityEngine;

public class GameBoard : MonoBehaviour
//  In Unity, all scripts that interact with game objects must inherit from MonoBehaviour..
{
    public int boardWidth = 50;
    public int boardHeight = 40;
    public GameObject tilePrefab; 
    public GameObject playerUnitPrefab; 

    private GameObject[,] tiles; // 2D array to store references to the tiles

    void Start()
    //special Unity method that is automatically called when the script starts running..
    {
        CreateGameBoard();
        PlacePlayerUnits();
    }

    void CreateGameBoard()
    //CreateGameBoard() method, which is responsible for creating the grid of tiles..
    {
        tiles = new GameObject[boardWidth, boardHeight];

        for (int x = 0; x < boardWidth; x++)
        {
            for (int y = 0; y < boardHeight; y++)
            {
                //nested loop, iterating through the x and y coordinates to cover the entire grid...


                GameObject tile = Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity);
                // Instantiate function is used to create copies of prefabs in Unitty
                // the '0' in the Z-axis indicates that the object will be placed on the 2D plane with a Z-coordinate of 0..
                tile.transform.parent = transform; // Make the tile a child of the GameBoard GameObject?

                tiles[x, y] = tile; // store the reference to the tile
            }
        }
    }

    void PlacePlayerUnits()
    {
        // temp example of player on center tile

        int centerX = boardWidth / 2;
        int centerY = boardHeight / 2;
        Instantiate(playerUnitPrefab, new Vector3(centerX, centerY, 0), Quaternion.identity);
    }
}