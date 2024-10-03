using UnityEngine;

public class HealPowerUp : PowerUp
{
    void Update()
    {
        GivePowerUp();
    }

    protected override void GivePowerUp()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) <= _interactDistance)
        {
            _player.PowerHealth();
            Destroy(gameObject);
        }
    }
}
