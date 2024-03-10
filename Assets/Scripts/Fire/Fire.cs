using System;
using UnityEngine;

public class Fire : IInteractable
{
    [SerializeField] private float _speed = 5f;

    private Vector3 _direction;

    public event Action<Fire> Destroied;

    public FireCreatorType CreatorType { get; private set; }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * _direction, Space.World);
    }

    public void Destroy()
    {
        Destroied?.Invoke(this);
    }

    public void SetParameters(FireSpawnPoint attacker)
    {
        _direction = attacker.FireDirection.normalized;
        CreatorType = attacker.Type;
        transform.position = attacker.transform.position;
    }
}