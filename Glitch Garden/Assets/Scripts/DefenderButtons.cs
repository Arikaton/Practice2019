using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButtons : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    private void Start()
    {
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        costText.text = defenderPrefab.GetStarCost().ToString();
    }

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
