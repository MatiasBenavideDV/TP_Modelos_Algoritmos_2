using TMPro;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BulletsView
{
    private TextMeshProUGUI _commonBulletsText, _iceBulletsText, _fireBulletsText;
    private Image _commonBG, _iceBG, _fireBG;

    private Color _commonColor, _iceColor, _fireColor;

    public BulletsView(TextMeshProUGUI common, TextMeshProUGUI ice, TextMeshProUGUI fire, Image commonBG, Image IceBG, Image FireBG)
    {
        _commonBulletsText = common;
        _iceBulletsText = ice;
        _fireBulletsText = fire;

        _commonBG = commonBG;
        _iceBG = IceBG;
        _fireBG = FireBG;
    }

    public void OnStart()
    {
        UpdateWeaponType(SelectedBullets.Common);
        SetBGColors();
    }

    public void UpdateWeaponType(SelectedBullets bulletType)
    {
        switch (bulletType)
        {
            case SelectedBullets.Common:
                _commonBulletsText.color = Color.yellow;
                _iceBulletsText.color = Color.white;
                _fireBulletsText.color = Color.white;

                ChangeBGOpacity(0.25f, 0f, 0f);
                break;
            case SelectedBullets.Ice:
                _commonBulletsText.color = Color.white;
                _iceBulletsText.color = Color.yellow;
                _fireBulletsText.color = Color.white;

                ChangeBGOpacity(0f, 0.25f, 0f);
                break;
            case SelectedBullets.Fire:
                _commonBulletsText.color = Color.white;
                _iceBulletsText.color = Color.white;
                _fireBulletsText.color = Color.yellow;

                ChangeBGOpacity(0f, 0f, 0.25f);
                break;
            default:
                _commonBulletsText.color = Color.yellow;
                _iceBulletsText.color = Color.white;
                _fireBulletsText.color = Color.white;

                ChangeBGOpacity(0.25f, 0f, 0f);
                break;
        }
    }

    private void SetBGColors()
    {
        _commonColor = _commonBG.color;
        _iceColor = _iceBG.color;
        _fireColor = _fireBG.color;
    }

    private void ChangeBGOpacity(float common, float ice, float fire)
    {
        _commonColor.a = common;
        _iceColor.a = ice;
        _fireColor.a = fire;

        _commonBG.color = _commonColor;
        _iceBG.color = _iceColor;
        _fireBG.color = _fireColor;
    }
}
