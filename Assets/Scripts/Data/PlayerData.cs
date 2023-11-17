using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public static int CurrentProgress;
    public static int CurrentGold;
    public static int CurrentLifes;
    public static int CurrentProjectileSpeed;
    public static int MusicEnabled;
    public static int SFxEnabled;
    public static float CurrentMusicVolume;
    public static float CurrentSFXVolume;
    public static int FirstGame;
	
    public static void Save()
    {
        PlayerPrefs.SetInt("currentGold", CurrentGold);
        PlayerPrefs.SetInt("currentProgress", CurrentProgress);
        PlayerPrefs.SetInt("currentLifes", CurrentLifes);
        PlayerPrefs.SetInt("currentProjectileSpeed", CurrentProjectileSpeed);
        PlayerPrefs.SetInt("musicEnabled", MusicEnabled);
        PlayerPrefs.SetInt("sfxEnabled", SFxEnabled);
        PlayerPrefs.SetFloat("currentMusicVolume", CurrentMusicVolume);
        PlayerPrefs.SetFloat("currentSFXVolume", CurrentSFXVolume);
        PlayerPrefs.SetInt("firstGame", FirstGame);
    }
	
    public static void Load()
    {
        CurrentGold = PlayerPrefs.GetInt("currentGold", 100);
        CurrentProgress = PlayerPrefs.GetInt("currentProgress", 1);
        CurrentLifes = PlayerPrefs.GetInt("currentLifes", 1);
        CurrentProjectileSpeed = PlayerPrefs.GetInt("currentProjectileSpeed", 0);
        FirstGame = PlayerPrefs.GetInt("firstGame", 1);
        MusicEnabled = PlayerPrefs.GetInt("musicEnabled", 1);
        SFxEnabled = PlayerPrefs.GetInt("sfxEnabled", 1);
        CurrentMusicVolume = PlayerPrefs.GetFloat("currentMusicVolume", 1f);
        CurrentSFXVolume = PlayerPrefs.GetFloat("currentSFXVolume", 1f);
    }

    public static void ClearData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}