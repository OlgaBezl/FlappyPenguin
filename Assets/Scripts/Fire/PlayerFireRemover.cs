using UnityEngine;

public class PlayerFireRemover : ObjectRemover
{
    [SerializeField] private FirePool _firePool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Fire fire) && fire.CreatorType == FireCreatorType.Player)
        {
            _firePool.AddObject(fire);
        }
    }
}
