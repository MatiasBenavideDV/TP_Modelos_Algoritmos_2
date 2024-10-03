using System.Collections;
using UnityEngine;

public class KamikazeExplosion : MonoBehaviour
{
    public Player target = default;
    [SerializeField] private float _damageRadius = 3f, _damage = 5f;
    
    void Start() => StartCoroutine(DestroyTime());

    private void Update() => Attack();

    private void Attack()
    {
        if (Vector3.Distance(transform.position, target.transform.position) <= _damageRadius)
            target.TakeDamage(_damage);
    }

    private IEnumerator DestroyTime()
    {
        yield return new WaitForSecondsRealtime(2f);
        Destroy(gameObject);
    }
}
