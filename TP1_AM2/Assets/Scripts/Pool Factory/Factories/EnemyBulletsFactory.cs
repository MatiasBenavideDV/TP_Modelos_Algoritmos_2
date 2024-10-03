using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletsFactory : Factory<EnemyBullet>
{
    public static EnemyBulletsFactory Instance;
    public EnemyBullet bulletPrefab;

    public EnemyBulletsFactory(EnemyBullet bullet)
    {
        Instance = this;
        _prefab = bulletPrefab = bullet;
    }

    public void ReturnBullet(ObjectPool<EnemyBullet> pool, EnemyBullet b)
    {
        pool.ReturnObject(b);
    }
}
