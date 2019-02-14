using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] GameObject exit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 randomFactor = new Vector3(Random.Range(0f, 0.25f), Random.Range(0f, 0.25f), 0);
        collision.transform.position = exit.transform.position + randomFactor;
    }
}
