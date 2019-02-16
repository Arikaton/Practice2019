using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    //config
    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] int health = 200;
    [SerializeField] GameObject explosion;
    [SerializeField] TextMeshProUGUI healthText;

    [Header("Projectile")]
    [SerializeField] GameObject shootPrefab;
    [SerializeField] float shootSpeed = 20f;
    [SerializeField] float projectileFiringPeriod = 0.1f;

    [Header("SFX")]
    [SerializeField] AudioClip SFXExplosion;
    [Range(0, 1)] [SerializeField] float explosionVolume;
    AudioSource SFXShoot;

    float minX;
    float maxX;
    float minY;
    float maxY;

    Coroutine fireCoroutine;

    void Start()
    {
        Cursor.visible = false;
        healthText.text = health.ToString();
        SFXShoot = GetComponent<AudioSource>();
        SetUpMoveBoundaries();
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            fireCoroutine = StartCoroutine(FireContiniously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(fireCoroutine);
        }
    }

    private IEnumerator FireContiniously()
    {
        while (true)
        {
            SFXShoot.PlayOneShot(SFXShoot.clip);
            GameObject currentShot = Instantiate(shootPrefab, transform.position, Quaternion.identity) as GameObject;
            currentShot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shootSpeed);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);
        transform.position = new Vector2(newXPos, newYPos);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        healthText.text = health.ToString();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<Level>().LoadFinishScene();
        AudioSource.PlayClipAtPoint(SFXExplosion, Camera.main.transform.position, explosionVolume);
        Destroy(gameObject);
        GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
        Destroy(exp, 0.5f);
        Cursor.visible = true;
    }
}
