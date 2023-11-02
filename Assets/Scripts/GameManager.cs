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
    
    public GameState gameState;
    public Difficulty difficulty;



    private void Start()
    {
        
        switch (difficulty)
        {
            case Difficulty.easy:
                scoreMultiplier = 1;
                _UI.UpdateDifficulty(1);
                break;
            case Difficulty.normal:
                scoreMultiplier = 2;
                _UI.UpdateDifficulty(2);
                break;
            case Difficulty.hard:
                scoreMultiplier = 3;
                _UI.UpdateDifficulty(3);
                break;
        }
       
    }

    public void ChangeGameState(GameState _gameState)
    {

    }

    public void ChangeDifficulty(int _difficulty) 
    { 
        difficulty = (Difficulty) _difficulty;
       
    
    }

    public void AddScore(int _points)
    {                   
        score += _points * scoreMultiplier;
        _UI.UpdateScore(score);
    }

    private void OnTargetHit(GameObject _target)
    {
        int _score = _target.GetComponent<Target>().myScore;
        //AddScore(1);
        //print("hit");

    }

    private void OnEnable()
    {
        Target.OnTargetHit += OnTargetHit;
        Target.OnTargetDie += OnTargetHit;


    }

    private void OnDisable()
    {
        Target.OnTargetHit -= OnTargetHit;
        Target.OnTargetDie -= OnTargetHit;
    }
}
