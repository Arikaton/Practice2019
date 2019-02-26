using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour 
{
    int countAttackers = 0;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] AudioClip winSound;
    bool loseGame = false;
    bool endTimer = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AddAtacker() => countAttackers ++;

    public void RemoveAttacker()
    {
        countAttackers --;
        if (countAttackers <= 0 & endTimer & !loseGame)
        {
            StartCoroutine(WinLevel());
        }
    }

    public void FinishLevel()
    {
        AttackersSpawner[] spawns = FindObjectsOfType<AttackersSpawner>();
        foreach (AttackersSpawner spawn in spawns)
        {
            spawn.FinishLevel();
        }
        endTimer = true;
    }

    IEnumerator WinLevel()
    {
        winLabel.SetActive(true);
        AudioSource.PlayClipAtPoint(winSound, Camera.main.transform.position);
        yield return new WaitForSeconds(3f);
        FindObjectOfType<LoadLevel>().LoadNextScene(); //Load win window
    }

    public void LoseGame()
    {
        loseGame = true;
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }
}
