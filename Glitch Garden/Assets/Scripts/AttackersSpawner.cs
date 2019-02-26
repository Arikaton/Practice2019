using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackersSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackersPrefab;

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        int randomChoose = Random.Range(0, attackersPrefab.Length);
        Attacker newAttacker = Instantiate(attackersPrefab[randomChoose], transform.position, Quaternion.identity) as Attacker;
        newAttacker.transform.parent = transform;
    }

    public void FinishLevel() => spawn = false;
}
