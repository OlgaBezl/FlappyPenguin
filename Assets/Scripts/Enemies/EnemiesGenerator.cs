using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesGenerator : Generator
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private EnemiesPool _enemiesPool;

    public override void StartGeneration()
    {
        StartCoroutine(GeneratePipes());
    }

    public override void Reset()
    {
        _enemiesPool.Reset();
    }

    private IEnumerator GeneratePipes()
    {
        var wait = new WaitForSeconds(_delay);

        while (IsActive)
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        Enemy enemy = _enemiesPool.GetObject();
        enemy.transform.position = spawnPoint;
    }
}
