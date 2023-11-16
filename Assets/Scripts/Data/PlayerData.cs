using UnityEngine;

public class PlayerData
{
    private int currentGameProgress;
    private int currentGold;
    private int currentLifePoints;
    private int currentProjectileSpeedPoints;
    private float currentMusicVolume;
    private float currentSFxVolume;
    private int musicEnabled;
    private int sFxEnabled;
    private int tutorialEnabled;

    public int CurrentGameProgress
    {
        get => currentGameProgress;
        set => currentGameProgress = value;
    }
    
    public int CurrentGold
    {
        get => currentGold;
        set => currentGold = value;
    }
    
    public int CurrentLifePoints
    {
        get => currentLifePoints;
        set => currentLifePoints = value;
    }
    
    public int CurrentProjectileSpeedPoints
    {
        get => currentProjectileSpeedPoints;
        set => currentProjectileSpeedPoints = value;
    }
    
    public float CurrentMusicVolume
    {
        get => currentMusicVolume;
        set => currentMusicVolume = value;
    }
    
    public float CurrentSFxVolume
    {
        get => currentSFxVolume;
        set => currentSFxVolume = value;
    }

    public int MusicEnabled
    {
        get => musicEnabled;
        set => musicEnabled = value;
    }
    
    public int SFxEnabled
    {
        get => sFxEnabled;
        set => sFxEnabled = value;
    }
    
    public PlayerData(bool isClearData)
    {
        if (isClearData)
        {
            ClearPlayerData();
            SavePlayerData();
        }
        else
        {
            currentGameProgress = PlayerPrefs.GetInt("currentGameProgress", 1);
            currentGold = PlayerPrefs.GetInt("currentGold", 100);
            currentLifePoints = PlayerPrefs.GetInt("currentLifePoints", 1);
            currentProjectileSpeedPoints = PlayerPrefs.GetInt("currentProjectileSpeedPoints", 0);
            currentMusicVolume = PlayerPrefs.GetFloat("currentMusicVolume", 1f);
            currentSFxVolume = PlayerPrefs.GetFloat("currentSFxVolume", 1f);
            
            musicEnabled = PlayerPrefs.GetInt("musicEnabled", 1);
            sFxEnabled = PlayerPrefs.GetInt("sFxEnabled", 1);
        }
        
    }

    public void SavePlayerData()
    {
        PlayerPrefs.SetInt("currentGameProgress", CurrentGameProgress);
        PlayerPrefs.SetInt("currentGold", CurrentGold);
        PlayerPrefs.SetInt("currentLifePoints", CurrentLifePoints);
        PlayerPrefs.SetInt("currentProjectileSpeedPoints", CurrentProjectileSpeedPoints);
        PlayerPrefs.SetFloat("currentMusicVolume", CurrentMusicVolume);
        PlayerPrefs.SetFloat("currentSFxVolume", CurrentSFxVolume);
        
        PlayerPrefs.SetInt("musicEnabled", MusicEnabled);
        PlayerPrefs.SetInt("sFxEnabled", SFxEnabled);
    }

    private void ClearPlayerData()
    {
        PlayerPrefs.DeleteAll();
    }
}
