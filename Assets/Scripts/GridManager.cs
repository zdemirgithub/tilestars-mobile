using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public Transform gridParent;

    public void GenerateGrid(LevelData levelData)
    {
        foreach (Transform child in gridParent)
        {
            Destroy(child.gameObject);
        }

        GameManager.Instance.tiles = new Tile[levelData.gridSize, levelData.gridSize];

        for (int x = 0; x < levelData.gridSize; x++)
        {
            for (int y = 0; y < levelData.gridSize; y++)
            {
                GameObject tileObj = Instantiate(tilePrefab, gridParent);
                Tile tile = tileObj.GetComponent<Tile>();

                Vector2Int pos = new Vector2Int(x, y);
                int colorIndex = levelData.startingColors[x + y * levelData.gridSize];

                tile.Initialize(levelData.availableColors, colorIndex, pos);
                tileObj.GetComponent<Button>().
