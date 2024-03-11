using UnityEngine;

public class EnemiesRemover : ObjectRemover
{
    [SerializeField] private EnemiesPool _enemiesPool;
    [SerializeField] private FirePool _firePool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            _enemiesPool.AddObject(enemy);
        }
        else if (collision.TryGetComponent(out Fire fire))
        {
            _firePool.AddObject(fire);
        }
    }
}
