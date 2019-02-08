using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableCounts;

    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
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
            sceneLoader.NextLevel();
        }
    }
}
