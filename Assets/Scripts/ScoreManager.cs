using UnityEngine;
using System;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int currentScore;
    [SerializeField] private int highestScore;

    public Action<int> OnScoreChange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highestScore = PlayerPrefs.GetInt("HighScore");
        GameManager.Instance.OnGameEnd += RegisterHighestScore;
    }

    public void AddScore(int toAdd)
    {
        currentScore += toAdd;
        OnScoreChange?.Invoke(currentScore);
    }

    public void RegisterHighestScore()
    {
        if (currentScore > highestScore)
        {
            highestScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highestScore);
        }
    }
}
