using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(PlayerCollisionHandler))]
public class Player : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private PlayerCollisionHandler _handler;

    public event Action GameOver;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _handler = GetComponent<PlayerCollisionHandler>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _mover.Reset();
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if(interactable is Ground)
        {
            GameOver?.Invoke();
        }
        else if (interactable is Fire fire && fire.CreatorType == FireCreatorType.Enemy)
        {
            GameOver?.Invoke();
        }
    }
}
