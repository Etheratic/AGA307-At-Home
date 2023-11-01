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

    private void Start()
    {
        UpdateScore(0);
        UpdateTarget(0);
    }

    public void UpdateScore(int _score)
    {
        scoreText.text = "score: " + _score;
    }

    public void UpdateDifficulty(string _difficulty)
    {
        difficultyText.text = _difficulty;
    }

    public void UpdateTarget(int _targetCount)
    {
        targetsLeftText.text = "remaining targets: " + _targetCount;
    
    }
}
