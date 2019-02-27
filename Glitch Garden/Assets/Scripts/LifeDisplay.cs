using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeDisplay : MonoBehaviour
{
    [SerializeField] int lifeCount;
    Text lifetext;

    private void Start()
    {
        lifeCount = 21 - PlayerPrefsController.GetLifeCount();
        lifetext = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        lifetext.text = lifeCount.ToString();
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
