using System;
using UnityEngine;

public class Enemy : Damageable
{
    [field: SerializeField] public Attacker FireSpawnPoint { get; private set; }

    public event Action<Enemy> Died;

    private void Awake()
    {
        Type = FireCreatorType.Enemy;
    }

    public override void TakeDamage()
    {
        Died?.Invoke(this);
    }
}
