using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider sliderVolume;
    [SerializeField] Slider sliderDifficulty;
    [SerializeField] float defaultVolume = 0.5f;
    [SerializeField] int defaultDifficulty = 11;

    private void Start()
    {
        sliderVolume.value = PlayerPrefsController.GetVolume();
        sliderDifficulty.value = PlayerPrefsController.GetLifeCount();
    }

    public void ChangeVolume()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(sliderVolume.value);
        } else { Debug.LogError("No MusicPlayer find. Did you start from splashScreen?"); }
    }

    public void ChangeDifficulty()
    {
        PlayerPrefsController.SetLifeCount(Mathf.RoundToInt(sliderDifficulty.value));
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(sliderVolume.value);
        PlayerPrefsController.SetLifeCount(Mathf.RoundToInt(sliderDifficulty.value));
        FindObjectOfType<LoadLevel>().NewGame();
    }

    public void SetDefaults()
    {
        sliderVolume.value = defaultVolume;
        sliderDifficulty.value = defaultDifficulty;
    }
}
