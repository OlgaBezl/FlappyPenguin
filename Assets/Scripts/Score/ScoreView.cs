using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _maxScoreText;

    private void OnEnable()
    {
        _scoreCounter.ScoreChanged += OnScoreChanged;
        _scoreCounter.MaxScoreChanged += OnMaxScoreChanged;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreChanged -= OnScoreChanged;
        _scoreCounter.MaxScoreChanged -= OnMaxScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _scoreText.text = score.ToString();
    }

    private void OnMaxScoreChanged(int score)
    {
        _maxScoreText.text = $"Ваш лучший счет: {score}";
    }
}
