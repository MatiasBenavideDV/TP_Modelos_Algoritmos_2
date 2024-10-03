using System.Collections;
using UnityEngine;

public class EnemyBullet : Bullet
{
    public ObjectPool<EnemyBullet> pool;

    [SerializeField] private LayerMask _playerMask;

    private void Awake()
    {
        Reset();
    }

    private void Update()
    {
        MoveBullet();
        MakeDamage();
    }

    public override void SetAttributes()
    {
        _damage = 15f;
        shootCooldown = 1f;
    }

    public override void MakeDamage()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + transform.forward * 0.3f, transform.forward, out hit, _viewRadius, _playerMask))
        {
            Player player = hit.transform.gameObject.GetComponent<Player>();

            if (player != null) player.TakeDamage(_damage);

            pool.ReturnObject(this);
        }
        else StartCoroutine(DestroyBullet(_destroyCooldown));
    }

    private IEnumerator DestroyBullet(float cooldown)
    {
        yield return new WaitForSecondsRealtime(cooldown);
        pool.ReturnObject(this);
    }
}
