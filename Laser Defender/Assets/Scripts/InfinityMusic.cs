using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityMusic : MonoBehaviour
{
    private void Awake()
    {
        if (FindObjectsOfType<InfinityMusic>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
