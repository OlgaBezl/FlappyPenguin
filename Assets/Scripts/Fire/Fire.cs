using System;
using UnityEngine;

public class Fire : IInteractable
{
    private Vector3 _direction;
    private FireCreatorType _creatorType;
    private float _speed;

    public event Action<Fire> Destroied;

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * _direction, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Damageable damageable))
        {
            if(damageable.Type != _creatorType)
            {
                damageable.TakeDamage();
                Destroied?.Invoke(this);
            }
        }
    }

    public void SetParameters(Attacker attacker, FireCreatorType creatorType)
    {
        _direction = attacker.FireDirection.normalized;

        _creatorType = creatorType;
        _speed = attacker.Speed;

        transform.localScale = new Vector3(-_direction.x, transform.localScale.y, transform.localScale.z);
        transform.position = attacker.transform.position;
    }
}