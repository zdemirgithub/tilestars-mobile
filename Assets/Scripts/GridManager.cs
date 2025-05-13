using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public Transform tileParent;
    public int gridSize = 3;

    public void CreateGrid(Color[] colorSet)
    {
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                GameObject tileObj = Instantiate(tilePrefab, tileParent);
                Tile tile = tileObj.GetComponent<Tile>();
                tile.Initialize(new Vector2Int(x, y), colorSet);
                GameManager.Instance.tiles[x, y] = tile;
            }
        }
    }
}
