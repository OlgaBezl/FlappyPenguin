using System;
using UnityEngine;

public class Fire : IInteractable
{
    [SerializeField] private float _speed = 5f;

    private Vector3 _direction;

    public event Action<Fire> Destroied;

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * _direction, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Damageable damageable))
        {
            damageable.TakeDamage();
            Destroied?.Invoke(this);
        }
    }

    public void SetParameters(FireSpawnPoint attacker)
    {
        _direction = attacker.FireDirection.normalized;
        transform.position = attacker.transform.position;
    }
}