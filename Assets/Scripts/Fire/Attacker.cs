using UnityEngine;

public class Attacker : MonoBehaviour

{
    [field: SerializeField] public Vector3 FireDirection { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }

}
