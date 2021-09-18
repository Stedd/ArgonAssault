using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{

    int score;

    public void UpdateScore(int _amount)
    {
        score += _amount;
        Debug.Log($"Score: {score}");
    }
}
