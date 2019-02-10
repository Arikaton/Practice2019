using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMechanic : MonoBehaviour
{
    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] TextMeshProUGUI guessText;
    private int guess;

    void Start()
    {
        NextGuess();
    }

    public void NextScene ()
    {
        int _currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(_currentScene + 1);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

    public void PressHigher ()
    {
        min = guess + 1;
        NextGuess();
    }

    public void PressLower ()
    {
        max = guess;
        NextGuess();
    }

    public void NextGuess ()
    {
        guess = Random.Range(min, max + 1);
        guessText.text = guess.ToString();
    }

    public void PlayAgain ()
    {
        SceneManager.LoadScene(0);
    }
}
