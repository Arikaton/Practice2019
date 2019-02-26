using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] int countAttackers = 0;

    public void AddAtacker() => countAttackers += 1;

    public void RemoveAttacker()
    {
        countAttackers -= 1;
        if (countAttackers <= 0)
        {
            WinLevel();
        }
    }

    public void FinishLevel()
    {
        AttackersSpawner[] spawns = FindObjectsOfType<AttackersSpawner>();
        foreach (AttackersSpawner spawn in spawns)
        {
            spawn.FinishLevel();
        }
    }

    void WinLevel()
    {
        Debug.Log("You WIN!!");
    }
}
