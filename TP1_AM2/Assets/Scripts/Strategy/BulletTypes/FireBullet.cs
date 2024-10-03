using UnityEngine;

public class FireBullet : IShoot
{
    private BulletType _bulletType;

    public FireBullet(BulletType bulletType)
    {
        _bulletType = bulletType;
    }

    public void SetStats()
    {
        _bulletType.currentBulletType = this;
        _bulletType.selectedBullets = SelectedBullets.Fire;
        _bulletType.damage = BulletPointer.FireBullet.damage;
        _bulletType.ticks = BulletPointer.FireBullet.ticks;
        _bulletType.fireRate = BulletPointer.FireBullet.fireRate;
    }

    public void DamageEnemy(Enemy enemy)
    {
        enemy.TakeDamage(_bulletType.damage, _bulletType.ticks, _bulletType.selectedBullets);
    }
}
