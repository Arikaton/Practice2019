using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentSpeed = 0;
    GameObject currentTarget;

    private void Start()
    {
        FindObjectOfType<LevelController>().AddAtacker();
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
    }

    public void SetMovementSpeed (float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(int damage)
    {
        if (!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.GetDamage(damage);
        }
    }

    public void HasAim()
    {
        if (!currentTarget) { GetComponent<Animator>().SetBool("IsAttacking", false); }
    }

    private void OnDestroy()
    {
        FindObjectOfType<LevelController>().RemoveAttacker();
    }
}
