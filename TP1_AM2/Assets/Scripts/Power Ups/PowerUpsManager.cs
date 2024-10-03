using UnityEngine;

public class PowerUpsManager : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private SpeedPowerUp _speedPowerUp;
    [SerializeField] private HealPowerUp _damagePowerUp;

    public void SpawnPowerUp(Transform transform)
    {
        int randomPowerUp = Random.Range(0, 11);

        if (randomPowerUp < 3)
            _speedPowerUp.Spawn(_player, transform);
        
        else if (randomPowerUp < 6)
            _damagePowerUp.Spawn(_player, transform);
        
        else return;
    }
}
