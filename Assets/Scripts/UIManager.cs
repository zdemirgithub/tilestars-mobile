using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text moveCounterText;
    public GameObject winPanel;
    public GameObject losePanel;

    public void UpdateMoves(int current, int max)
    {
        moveCounterText.text = $"Moves: {current}/{max}";
    }

    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
    }

    public void ShowLosePanel()
    {
        losePanel.SetActive(true);
    }

    public void HidePanels()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    public void OnRestart()
    {
        HidePanels();
        GameManager.Instance.RestartLevel();
    }

    public void OnNextLevel()
    {
        HidePanels();
        GameManager.Instance.NextLevel();
    }
}
