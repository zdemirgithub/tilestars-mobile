using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public Image tileImage;
    public int colorIndex;
    public Color[] colors;
    public Vector2Int gridPosition;

    public void Initialize(Color[] colorSet, int startIndex, Vector2Int position)
    {
        colors = colorSet;
        colorIndex = startIndex;
        gridPosition = position;
        UpdateColor();
    }

    public void OnClick()
    {
        GameManager.Instance.OnTileClicked(gridPosition);
    }

    public void RotateColor()
    {
        colorIndex = (colorIndex + 1) % colors.Length;
        UpdateColor();
    }

    public void SetColorIndex(int index)
    {
        colorIndex = index;
        UpdateColor();
    }

    public void UpdateColor()
    {
        tileImage.color = colors[colorIndex];
    }
}

