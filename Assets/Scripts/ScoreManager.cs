using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI leftPlayerScoreText;
    public TextMeshProUGUI rightPlayerScoreText;

    private int leftScore = 0;
    private int rightScore = 0;

    private void Start()
    {
        UpdateScoreUI();
    }

    public void AddPointToLeft()
    {
        leftScore++;
        UpdateScoreUI();
    }

    public void AddPointToRight()
    {
        rightScore++;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (leftPlayerScoreText != null)
            leftPlayerScoreText.text = leftScore.ToString();

        if (rightPlayerScoreText != null)
            rightPlayerScoreText.text = rightScore.ToString();
    }
}
