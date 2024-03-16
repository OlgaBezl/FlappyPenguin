using System.Collections;
using UnityEngine;

public abstract class FireGenerator : Generator
{
    [SerializeField] private float _delay;
    [SerializeField] private FirePool _firePool;

    public override Coroutine StartGeneration()
    {
        return StartCoroutine(GenerateFire());
    }

    protected abstract void PrepareForSpawn();

    protected void Spawn(Attacker spawnPoint, FireCreatorType creatorType)
    {
        Fire fire = _firePool.GetObject();
        fire.SetParameters(spawnPoint, creatorType);
    }

    public override void Reset()
    {
        _firePool.Reset();
    }

    private IEnumerator GenerateFire()
    {
        var wait = new WaitForSeconds(_delay);

        while (IsActive)
        {
            PrepareForSpawn();
            yield return wait;
        }
    }
}
