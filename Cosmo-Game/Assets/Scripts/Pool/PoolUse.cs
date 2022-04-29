using UnityEngine;

public class PoolUse : MonoBehaviour
{
    [SerializeField] private int _playerWeaponCount;
    [SerializeField] private int _enemyWeaponCount;
    [SerializeField] private bool _autoExpand;
    [SerializeField] private WeaponEnemy _weaponEnemy;
    [SerializeField] private WeaponPlayer _weaponPlayer;

    private PoolMono<WeaponEnemy> _poolWeaponEnemy;
    private PoolMono<WeaponPlayer> _poolWeaponPlayer;

    private void Awake()
    {
        CreatePoolEnemyWeapon();
        CreatePoolPlayerWeapon();
    }

    private void CreatePoolEnemyWeapon()
    {
        this._poolWeaponEnemy = new PoolMono<WeaponEnemy>(this._weaponEnemy, this._enemyWeaponCount, this.transform);
        this._poolWeaponEnemy.AutoExpand = this._autoExpand;
    }
    private void CreatePoolPlayerWeapon()
    {
        this._poolWeaponPlayer = new PoolMono<WeaponPlayer>(this._weaponPlayer, this._playerWeaponCount, this.transform);
        this._poolWeaponPlayer.AutoExpand = this._autoExpand;
    }

    public void CreatePlayerWeapon(Transform PlayerPosition, float ForceBullet)
    {
        var enemyWeapon = _poolWeaponPlayer.GetFreeElement();
        enemyWeapon.transform.position = PlayerPosition.position;
        enemyWeapon.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,ForceBullet));
    }

    public void CreateEnemyWeapon(Transform EnemyPosition , float ForceBullet)
    {
        var playerWeapon = _poolWeaponEnemy.GetFreeElement();
        playerWeapon.transform.position = EnemyPosition.position;
        playerWeapon.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -ForceBullet));
    }
}
