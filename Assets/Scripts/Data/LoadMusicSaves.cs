using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class LoadMusicSaves : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private void Start()
    {
        SetCurrentMusicVolume(PlayerData.CurrentMusicVolume);
        SetMusicEnabled(PlayerData.MusicEnabled == 1);
    }

    public void SetCurrentMusicVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void SetMusicEnabled(bool isEnabled)
    {
        PlayerData.Load();
        audioSource.enabled = isEnabled;
        if (isEnabled)
        {
            PlayerData.MusicEnabled = 1;
        }
        else
        {
            PlayerData.MusicEnabled = 0;
        }
        
        PlayerData.Save();
    }
}
