using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //config
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] GameObject shootPrefab;
    [SerializeField] float shootSpeed = 20f;

    float minX;
    float maxX;
    float minY;
    float maxY;

    void Start()
    {
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
            GameObject currentShot = Instantiate(shootPrefab, transform.position, Quaternion.identity) as GameObject;
            currentShot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shootSpeed);
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
}
