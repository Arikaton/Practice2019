using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButtons : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    private void OnMouseDown()
    {
        DefenderButtons[] buttons = FindObjectsOfType<DefenderButtons>();
        foreach (DefenderButtons button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = Color.gray;
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<SpawnDefenders>().SetSelectedDefender(defenderPrefab);
    }
}
