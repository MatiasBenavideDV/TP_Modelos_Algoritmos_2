using UnityEngine;

public class SpeedPowerUp : PowerUp
{
    void Update()
    {
        GivePowerUp();
    }

    protected override void GivePowerUp()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) <= _interactDistance)
        {
            _player.PowerSpeed();
            Destroy(gameObject);
        }
    }
}
