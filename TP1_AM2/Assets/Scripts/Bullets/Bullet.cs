using System;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    protected float _damage = default;

    [NonSerialized] public float shootCooldown = default;

    [SerializeField] protected float _maxSpeed = default, _viewRadius = default, _destroyCooldown = default;

    private Vector3 _velocity;

    protected void Reset() => _velocity = Vector3.right * _maxSpeed;

    protected void MoveBullet() => transform.position += transform.forward * _maxSpeed * Time.deltaTime;

    public abstract void SetAttributes();

    public abstract void MakeDamage();

    public static void TurnOn(Bullet b)
    {
        b.Reset();
        b.gameObject.SetActive(true);
    }

    public static void TurnOff(Bullet b) => b.gameObject.SetActive(false);
}
