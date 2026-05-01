using TMPro;
using UnityEngine;

public class BestScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScoreText;

    private void Start()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        if (bestScoreText != null)
            bestScoreText.text = "Best: " + bestScore.ToString();
    }
}



