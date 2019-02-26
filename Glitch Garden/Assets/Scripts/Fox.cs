using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Defender>())
        {
            if (collision.gameObject.tag == "Gravestone")
            {
                GetComponent<Animator>().SetTrigger("JumpTrigger");
            }
            else
            {
                GetComponent<Attacker>().Attack(collision.gameObject);
            }
        }
    }
}
