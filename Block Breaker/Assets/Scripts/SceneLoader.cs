using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    GameStatus gameStatus;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name.StartsWith("Level"))
        {
            Cursor.visible = false;
        }
        else
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

    public void StartLastLevel()
    {
        SceneManager.LoadScene(gameStatus.currentLevel);
        gameStatus.ResetCurrentScore();
    }
}
