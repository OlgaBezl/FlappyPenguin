using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesPool : ObjectPool
{
    [SerializeField] protected Enemy _prefab;

    private Queue<Enemy> _pool;

    public event Action<Enemy> AddedNew;
    public event Action EnemyDied;

    public IEnumerable<Enemy> PoolObjects => _pool;

    private void Awake()
    {
        _pool = new Queue<Enemy>();
    }

    private void OnDisable()
    {
        foreach (Enemy enemy in _pool)
        {
            enemy.Died -= RecordEnemyDeath;
        }
    }

    public override void Reset()
    {
        OnDisable();
        _pool.Clear();
    }

    public Enemy GetObject()
    {
        if (_pool.Count == 0)
        {
            Enemy newEnemy = Instantiate(_prefab);
            newEnemy.transform.parent = Container;
            newEnemy.Died += RecordEnemyDeath;
            AddedNew?.Invoke(newEnemy);

            return newEnemy;
        }

        Enemy enemy = _pool.Dequeue();
        enemy.gameObject.SetActive(true);

        return enemy;
    }

    public void AddObject(Enemy enemy)
    {
        _pool.Enqueue(enemy);
        enemy.gameObject.SetActive(false);
    }

    private void RecordEnemyDeath(Enemy enemy)
    {
        AddObject(enemy);
        EnemyDied?.Invoke();
    }
}
