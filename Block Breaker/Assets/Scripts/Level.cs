using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableCounts;

    SceneLoader sceneLoader;
    GameStatus gameStatus;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    public void CountBreakableBlocks()
    {
        breakableCounts++;
    }

    public void BlockDestroyed ()
    {
        breakableCounts--;
        if (breakableCounts <= 0)
        {
            gameStatus.IncCurrentLevel();
            sceneLoader.NextLevel();
        }
    }
}
