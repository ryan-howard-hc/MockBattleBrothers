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
    {
        CreateGameBoard();
        PlacePlayerUnits();
    }

    void CreateGameBoard()
    {
        tiles = new GameObject[boardWidth, boardHeight];

        for (int x = 0; x < boardWidth; x++)
        {
            for (int y = 0; y < boardHeight; y++)
            {
                GameObject tile = Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity);
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