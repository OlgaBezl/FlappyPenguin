using UnityEngine;

public class Container : MonoBehaviour
{
    public void Clear()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
