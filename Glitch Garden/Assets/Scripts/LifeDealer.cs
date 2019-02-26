using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeDealer : MonoBehaviour
{
    [SerializeField] LifeDisplay text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.LoseLife();
        Destroy(collision.gameObject);
    }
}
