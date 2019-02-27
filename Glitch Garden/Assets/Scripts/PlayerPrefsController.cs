using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    public static float GetVolume() => PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);

    public static void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else { Debug.LogError("Master volume is out of range"); }
    }

    public static void SetLifeCount(int value) => PlayerPrefs.SetInt(DIFFICULTY_KEY, value);

    public static int GetLifeCount() => PlayerPrefs.GetInt(DIFFICULTY_KEY);
}
