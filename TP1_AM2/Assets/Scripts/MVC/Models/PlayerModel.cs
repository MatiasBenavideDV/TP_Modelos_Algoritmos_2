using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerModel
{
    private float _maxHealth = default, _currentHealth = default, _speed = default, _currentSpeed = default, _rotationSpeed = default, _turnSpeed = default;

    private float _maxSpeed = 15f;

    private Transform _playerTransform = default;

    private Factory<PlayerBullets> _factory;
    private ObjectPool<PlayerBullets> _pool;

    public Player _player;

    public bool canShoot = true;

    public event Action<float> onGetDamage = delegate { };

    public PlayerModel(float maxHealth, float speed, float rotationSpeed, float turnSpeed, Transform playerTransform, ObjectPool<PlayerBullets> pool, Player player)
    {
        _currentHealth = _maxHealth = maxHealth;
        _currentSpeed = _speed = speed;
        _rotationSpeed = rotationSpeed;
        _playerTransform = playerTransform;
        _pool = pool;
        _player = player;
        _turnSpeed = turnSpeed;
    }

    public void Move(Vector3 moveDir, bool isShooting = false)
    {
        _playerTransform.position += moveDir * _currentSpeed * Time.deltaTime;
        if (isShooting) Rotate(moveDir);
    }

    public void Rotate(Vector3 moveDir)
    {
        _playerTransform.forward = Vector3.Lerp(_playerTransform.forward, moveDir, _currentSpeed * Time.deltaTime);
    }

    //private void Rotate()
    //{
    //    Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(_playerTransform.position);

    //    float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;

    //    _playerTransform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
    //}

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        onGetDamage(_currentHealth / _maxHealth);

        if (_currentHealth <= 0)
        {
            _player.Die();
        }
    }

    public void Heal()
    {
        if (_currentHealth <= _maxHealth)
        {
            _currentHealth += 5f;

            if (_currentHealth > _maxHealth) _currentHealth = _maxHealth;
        }
    }

    public void BuffSpeed()
    {
        if (_currentSpeed < _maxSpeed)
            _currentSpeed = _speed * 1.05f;
    }

    public void Die()
    {
        Debug.Log("Player Dead");
    }
}
