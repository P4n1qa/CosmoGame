using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MotherShipTimer : MonoBehaviour
{
    [SerializeField] private float _timeSpawnMotherShip;
    [SerializeField] private List<Transform> _listSpawnPoint;
    [SerializeField] private GameObject _motherShip;

    private float _currTime;
    private Pause _pause;

    private void Start()
    {
        _currTime = _timeSpawnMotherShip;
        _pause = FindObjectOfType<Pause>().GetComponent<Pause>();
    }

    private void Update()
    {
        if (_pause.CanPlay == true)
        {
            Timer();
        }
    }

    private void Timer()
    {
        _currTime -= Time.deltaTime;
        if (_currTime <= 0)
        {
            _currTime = _timeSpawnMotherShip;
            RandomSpawn();
        }
    }

    private void RandomSpawn()
    {
        var i = Random.Range(0, 9);
        if (i > 3)
        {
            SpawnShip();
        }
    }
    private void SpawnShip()
    {
        var spawnPoint = _listSpawnPoint[Random.Range(0, _listSpawnPoint.Count)];
        GameObject newMotherShip = Instantiate(_motherShip, spawnPoint.position, Quaternion.identity, transform);
    }
}
