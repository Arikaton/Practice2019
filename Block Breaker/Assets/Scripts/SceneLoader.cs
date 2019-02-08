using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    GameStatus gameStatus;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            Cursor.visible = false;
        }
        if (SceneManager.GetActiveScene().name == "FinishGame")
        {
            Cursor.visible = true;
        }
        gameStatus = FindObjectOfType<GameStatus>();
    }
    public  void NextLevel ()
    {
        int _currentLevel;
        _currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(_currentLevel+1);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

    public void StartNewGame ()
    {
        gameStatus.DestoyGameStatus();
        SceneManager.LoadScene(0);
    }
}
