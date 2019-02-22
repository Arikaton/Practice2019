using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDefenders : MonoBehaviour
{
    [SerializeField] GameObject defender;
    
    private void OnMouseDown()
    {
        SpawnAtPos();
    }

    private void SpawnAtPos()
    {
        Vector2 clickPos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = new Vector2(Mathf.RoundToInt(worldPos.x), Mathf.RoundToInt(worldPos.y));
        Instantiate(defender, gridPos, transform.rotation);

    }
}
