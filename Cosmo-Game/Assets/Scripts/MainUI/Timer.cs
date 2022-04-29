using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _timeStart = 3f;
    private TextMeshProUGUI _timer;
    private Pause _pause;

    public event Action StartGame;

    private void Start()
    {
        _timer = GetComponent<TextMeshProUGUI>();
        _timer.text = _timeStart.ToString();
        _pause = FindObjectOfType<Pause>().GetComponent<Pause>();
    }

    private void Update()
    {
        if (_timeStart > 0)
        {
            _timeStart -= Time.deltaTime;
            _timer.text = Mathf.Round(_timeStart).ToString();
        }

        if (_timeStart < 1)
        {
            StartGame?.Invoke();
            _pause.CanPlay = true;
            gameObject.SetActive(false);
        }
    }
}
