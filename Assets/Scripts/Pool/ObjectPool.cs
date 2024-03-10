using UnityEngine;

public abstract class ObjectPool : MonoBehaviour
{
    [SerializeField] protected Transform Container;

    public abstract void Reset();
}
