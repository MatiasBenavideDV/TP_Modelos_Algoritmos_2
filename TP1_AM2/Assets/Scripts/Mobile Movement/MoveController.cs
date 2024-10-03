using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveController : MonoBehaviour
{
    public abstract Vector3 GetDir();
}

public class PlayerMobileController : MonoBehaviour
{
    [SerializeField] private MoveController _moveController = default;
    [SerializeField] private float _speed = default;

    private void Update()
    {
        transform.position += _moveController.GetDir() * _speed * Time.deltaTime;
    }
}

public class ButtonController : MoveController
{
    private Vector3 _dir;

    public override Vector3 GetDir()
    {
        return _dir;
    }
}
