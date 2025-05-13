using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ColorGrid/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    public int gridSize = 3;
    public int moveLimit = 8;

    [Tooltip("Total number of tiles = gridSize * gridSize. Use color indexes.")]
    public int[] startingColors;

    public Color[] availableColors;

    [Tooltip("Pattern offsets (e.g., up, down, left, right)")]
    public Vector2Int[] pattern;
}
