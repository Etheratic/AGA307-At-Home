using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton <GameManager> 
{
    public int score = 0;
    int scoreMultiplier = 1;
    public float timer;

    public void AddScore(int _points)
    {
        score += _points * scoreMultiplier;
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
