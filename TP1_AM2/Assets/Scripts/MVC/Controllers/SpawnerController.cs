using System;

public class SpawnerController : IController
{
    SpawnerModel model;

    public SpawnerController(SpawnerModel m)
    {
        model = m;
    }

    public void OnUpdate()
    {
        model.SpawnEnemy();
    }
}
