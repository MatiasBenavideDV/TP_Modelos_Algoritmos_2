using UnityEngine;

public class CommonBullet : IShoot
{
    private BulletType _bulletType;

    public CommonBullet(BulletType bulletType)
    {
        _bulletType = bulletType;
    }
    public void SetStats()
    {
        _bulletType.currentBulletType = this;
        _bulletType.selectedBullets = SelectedBullets.Common;
        _bulletType.damage = BulletPointer.CommonBullet.damage;
        _bulletType.ticks = BulletPointer.CommonBullet.ticks;
        _bulletType.fireRate = BulletPointer.CommonBullet.fireRate;
    }
    public void DamageEnemy(Enemy enemy)
    {
        enemy.TakeDamage(_bulletType.damage, _bulletType.ticks, _bulletType.selectedBullets);
    }
}
