using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveContoller : MonoBehaviour
{
    [SerializeField] private List<Enemy> _listEnemy;
    [SerializeField] private List<EnemyArcher> _listEnemyArchers;

    private Timer _timer;

    private void Start()
    {
        _timer = FindObjectOfType<Timer>().GetComponent<Timer>();
        _timer.StartGame += StartShoot;
    }

    public void ComeUpAll()
    {
        foreach (var enemy in _listEnemy)
        {
            enemy.ComeUp();
        }
    }

    private void StartShoot()
    {
        foreach (var archers in _listEnemyArchers)
        {
            archers.StartShoot();
        }
    }
}
