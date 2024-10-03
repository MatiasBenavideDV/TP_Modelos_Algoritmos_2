using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        float x = _playerTransform.position.x;
        float y = transform.position.y;
        float z = _playerTransform.position.z;

        transform.position = new Vector3(x, y, z);
    }
}
