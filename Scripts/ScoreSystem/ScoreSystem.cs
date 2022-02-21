using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public TMP_Text scoreText;

    public int currentScore;

    string scoreKey = "Score";

    private void Awake()
    {
        currentScore = PlayerPrefs.GetInt("Score");
    }
    private void Start()
    {
        if (scoreText != null)
            scoreText.text = currentScore + "";
    }
    public void SetScore(int score)
    {
        PlayerPrefs.SetInt("Score", score);
    }
}
