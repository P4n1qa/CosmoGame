using System.Collections;
using UnityEngine;

public class EnemyArcher : Enemy
{
    [SerializeField] private float _duractionShot;

    public void StartShoot()
    {
        StartCoroutine(CR_StartShoot());
    }

    public IEnumerator CR_StartShoot()
    {
        yield return new WaitForSeconds(_duractionShot);
        Shoot();
        StartCoroutine(CR_StartShoot());
    }
}
