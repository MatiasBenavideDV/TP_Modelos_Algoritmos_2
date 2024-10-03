using System.Collections;
using UnityEngine;

public abstract class Enemy : SteeringAgent
{
    public Player target;

    public PowerUpsManager powerUpsManager;

    protected float _maxHealth = default, _currentHealth = default, _damage = default, _currentSpeed = default, _attackDistance = default;

    public ObjectPool<Enemy> pool;

    [SerializeField] private ParticleSystem _particles;

    protected bool _canTakeTickDamage = true, _isDead = false;

    public abstract void Reset();
    protected abstract void Attack();

    public void IsDead()
    {
        if (_currentHealth <= 0)
        {
            powerUpsManager.SpawnPowerUp(transform);
            target.KilledEnemy();
            _isDead = true;
            EnemyFactory.Instance.ReturnEnemy(pool, this);
        }
        else return;
    }

    public void TakeDamage(float damage)
    {
        if (!_isDead)
        {
            _currentHealth -= damage;
            IsDead();
        }
    }

    public void TakeDamage(float damage, float ticks, SelectedBullets damageType)
    {
        if (!_isDead)
        {
            TakeDamage(damage);
            
            // gameObject.activeInHierarchy se utiliza para evitar un error al devolver el objeto al pool
            if (gameObject.activeInHierarchy && ticks > 1) StartCoroutine(TickDamage(damage, ticks, damageType));
        }
    }

    public void ChangeParticlesColor(Color damageColor)
    {
        ParticleSystem.MainModule mainParticle = _particles.main;
        _particles.Stop();
        mainParticle.startColor = damageColor;
        _particles.Play();
    }

    public static void TurnOn(Enemy e)
    {
        e.Reset();
        e.gameObject.SetActive(true);
    }

    public static void TurnOff(Enemy e)
    {
        e.gameObject.SetActive(false);
    }

    private IEnumerator TickDamage(float damage, float ticks, SelectedBullets damageType)
    {
        for (int i = 0; i <= ticks; i++)
        {
            if (_canTakeTickDamage)
            {
                // gameObject.activeInHierarchy se utiliza para evitar un error al devolver el objeto al pool
                if (gameObject.activeInHierarchy && damageType == SelectedBullets.Fire)
                    yield return StartCoroutine(SetFireEffect(damage, 0.5f));
                
                else if (gameObject.activeInHierarchy && damageType == SelectedBullets.Ice)
                    yield return StartCoroutine(SetIceEffect(damage, 0.5f));
                
                else yield return null;
            }
        }
    }

    private IEnumerator TickCooldown(float tickCooldown)
    {
        _canTakeTickDamage = false;
        yield return new WaitForSeconds(tickCooldown);
        _canTakeTickDamage = true;
    }

    private IEnumerator SetFireEffect(float damage, float tickCooldown)
    {
        TakeDamage(damage / 3);
        ChangeParticlesColor(Color.red);
        _maxSpeed = _currentSpeed * 2;
        yield return TickCooldown(tickCooldown);
        _maxSpeed = _currentSpeed;
    }

    private IEnumerator SetIceEffect(float damage, float tickCooldown)
    {
        TakeDamage(damage / 5);
        ChangeParticlesColor(Color.cyan);
        _maxSpeed = _currentSpeed / 2;
        yield return TickCooldown(tickCooldown);
        _maxSpeed = _currentSpeed;
    }
}
