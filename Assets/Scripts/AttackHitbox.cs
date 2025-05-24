using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    public int damage = 1;
    public float duration = 0.2f;

    private void Start()
    {
        Destroy(gameObject, duration); // Se destruye solo tras un tiempo
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Slime>().TakeDamage(damage);
        }
    }
}
