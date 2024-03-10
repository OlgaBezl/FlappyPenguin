using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private List<Generator> _generators;
    [SerializeField] private List<Container> _containers;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;

    private void Awake()
    {
        Time.timeScale = 0f;
    }

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClicked;
        _endScreen.RestartButtonClicked += OnRestartButtonClicked;
        _player.GameOver += StopGame;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClicked;
        _endScreen.RestartButtonClicked -= OnRestartButtonClicked;
        _player.GameOver -= StopGame;
    }

    private void OnPlayButtonClicked()
    {
        StartGame();
    }

    private void OnRestartButtonClicked()
    {
        StartGame();
    }

    private void StartGame()
    {
        _startScreen.Close();
        _endScreen.Close();
        _player.Reset();
        _containers.ForEach(container => container.Clear());
        _generators.ForEach(generator => generator.SetActive(true));

        Time.timeScale = 1f;
    }

    private void StopGame()
    {
        Time.timeScale = 0f;
        _generators.ForEach(generator => generator.SetActive(false));
        _endScreen.Open();
    }
}
