using System;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;
    private float _score = 0f;

    private void Start()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
        _scoreText.text = _score.ToString();
    }

    public void UpdateScore(float AddPoints)
    {
        _score += AddPoints;
        _scoreText.text = _score.ToString();
    }
}
