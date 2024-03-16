using UnityEngine;

public abstract class Generator : MonoBehaviour
{
    protected bool IsActive { get; private set; }
    private Coroutine _coroutine;

    public void SetActive(bool isActive)
    {
        IsActive = isActive;

        if (IsActive)
        {
            _coroutine = StartGeneration();
        }
        else
        {
            StopCoroutine(_coroutine);
            Reset();
        }
    }

    public abstract Coroutine StartGeneration();
    public abstract void Reset();
}
