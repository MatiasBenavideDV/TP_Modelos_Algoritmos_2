public class EnemyFactory : Factory<Enemy>
{
    public static EnemyFactory Instance;

    public Enemy enemyPrefab;

    public EnemyFactory(Enemy enemy)
    {
        Instance = this;
        _prefab = enemyPrefab = enemy;
    }

    public void ReturnEnemy(ObjectPool<Enemy> pool, Enemy e)
    {
        pool.ReturnObject(e);
    }
}
