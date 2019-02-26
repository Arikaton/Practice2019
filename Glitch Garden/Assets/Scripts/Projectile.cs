using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(0, 10)] [SerializeField] float projectileSpeed = 2f;

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * projectileSpeed);
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Attacker>())
        {
            DamageDealer damage = GetComponent<DamageDealer>();
            Hit();
            Health healthDealer = collision.GetComponent<Health>();
            healthDealer.GetDamage(damage.GetDamage);
        }
    }
}
