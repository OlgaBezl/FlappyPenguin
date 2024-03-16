using UnityEngine;

public abstract class Damageable: MonoBehaviour
{
    public FireCreatorType Type { get; protected set; }
    public abstract void TakeDamage();
}
