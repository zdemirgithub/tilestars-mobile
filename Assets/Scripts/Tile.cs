using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public Image tileImage;
    public int colorIndex = 0;
    public Color[] colors;
    public Vector2Int gridPos;

    public void Initialize(Vector2Int pos, Color[] colorSet)
    {
        gridPos = pos;
        colors = colorSet;
        colorIndex = Random.Range(0, colors.Length);
        UpdateColor();
    }

    public void OnClick()
    {
        RotateColor();
        GameManager.Instance.AffectAdjacent(gridPos);
        GameManager.Instance.CheckWinCondition();
    }

    public void RotateColor()
    {
        colorIndex = (colorIndex + 1) % colors.Length;
        UpdateColor();
    }

    public void UpdateColor()
    {
        tileImage.color = colors[colorIndex];
    }
}
