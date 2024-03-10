using UnityEngine;

public class PlayerFireGenerator : FireGenerator
{
    [SerializeField] private FireSpawnPoint _spawnPoint;

    public override void StartGeneration()
    {
        AddSpawnPoint(_spawnPoint);
        base.StartGeneration();
    }
}
