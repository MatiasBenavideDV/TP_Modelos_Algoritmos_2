using System.Collections;
using UnityEngine;

public class KamikazeEnemy : Enemy
{
    [SerializeField] private float _poolReturnCooldown = default, _aproachDistance = default;
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private LayerMask _playerMask;

    private KamikazeExplosion _explosion;

    private bool _isAttacking = default;

    void Start()
    {
        Reset();
        _explosion = _explosionPrefab.GetComponent<KamikazeExplosion>();
        _currentSpeed = _maxSpeed;
    }

    void Update()
    {
        if (!_isAttacking) Move(target.transform.position);

        Attack();
    }

    protected override void Attack()
    {
        if (Vector3.Distance(transform.position, target.transform.position) <= _aproachDistance)
        {
            _maxSpeed = _currentSpeed * 2;

            if (Vector3.Distance(transform.position, target.transform.position) <= _attackDistance)
            {
                _isAttacking = true;

                _explosion.target = target;
            
                Instantiate(_explosionPrefab, transform.position, transform.rotation);

                StartCoroutine(WaitToPoolReturn(_poolReturnCooldown));
            }
        }
        else _maxSpeed = _currentSpeed;
    }

    public override void Reset()
    {
        _currentHealth = _maxHealth = EnemyPointer.Kamikaze.maxHealth;
        _maxSpeed = EnemyPointer.Kamikaze.speed;
        _velocity = EnemyPointer.Kamikaze.direction * _maxSpeed;
        _damage = EnemyPointer.Kamikaze.damage;
        _attackDistance = 2f;
        _aproachDistance = 10f;
        _poolReturnCooldown = .5f;
        _isAttacking = false;
        _distanceAttack = false;
        _isDead = false;
    }

    private IEnumerator WaitToPoolReturn(float waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime);

        pool.ReturnObject(this);
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 rayAproach = transform.position + transform.forward * 0.3f;
        Gizmos.DrawLine(rayAproach, rayAproach + transform.forward * _aproachDistance);

        Gizmos.color = Color.green;
        Vector3 rayAttack = transform.position + transform.forward * 0.3f;
        Gizmos.DrawLine(rayAttack, rayAttack + transform.forward * _attackDistance);
    }
}
