using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;

    public int GetHealth => health;

    public void GetDamage(int damage) { health -= damage; }
}
