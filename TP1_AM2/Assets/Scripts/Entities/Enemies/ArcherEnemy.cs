using System.Collections;
using UnityEngine;

public class ArcherEnemy : Enemy
{
    [SerializeField] private EnemyBullet _bulletPrefab;
    [SerializeField] private int _bulletStock = default;

    private bool _canAttack = true;

    private Factory<EnemyBullet> _factory;
    private ObjectPool<EnemyBullet> _pool;

    void Start()
    {
        Reset();
        _currentSpeed = _maxSpeed;

        _factory = new EnemyBulletsFactory(_bulletPrefab);
        _pool = new ObjectPool<EnemyBullet>(_factory.GetObject, EnemyBullet.TurnOn, EnemyBullet.TurnOff, _bulletStock);
    }

    void Update()
    {
        Move(target.transform.position);
        Attack();
    }

    protected override void Attack()
    {
        if (Vector3.Distance(transform.position, target.transform.position) <= _attackDistance)
        {
            _distanceAttack = true;
            ShootPlayer();
        }
        else
        {
            _distanceAttack = false;
        }
    }

    public override void Reset()
    {
        _currentHealth = _maxHealth = EnemyPointer.Archer.maxHealth;
        _maxSpeed = EnemyPointer.Archer.speed;
        _velocity = EnemyPointer.Archer.direction * _maxSpeed;
        _damage = EnemyPointer.Archer.damage;
        _distanceAttack = false;
        _attackDistance = 15f;
        _isDead = false;
    }

    private void ShootPlayer()
    {

        if (_canAttack)
        {
            StartCoroutine(ShootCooldown(1f));

            var b = _pool.GetObject();

            if (!b) return;

            b.pool = _pool;
            b.transform.position = transform.position;
            //b.transform.rotation = Quaternion.Euler(new Vector3(90f, 0f, 0f));
            b.transform.forward = transform.forward;
            b.SetAttributes();
        }
    }

    private IEnumerator ShootCooldown(float cooldown)
    {
        _canAttack = false;
        yield return new WaitForSecondsRealtime(cooldown);
        _canAttack = true;
    }
}
