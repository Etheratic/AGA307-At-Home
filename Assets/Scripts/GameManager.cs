using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public enum GameState
{
    Title, Playing, Paused, GameOver
}

public enum Difficulty
{
    easy, normal, hard
}

public class GameManager : Singleton <GameManager> 
{
    public int score = 0;
    int scoreMultiplier = 1;
    public float timer;
    public GameState gameState;
    public Difficulty difficulty;



    private void Start()
    {
        
        switch (difficulty)
        {
            case Difficulty.easy:
                scoreMultiplier = 1;
                _UI.UpdateDifficulty("easy");
                break;
            case Difficulty.normal:
                scoreMultiplier = 2;
                _UI.UpdateDifficulty("normal");
                break;
            case Difficulty.hard:
                scoreMultiplier = 3;
                _UI.UpdateDifficulty("hard");
                break;
        }
       
    }
    public void AddScore(int _points)
    {
       
            
        score += _points * scoreMultiplier;
        _UI.UpdateScore(score);
    }

    private void OnEnemyHit(GameObject _enemy)
    {
        AddScore(score);
        print("hit");

    }

    private void OnEnable()
    {
        Projectile.OnEnemyHit += OnEnemyHit;

    }

    private void OnDisable()
    {
        Projectile.OnEnemyHit -= OnEnemyHit;
    }
}
