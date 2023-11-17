using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXVolumeResolver : MonoBehaviour
{
    [SerializeField] private AudioSource source;

    private void Start()
    {
        PlayerData.Load();
        source.volume = PlayerData.CurrentSFXVolume;
        source.enabled = PlayerData.SFxEnabled == 1;
    }
}
