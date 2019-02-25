using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentSpeed = 0;
    [SerializeField] GameObject deathVFX;

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
    }

    public void SetMovementSpeed (float speed)
    {
        currentSpeed = speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Projectile>())
        {
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();
            DamageDealer damage = collision.GetComponent<DamageDealer>();
            projectile.Hit();
            Health healthDealer = GetComponent<Health>();
            healthDealer.GetDamage(damage.GetDamage);
            if (healthDealer.GetHealth <= 0)
            {
                DeathVFX();
                Destroy(gameObject);
            }
        }
    }

    private void DeathVFX()
    {
        GameObject dieVFX = Instantiate(deathVFX, transform.position + new Vector3(-0.25f, -0.25f), transform.rotation);
        Destroy(dieVFX, 0.5f);
    }
}
