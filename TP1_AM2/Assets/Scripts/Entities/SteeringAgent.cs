using UnityEngine;

public class SteeringAgent : MonoBehaviour
{
    protected float _maxSpeed = default, _maxForce = 7f, _viewRadius = 20f;

    protected bool _distanceAttack = default;

    protected Vector3 _velocity;
    
    protected void Move(Vector3 target)
    {
        Seek(target);
        if(!_distanceAttack) transform.position += _velocity * Time.deltaTime;
        transform.forward = _velocity;
    }

    protected void Seek(Vector3 targetPos)
    {
        Vector3 desired = targetPos - transform.position;
        desired.Normalize();
        desired *= _maxSpeed;

        Vector3 steering = desired - _velocity;

        steering = Vector3.ClampMagnitude(steering, _maxForce * Time.deltaTime);

        AddForce(steering);
    }

    protected void AddForce(Vector3 force)
    {
        _velocity = Vector3.ClampMagnitude(_velocity + force, _maxSpeed);
    }
}
