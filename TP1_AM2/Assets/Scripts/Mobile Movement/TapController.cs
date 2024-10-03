using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private SelectedBullets _bulletType = default;
    private bool _isTapped = false;

    public SelectedBullets BulletType { get { return _bulletType; } }

    public bool GetTapped() => _isTapped;

    public void FalseTapped()
    {
        Debug.Log(_bulletType + " Off");
        _isTapped = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(_bulletType + " On");
        _isTapped = true;
    }
}
