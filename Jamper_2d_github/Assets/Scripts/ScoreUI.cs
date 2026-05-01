using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private int _score = 0;

    private void Start()
    {
        UpdateScoreText();
    }

    public void IncreaseScore()
    {
        _score++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = _score.ToString();
    }

    public void EndGame()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        if (_score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", _score);
            PlayerPrefs.Save();
        }
    }

    public int GetScore()
    {
        return _score;
    }
}



