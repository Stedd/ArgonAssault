using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    TMP_Text scoreText;

    int score;

    private void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        UpdateScoreText(score);
    }

    public void UpdateScore(int _amount)
    {
        score += _amount;
        UpdateScoreText(score);
    }

    private void UpdateScoreText(int _score)
    {
        scoreText.text = $"Score: {score}";
    }
}
