using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerModel : MonoBehaviour
{
    private IController _controller;

    private Factory<Enemy> factory;
    private ObjectPool<Enemy> pool;

    [SerializeField] private float cooldown = 2f;
    [SerializeField] private int enemyStock = 7;
    
    [SerializeField] private Player target;
    [SerializeField] private PowerUpsManager _powerUpsManager;

    [SerializeField] private List<Enemy> enemiesList;


    private bool canSpawn = true;

    void Start()
    {
        _controller = new SpawnerController(this);

        int randomEnemy = Random.Range(0, enemiesList.Count);

        Enemy enemyToSpawn = enemiesList[randomEnemy];

        factory = new EnemyFactory(enemyToSpawn);

        pool = new ObjectPool<Enemy>(factory.GetObject, Enemy.TurnOn, Enemy.TurnOff, enemyStock, false);
    }

    void Update()
    {
        _controller.OnUpdate();
    }

    public void SpawnEnemy()
    {
        if (canSpawn)
        {
            var e = pool.GetObject();

            if (!e) return;

            e.pool = pool;
            e.transform.position = transform.position;
            e.target = target;
            e.powerUpsManager = _powerUpsManager;
            
            StartCoroutine(SpawnCooldown(cooldown));
        }
    }

    private IEnumerator SpawnCooldown(float cooldown)
    {
        canSpawn = false;

        yield return new WaitForSecondsRealtime(cooldown);

        canSpawn = true;
    }
}
