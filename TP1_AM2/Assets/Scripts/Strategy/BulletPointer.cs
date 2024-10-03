public class BulletPointer
{
    public static readonly BulletEntity CommonBullet = new BulletEntity
    {
        damage = 15f,
        ticks = 1,
        fireRate = 0.5f,
    };

    public static readonly BulletEntity IceBullet = new BulletEntity
    {
        damage = 20f,
        ticks = 5,
        fireRate = 1f
    };


    public static readonly BulletEntity FireBullet = new BulletEntity
    {
        damage = 10f,
        ticks = 3,
        fireRate = 0.15f
    };
}
