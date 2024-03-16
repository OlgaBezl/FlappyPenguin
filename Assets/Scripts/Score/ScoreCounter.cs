using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private EnemiesPool _enemiesPool;

    private int _score;
    private int _maxScore;

    public event Action<int> ScoreChanged;
    public event Action<int> MaxScoreChanged;

    private void OnEnable()
    {
        _enemiesPool.EnemyDied += Add;
    }

    private void OnDisable()
    {
        _enemiesPool.EnemyDied -= Add;
    }

    public void Add()
    {
        _score++;
        ScoreChanged?.Invoke(_score);

        if(_score > _maxScore)
        {
            _maxScore = _score;
            MaxScoreChanged?.Invoke(_maxScore);
        }
    }

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }
}
