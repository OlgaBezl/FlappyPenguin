using UnityEngine;

public class PlayerFireGenerator : FireGenerator
{
    [SerializeField] private Attacker _spawnPoint;

    private bool _isReady;

    private void Update()
    {
        if (_isReady)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                Spawn(_spawnPoint, FireCreatorType.Player);
                _isReady = false;
            }
        }
    }

    protected override void PrepareForSpawn()
    {
        _isReady = true;
    }
}
