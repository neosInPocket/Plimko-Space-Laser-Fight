using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class LoadMusicSaves : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private PlayerData playerData;

    private void Start()
    {
        playerData = new PlayerData(false);
        SetCurrentMusicVolume(playerData.CurrentMusicVolume);
        SetMusicEnabled(playerData.MusicEnabled == 1);
    }

    public void SetCurrentMusicVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void SetMusicEnabled(bool isEnabled)
    {
        audioSource.enabled = isEnabled;
    }
}
