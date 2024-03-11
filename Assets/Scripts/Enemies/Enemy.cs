using System;
using UnityEngine;

public class Enemy : Damageable
{
    [field: SerializeField] public FireSpawnPoint FireSpawnPoint { get; private set; }

    public event Action<Enemy> Died;
    
    public override void TakeDamage()
    {
        Died?.Invoke(this);
    }
}
