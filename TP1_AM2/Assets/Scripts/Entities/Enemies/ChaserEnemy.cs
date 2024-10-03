using UnityEngine;

public class ChaserEnemy : Enemy
{
    private bool _isAttacking = default;

    void Start()
    {
        Reset();
        _currentSpeed = _maxSpeed;
    }

    void Update()
    {
        if (!_isAttacking) Move(target.transform.position);

        Attack();
    }

    protected override void Attack()
    {
        if (Vector3.Distance(transform.position, target.transform.position) <= _attackDistance)
        {
            _isAttacking = true;

            target.TakeDamage(_damage);
        }
        else _isAttacking = false;
    }

    public override void Reset()
    {
        _currentHealth = _maxHealth = EnemyPointer.Chaser.maxHealth;
        _maxSpeed = EnemyPointer.Chaser.speed;
        _velocity = EnemyPointer.Chaser.direction * _maxSpeed;
        _damage = EnemyPointer.Chaser.damage;
        _attackDistance = 2f;
        _isAttacking = false;
        _distanceAttack = false;
        _isDead = false;
    }
}
