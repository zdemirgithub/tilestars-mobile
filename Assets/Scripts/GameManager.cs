using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GridManager gridManager;
    public Tile[,] tiles;
    public Color[] colors;
    public int gridSize = 3;
    public int maxMoves = 10;
    private int currentMoves = 0;

    private void Awake()
    {
        Instance = this;
        tiles = new Tile[gridSize, gridSize];
    }

    private void Start()
    {
        gridManager.gridSize = gridSize;
        gridManager.CreateGrid(colors);
    }

    public void AffectAdjacent(Vector2Int pos)
    {
        currentMoves++;

        Vector2Int[] dirs = {
            new Vector2Int(1, 0),
            new Vector2Int(-1, 0),
            new Vector2Int(0, 1),
            new Vector2Int(0, -1)
        };

        foreach (var dir in dirs)
        {
            Vector2Int checkPos = pos + dir;
            if (checkPos.x >= 0 && checkPos.y >= 0 && checkPos.x < gridSize && checkPos.y < gridSize)
            {
                tiles[checkPos.x, checkPos.y].RotateColor();
            }
        }
    }

    public void CheckWinCondition()
    {
        int firstColor = tiles[0, 0].colorIndex;

        foreach (var tile in tiles)
        {
            if (tile.colorIndex != firstColor)
                return;
        }

        Debug.Log("🎉 You Win!");
        // Restart or Show UI
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
