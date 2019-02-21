using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab, gun;

    public void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab, gun.transform.position, Quaternion.identity) as GameObject;
    }
}
