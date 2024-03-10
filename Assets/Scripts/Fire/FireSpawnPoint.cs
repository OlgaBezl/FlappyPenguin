using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawnPoint : MonoBehaviour

{
    [field: SerializeField] public Vector3 FireDirection { get; private set; }
    [field: SerializeField] public FireCreatorType Type { get; private set; }

}
