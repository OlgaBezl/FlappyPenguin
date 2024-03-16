using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyFireGeneraror : FireGenerator
{
    [SerializeField] private EnemiesPool _enemiesPool;
    private List<Attacker> _spawnPoints;

    private void OnEnable()
    {
        _enemiesPool.Getted += AddSpawnPoints;
        _enemiesPool.Returned += RemoveSpawnPoints;
    }

    private void OnDisable()
    {
        _enemiesPool.Getted -= AddSpawnPoints;
        _enemiesPool.Returned -= RemoveSpawnPoints;
    }

    public override void Reset()
    {
        base.Reset();
        _spawnPoints.Clear();
    }

    private void AddSpawnPoints(Enemy enemy)
    {
        AddSpawnPoint(enemy.FireSpawnPoint);
    }

    private void RemoveSpawnPoints(Enemy enemy)
    {
        RemoveSpawnPoint(enemy.FireSpawnPoint);
    }
    protected void AddSpawnPoint(Attacker spawnPoint)
    {
        if (_spawnPoints == null)
        {
            _spawnPoints = new List<Attacker>();
        }

        _spawnPoints.Add(spawnPoint);
    }

    protected void RemoveSpawnPoint(Attacker spawnPoint)
    {
        if (_spawnPoints == null)
        {
            return;
        }

        if (_spawnPoints.Contains(spawnPoint))
        {
            _spawnPoints.Remove(spawnPoint);
        }
    }


    protected override void PrepareForSpawn()
    {
        foreach (Attacker spawnPoint in _spawnPoints.Where(point => point.enabled))
        {
            Spawn(spawnPoint, FireCreatorType.Enemy);
        }
    }
}
