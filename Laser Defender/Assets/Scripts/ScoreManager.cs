using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void IncrementScore(int score)
    {
        currentScore += score;
       // scoreText.text = currentScore.ToString();
    }

    public void Reset() 
    {
        Destroy(gameObject);
    }

    public int GetScore () { return currentScore; }
}
