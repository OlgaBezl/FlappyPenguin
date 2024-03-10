using UnityEngine;

public abstract class Generator : MonoBehaviour
{
    protected bool IsActive { get; private set; }

    public void SetActive(bool isActive)
    {
        IsActive = isActive;

        if (IsActive)
        {
            StartGeneration();
        }
        else
        {
            Reset();
        }
    }

    public abstract void StartGeneration();
    public abstract void Reset();
}
