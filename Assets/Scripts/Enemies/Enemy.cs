using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field: SerializeField] public FireSpawnPoint FireSpawnPoint { get; private set; }
    [SerializeField] private EnemyCollisionHandler _handler;

    public event Action<Enemy> Died;

    private void OnEnable()
    {
        _handler.CollisionDetected += CollisionWithFire;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= CollisionWithFire;
    }

    private void CollisionWithFire(Fire fire)
    {
        Died?.Invoke(this);
    }
}
