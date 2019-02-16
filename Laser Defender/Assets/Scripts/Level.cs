using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds;

    public void LoadStartScene()
    {
        FindObjectOfType<ScoreManager>().Reset();
        SceneManager.LoadScene(0);
    }

    public void LoadFinishScene()
    {
        StartCoroutine(WaitSomething());
    }

    IEnumerator WaitSomething()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(2);
    }

    public void LoadGame()
    {
        var scoreManager = FindObjectOfType<ScoreManager>();
        if (!scoreManager)
        {
            Debug.Log("Empty");
        }
        else
        {
            scoreManager.Reset();
        }
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
