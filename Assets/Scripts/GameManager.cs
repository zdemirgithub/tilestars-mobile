using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GridManager gridManager;
    public UIManager uiManager;
    public LevelData[] levels;
    public Tile[,] tiles;
    public int currentLevelIndex = 0;
    private LevelData currentLevel;
    private int moveCount = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        LoadLevel(currentLevelIndex);
    }

    public void LoadLevel(int index)
    {
        currentLevel = levels[index];
        moveCount = 0;
        uiManager.UpdateMoves(moveCount, currentLevel.moveLimit);
        gridManager.GenerateGrid(currentLevel);
    }

    public void OnTileClicked(Vector2Int pos)
    {
        moveCount++;
        uiManager.UpdateMoves(moveCount, currentLevel.moveLimit);

        ApplyPattern(pos);

        if (CheckWinCondition())
        {
            uiManager.ShowWinPanel();
        }
        else if (moveCount >= currentLevel.moveLimit)
        {
            uiManager.ShowLosePanel();
        }
    }

    private void ApplyPattern(Vector2Int pos)
    {
        Vector2Int[] pattern = currentLevel.pattern;

        foreach (Vector2Int offset in pattern)
        {
            Vector2Int target = pos + offset;
            if (target.x >= 0 && target.y >= 0 &&
                target.x < currentLevel.gridSize && target.y < currentLevel.gridSize)
            {
                tiles[target.x, target.y].RotateColor();
            }
        }

        tiles[pos.x, pos.y].RotateColor(); // Also rotate the clicked tile
    }

    private bool CheckWinCondition()
    {
        int targetColor = tiles[0, 0].colorIndex;

        foreach (Tile tile in tiles)
        {
            if (tile.colorIndex != targetColor)
                return false;
        }

        return true;
    }

    public void RestartLevel()
    {
        LoadLevel(currentLevelIndex);
    }

    public void NextLevel()
    {
        currentLevelIndex = (currentLevelIndex + 1) % levels.Length;
        LoadLevel(currentLevelIndex);
    }
}

