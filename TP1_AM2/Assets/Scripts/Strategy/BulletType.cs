using System;
using UnityEngine;

public class BulletType
{
    public float damage = default;
    public int ticks = default;
    public float fireRate = default;

    private IShoot _commonBullet, _iceBullet, _fireBullet;

    public IShoot currentBulletType;

    public SelectedBullets selectedBullets;

    public event Action<SelectedBullets> onBulletChange = delegate { };

    public BulletType() {}

    public void OnAwake()
    {
        _commonBullet = new CommonBullet(this);
        _iceBullet = new IceBullet(this);
        _fireBullet = new FireBullet(this);

        ChangeBulletType(SelectedBullets.Common);
    }

    public void ChangeBulletType(SelectedBullets selectedBullets)
    {
        switch(selectedBullets)
        {
            case SelectedBullets.Common:
                currentBulletType = _commonBullet;
                _commonBullet.SetStats();
                onBulletChange(SelectedBullets.Common);
                break;

            case SelectedBullets.Ice:
                currentBulletType = _iceBullet;
                _iceBullet.SetStats();
                onBulletChange(SelectedBullets.Ice);
                break;
            
            case SelectedBullets.Fire:
                currentBulletType = _fireBullet;
                _fireBullet.SetStats();
                onBulletChange(SelectedBullets.Fire);
                break;

            default:
                _commonBullet.SetStats();
                onBulletChange(SelectedBullets.Common);
                break;
        }
    }
}
