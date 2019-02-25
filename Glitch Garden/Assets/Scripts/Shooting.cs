using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab, gun;
    AttackersSpawner myLaneSpawner;
    Animator animator;

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackersSpawner[] attackersSpawners = FindObjectsOfType<AttackersSpawner>();

        foreach (AttackersSpawner spawner in attackersSpawners)
        {
            bool isCloseEnough =
            (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        } else { return true; }
    }

    public void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab, gun.transform.position, Quaternion.identity) as GameObject;
    }
}
