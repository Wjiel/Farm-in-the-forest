using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public int Damage;
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(20);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.TryGetComponent(out Enemy enemy))
        {
            enemy.GetDamage(Damage);
            Destroy(gameObject);
        }
    }
}