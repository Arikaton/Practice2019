using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    ScoreManager scoreManager;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = scoreManager.GetScore().ToString();
    }
}
