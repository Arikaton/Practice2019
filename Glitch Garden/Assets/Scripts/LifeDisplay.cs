using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeDisplay : MonoBehaviour
{
    [SerializeField] int lifeCount = 20;
    Text lifetext;

    private void Start()
    {
        lifetext = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        lifetext.text = lifeCount.ToString();
        if (lifeCount == 10 )
        {
            lifetext.color = Color.yellow;
        } 
        if (lifeCount == 3)
        {
            lifetext.color = Color.red;
        }
    }

    public void LoseLife()
    {
        if (lifeCount > 1)
        {
            lifeCount -= 1;
            UpdateDisplay();
        }
        else
        {
            FindObjectOfType<LevelController>().LoseGame();
        }
    }
}
