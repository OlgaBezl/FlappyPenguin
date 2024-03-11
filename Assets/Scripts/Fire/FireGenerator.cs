using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class FireGenerator : Generator
{
    [SerializeField] private float _delay;
    [SerializeField] private FirePool _firePool;       

    private List<FireSpawnPoint> _spawnPoints;

    public override void StartGeneration()
    {
        StartCoroutine(GeneratePipes());
    }

    public override void Reset()
    {
        _spawnPoints.Clear();
        _firePool.Reset();
    }

    protected void AddSpawnPoint(FireSpawnPoint spawnPoint)
    {
        if(_spawnPoints == null)
        {
            _spawnPoints = new List<FireSpawnPoint>();
        }

        _spawnPoints.Add(spawnPoint);
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
        foreach (FireSpawnPoint spawnPoint in _spawnPoints.Where(point => point.enabled))
        {
            Fire fire = _firePool.GetObject();
            fire.SetParameters(spawnPoint);
        }
    }
}
