using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    //config params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerDestroyedBlock = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    public bool moveByMouse = true;

    //state
    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        int currentCount = FindObjectsOfType<GameStatus>().Length;
        if (currentCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {   
        UpdateScore();
    }
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore ()
    {
        currentScore += pointsPerDestroyedBlock;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = currentScore.ToString();
    }

    public void DestoyGameStatus ()
    {
        Destroy(gameObject);
    }

    public bool ChangeMoveSet ()
    {
        moveByMouse = !moveByMouse;
        if (moveByMouse)
        {
            Cursor.visible = false;
        }
        return moveByMouse;
    }
}
