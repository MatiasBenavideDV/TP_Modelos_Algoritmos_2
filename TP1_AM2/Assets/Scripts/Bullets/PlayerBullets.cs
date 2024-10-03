using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullets : Bullet
{
    public ObjectPool<PlayerBullets> pool;

    private BulletType _bulletType;
    
    private int _ticks = default;

    [SerializeField] private LayerMask _enemiesMask;

    [SerializeField] private Renderer _renderer;

    [SerializeField] private List<Material> _bulletMaterials;

    private void Awake()
    {
        Reset();
    }

    private void Update()
    {
        MoveBullet();
        MakeDamage();
    }

    public void SetBulletType(BulletType bulletType)
    {
        _bulletType = bulletType;
        SetAttributes();
    }

    public override void SetAttributes()
    {
        _damage = _bulletType.damage;
        _ticks = _bulletType.ticks;
        shootCooldown = _bulletType.fireRate;

        switch (_bulletType.selectedBullets)
        {
            case SelectedBullets.Common:
                _renderer.material = _bulletMaterials[0];
                break;

            case SelectedBullets.Ice:
                _renderer.material = _bulletMaterials[1];
                break;

            case SelectedBullets.Fire:
                _renderer.material = _bulletMaterials[2];
                break;

            default:
                _renderer.material = _bulletMaterials[0];
                break;
        }

    }

    public override void MakeDamage()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + transform.forward * 0.3f, transform.forward, out hit, _viewRadius, _enemiesMask))
        {
            Enemy enemy = hit.transform.gameObject.GetComponent<Enemy>();

            if (enemy != null) _bulletType.currentBulletType.DamageEnemy(enemy);

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
