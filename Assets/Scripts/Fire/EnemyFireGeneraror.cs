using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireGeneraror : FireGenerator
{
    [SerializeField] private EnemiesPool _enemiesPool;

    private void OnEnable()
    {
        _enemiesPool.AddedNew += UpdateSpawnPoints;
    }

    private void OnDisable()
    {
        _enemiesPool.AddedNew -= UpdateSpawnPoints;
    }

    private void UpdateSpawnPoints(Enemy enemy)
    {
        AddSpawnPoint(enemy.FireSpawnPoint);
    }
}
