using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public GameObject winPanel;
    public int totalCoins = 10;

    private int score = 0;

    private void Start()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }

        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        score = score + amount;
        UpdateScoreUI();

        if (score >= totalCoins)
        {
            ClearGame();
        }
    }

    public void ClearGame()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}/{totalCoins}";
        }
    }
}
