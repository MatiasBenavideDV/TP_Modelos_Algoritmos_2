using UnityEngine;

public class IceBullet : IShoot
{
    private BulletType _bulletType;

    public IceBullet(BulletType bulletType)
    {
        _bulletType = bulletType;
    }

    public void SetStats()
    {
        _bulletType.currentBulletType = this;
        _bulletType.selectedBullets = SelectedBullets.Ice;
        _bulletType.damage = BulletPointer.IceBullet.damage;
        _bulletType.ticks = BulletPointer.IceBullet.ticks;
        _bulletType.fireRate = BulletPointer.IceBullet.fireRate;
    }

    public void DamageEnemy(Enemy enemy)
    {
        enemy.TakeDamage(_bulletType.damage, _bulletType.ticks, _bulletType.selectedBullets);
    }
}
