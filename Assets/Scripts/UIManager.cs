using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager> 
{
    public TMP_Text scoreText;
    public TMP_Text difficultyText;
    public TMP_Text targetsLeftText;
    public TMP_Text timerText;

    private void Start()
    {
        UpdateScore(0);
        UpdateTarget(0);
        UpdateDifficulty(0);
    }

    public void UpdateScore(int _score)
    {
        scoreText.text = "score: " + _score;
    }

    public void UpdateDifficulty(int _difficultyLevel)
    {
        difficultyText.text = "Difficulty: " + _difficultyLevel;
            
    }

    public void UpdateTarget(int _targetCount)
    {
        targetsLeftText.text = "remaining targets: " + _targetCount;
    
    }

    public void UpdateTime(float _time)
    {
        timerText.text = _time.ToString("F2");
    }
}
