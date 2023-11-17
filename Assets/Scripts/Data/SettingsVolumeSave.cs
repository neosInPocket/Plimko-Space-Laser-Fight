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

    private void Start()
    {
        PlayerData.Load();
        musicVolumeSlider.value = PlayerData.CurrentMusicVolume;
        sFxVolumeSlider.value = PlayerData.CurrentSFXVolume;
        musicImage.enabled = PlayerData.MusicEnabled == 1;
        sFxImage.enabled = PlayerData.SFxEnabled == 1;
    }

    public void SaveCurrentVolume()
    {
        PlayerData.CurrentMusicVolume = musicVolumeSlider.value;
        PlayerData.CurrentSFXVolume = sFxVolumeSlider.value;
        PlayerData.Save();
    }

    public void ToggleMusic()
    {
        if (musicImage.enabled)
        {
            musicImage.enabled = false;
            PlayerData.MusicEnabled = 0;
            PlayerData.Save();
            loadMusicSaves.SetMusicEnabled(false);
        }
        else
        {
            musicImage.enabled = true;
            PlayerData.MusicEnabled = 1;
            PlayerData.Save();
            loadMusicSaves.SetMusicEnabled(true);
        }
    }
    
    public void ToggleSFx()
    {
        if (sFxImage.enabled)
        {
            sFxImage.enabled = false;
            PlayerData.SFxEnabled = 0;
            PlayerData.Save();
        }
        else
        {
            sFxImage.enabled = true;
            PlayerData.SFxEnabled = 1;
            PlayerData.Save();
        }
    }
}
