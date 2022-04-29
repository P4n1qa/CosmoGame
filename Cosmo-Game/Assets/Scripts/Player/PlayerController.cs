using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private float _speed;
   [SerializeField] private float _forceWeapon;
   
   private Pause _pause;
   private PoolUse _poolUse;

   private int _directionInput;
   public float Health;
   
   public event Action GetDamaged;

   private void Start()
   {
      _pause = FindObjectOfType<Pause>().GetComponent<Pause>();
      _poolUse = FindObjectOfType<PoolUse>().GetComponent<PoolUse>();
   }

   private void Shoot()
   {
      _poolUse.CreatePlayerWeapon(transform , _forceWeapon);
   }
   public void GetDamage()
   {
      Health -= 1;
      GetDamaged?.Invoke();
   }

   public void Move(int InputAxis)
   {
      _directionInput = InputAxis;
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space) && _pause.CanPlay == true)
      {
         Shoot();
      }
   }

   private void FixedUpdate()
   {
      if (_pause.CanPlay == true)
      {
         transform.position += new Vector3(_speed * _directionInput, 0, 0) * Time.deltaTime;
      }
   }

   private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.GetComponent<Enemy>() != null)
      {
         Destroy(gameObject);
      }
      if (col.GetComponent<WeaponEnemy>() != null)
      {
         GetDamage();
      }
   }
}
