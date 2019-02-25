using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;
    [SerializeField] int minRandomAmount = 3;

    public void AddStars(int amount)
    {
        int randAmount = Random.Range(minRandomAmount, amount);
        FindObjectOfType<StarDisplay>().AddStars(randAmount);
    }

    public int GetStarCost() { return starCost; }
}
