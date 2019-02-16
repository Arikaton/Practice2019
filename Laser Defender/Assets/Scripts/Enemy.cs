using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] float shootCounter;
    [SerializeField] float minTimeBetweenShoots = 0.2f;
    [SerializeField] float maxTimeBetweenShoots = 3f;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        shootCounter = Random.Range(minTimeBetweenShoots, maxTimeBetweenShoots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndFire();
    }

    private void CountDownAndFire()
    {
        shootCounter -= Time.deltaTime;
        if (shootCounter <= 0f)
        {
            Fire();
            shootCounter = Random.Range(minTimeBetweenShoots, maxTimeBetweenShoots);
        }
    }

    private void Fire()
    {
        var fire = Instantiate(projectile,
                    transform.position,
                    Quaternion.identity) as GameObject;
        fire.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProccesHit(damageDealer);
    }

    private void ProccesHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
