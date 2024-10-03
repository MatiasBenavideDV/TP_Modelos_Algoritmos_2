using UnityEngine;
using UnityEngine.EventSystems;

public class JoyController : MoveController, IDragHandler, IEndDragHandler
{
    private Vector3 _dir = default, _startPos = default;
    [SerializeField] private float _magnitude = default;

    private void Start()
    {
        _startPos = transform.position;
    }

    public override Vector3 GetDir()
    {
        return _dir;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 clampedDir = Vector3.ClampMagnitude((Vector3)eventData.position - _startPos, _magnitude);
        transform.position = _startPos + clampedDir;

        clampedDir = new Vector3(clampedDir.x, 0, clampedDir.y);

        _dir = clampedDir / _magnitude;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = _startPos;
        _dir = Vector3.zero;
    }
}
