using System.Collections;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] protected Player _player;
    private float _destroyTime = 2.5f;
    protected float _interactDistance = 3f;

    public void SetPlayer(Player player)
    {
        _player = player;
    }

    protected abstract void GivePowerUp();

    public void Spawn(Player player, Transform transform)
    {
        SetPlayer(player);
        Instantiate(this, transform.position, transform.rotation);
    }

    protected IEnumerator DestroyPowerUp()
    {
        yield return new WaitForSecondsRealtime(_destroyTime);
        Destroy(gameObject);
    }
}
