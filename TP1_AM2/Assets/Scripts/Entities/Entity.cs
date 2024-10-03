using UnityEngine;

public class Entity
{
    public float maxHealth = default, speed = default, damage = default;
    public Vector3 direction = Vector3.forward;
}

public class BulletEntity
{
    public float damage = default;
    public int ticks = default;
    public float fireRate = default;
}
