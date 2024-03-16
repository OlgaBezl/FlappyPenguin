using System.Collections.Generic;
using UnityEngine;

public class FirePool : ObjectPool
{
    [SerializeField] protected Fire _prefab;

    private Queue<Fire> _pool;

    public IEnumerable<Fire> PoolObjects => _pool;

    private void Awake()
    {
        _pool = new Queue<Fire>();
    }

    private void OnDisable()
    {
        foreach (Fire fire in _pool)
        {
            fire.Destroied -= AddObject;
        }
    }

    public override void Reset()
    {
        OnDisable();
        _pool.Clear();
    }

    public Fire GetObject()
    {
        if (_pool.Count == 0)
        {
            Fire newFire = Instantiate(_prefab);
            newFire.transform.parent = Container;
            newFire.Destroied += AddObject;

            return newFire;
        }

        Fire fire = _pool.Dequeue();
        fire.gameObject.SetActive(true);

        return fire;
    }

    public void AddObject(Fire fire)
    {
        _pool.Enqueue(fire);
        fire.gameObject.SetActive(false);
    }
}
