using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _speed;
    [SerializeField] private float _forceWeapon;
    [SerializeField] private float _scorePoints;

    private Pause _pause;
    private PoolUse _poolUse;
    private EnemyWaveContoller _enemyWaveContoller;
    private Score _score;

    private void Start()
    {
        _pause = FindObjectOfType<Pause>().GetComponent<Pause>();
        _poolUse = FindObjectOfType<PoolUse>().GetComponent<PoolUse>();
        _enemyWaveContoller = FindObjectOfType<EnemyWaveContoller>().GetComponent<EnemyWaveContoller>();
        _score = FindObjectOfType<Score>().GetComponent<Score>();
    }
    private void GetDamage()
    {
        if (_health > 1)
        {
            _health -= 1;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Shoot()
    {
        _poolUse.CreateEnemyWeapon(transform ,_forceWeapon);
    }
    private void Walk()
    {
        if (_pause.CanPlay == true)
        {
            transform.position += new Vector3(_speed, 0, 0) * Time.deltaTime;
        }
    }

    public void ComeUp()
    {
        transform.position += new Vector3(0f, -1f, 0);
        _speed += 0.5f;
        _speed = -_speed;
    }
    private void Update()
    {
        Walk();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Wall>() != null)
        {
            _enemyWaveContoller.ComeUpAll();
        }

        if (col.GetComponent<WeaponPlayer>() != null)
        {
            GetDamage();
        }
    }

    private void OnDisable()
    {
        _score.UpdateScore(_scorePoints);
    }
}
