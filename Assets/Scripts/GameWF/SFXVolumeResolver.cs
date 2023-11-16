using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXVolumeResolver : MonoBehaviour
{
    [SerializeField] private AudioSource source;

    private void Start()
    {
        var data = new PlayerData(false);
        source.volume = data.CurrentSFxVolume;
        source.enabled = data.SFxEnabled == 1;
    }
}
