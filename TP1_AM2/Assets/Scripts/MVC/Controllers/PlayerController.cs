using UnityEngine;

public class PlayerController : IController
{
    private PlayerModel _playerModel = default;
    private BulletType _bulletType = default;
    private JoyController _moveStick = default, _aimStick = default;
    private TapController[] _taps = default;
    private bool _canShoot = false;

    public PlayerController (PlayerModel playerModel, BulletType bulletType, JoyController moveStick, JoyController aimStick, TapController[] taps)
    {
        _playerModel = playerModel;

        _bulletType = bulletType;
        _bulletType.OnAwake();

        _moveStick = moveStick;
        _aimStick = aimStick;

        _taps = taps;
    }

    public void OnUpdate()
    {
        if (_aimStick.GetDir().magnitude > 0.1f)
        {
            _playerModel.Move(_moveStick.GetDir());
            _canShoot = true;
            _playerModel.Rotate(_aimStick.GetDir());
        }
        else
        {
            _playerModel.Move(_moveStick.GetDir(), true);
            _canShoot = false;
        }

        GetBulletType();

        if (_canShoot) _playerModel._player.ShootBullet(_bulletType);
    }

    private void GetBulletType()
    {
        TapController currentTap = null;

        foreach (var tap in _taps)
        {
            if (tap.GetTapped())
            {
                currentTap = tap;
                
                foreach (var otherTap in _taps)
                {
                    if (otherTap.BulletType != tap.BulletType) currentTap.FalseTapped();
                }
            }
            else _bulletType.ChangeBulletType(SelectedBullets.Common);
        }

        if (currentTap != null) _bulletType.ChangeBulletType(currentTap.BulletType);
        else _bulletType.ChangeBulletType(SelectedBullets.Common);
    }
}
