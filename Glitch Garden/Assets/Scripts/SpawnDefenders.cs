using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDefenders : MonoBehaviour
{
    Defender defender;
    
    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    private void AttemptToPlaceDefenderAt (Vector2 gridPos)
    {
        var StarDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();
        if (StarDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnAtPos(gridPos);
            StarDisplay.SpendStars(defenderCost);
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = new Vector2(Mathf.RoundToInt(worldPos.x), Mathf.RoundToInt(worldPos.y));
        return gridPos;
    }

    private void SpawnAtPos(Vector2 spawnPos)
    {   
        Defender defenderObject = Instantiate(defender, spawnPos, transform.rotation) as Defender;
    }

    public void SetSelectedDefender(Defender selecetedDefender)
    {
        defender = selecetedDefender;
    }
}
