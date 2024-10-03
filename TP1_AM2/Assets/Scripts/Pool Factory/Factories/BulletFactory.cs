public class BulletFactory : Factory<PlayerBullets>
{
    public static BulletFactory Instance;
    public PlayerBullets bulletPrefab;

    public BulletFactory(PlayerBullets bullet)
    {
        Instance = this;
        _prefab = bulletPrefab = bullet;
    }

    public void ReturnBullet(ObjectPool<PlayerBullets> pool, PlayerBullets b)
    {
        pool.ReturnObject(b);
    }
}
