using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsVolumeSave : MonoBehaviour
{
    [SerializeField] private LoadMusicSaves loadMusicSaves;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sFxVolumeSlider;
    [SerializeField] private Image musicImage;
    [SerializeField] private Image sFxImage;
    private PlayerData playerData;

    private void Start()
    {
        playerData = new PlayerData(false);
        musicVolumeSlider.value = playerData.CurrentMusicVolume;
        sFxVolumeSlider.value = playerData.CurrentSFxVolume;
        musicImage.enabled = playerData.MusicEnabled == 1;
        sFxImage.enabled = playerData.SFxEnabled == 1;
    }

    public void SaveCurrentVolume()
    {
        playerData.CurrentMusicVolume = musicVolumeSlider.value;
        playerData.CurrentSFxVolume = sFxVolumeSlider.value;
        playerData.SavePlayerData();
    }

    public void ToggleMusic()
    {
        if (musicImage.enabled)
        {
            musicImage.enabled = false;
            playerData.MusicEnabled = 0;
            playerData.SavePlayerData();
            loadMusicSaves.SetMusicEnabled(false);
        }
        else
        {
            musicImage.enabled = true;
            playerData.MusicEnabled = 1;
            playerData.SavePlayerData();
            loadMusicSaves.SetMusicEnabled(true);
        }
    }
    
    public void ToggleSFx()
    {
        if (sFxImage.enabled)
        {
            sFxImage.enabled = false;
            playerData.SFxEnabled = 0;
            playerData.SavePlayerData();
        }
        else
        {
            sFxImage.enabled = true;
            playerData.SFxEnabled = 1;
            playerData.SavePlayerData();
        }
    }
}
