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

    private float screenSizeX;
    private float screenSizeY;
    
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

    // public Vector2 ScreenSize
    // {
    //     get => new Vector2(screenSizeX, screenSizeY);
    //     set
    //     {
    //         screenSizeX = value.x;
    //         screenSizeY = value.y;
    //     }
    // }
    
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
            screenSizeX = PlayerPrefs.GetFloat("screenSizeX", 0);
            screenSizeY = PlayerPrefs.GetFloat("screenSizeY", 0);
        }
        
    }

    public void SavePlayerData()
    {
        PlayerPrefs.SetInt("currentGameProgress", currentGameProgress);
        PlayerPrefs.SetInt("currentGold", currentGold);
        PlayerPrefs.SetInt("currentLifePoints", currentLifePoints);
        PlayerPrefs.SetInt("currentProjectileSpeedPoints", currentProjectileSpeedPoints);
        PlayerPrefs.SetFloat("currentMusicVolume", currentMusicVolume);
        PlayerPrefs.SetFloat("currentSFxVolume", currentSFxVolume);
        
        PlayerPrefs.SetInt("musicEnabled", musicEnabled);
        PlayerPrefs.SetInt("sFxEnabled", sFxEnabled);
        
        PlayerPrefs.SetFloat("screenSizeX", screenSizeX);
        PlayerPrefs.SetFloat("screenSizeY", screenSizeY);
    }

    private void ClearPlayerData()
    {
        currentGameProgress = 1;
        currentGold = 100;
        currentLifePoints = 1;
        currentProjectileSpeedPoints = 0;
        currentMusicVolume = 1;
        currentSFxVolume = 1;
        musicEnabled = 1;
        sFxEnabled = 1;
        screenSizeX = 0;
        screenSizeY = 0;
        SavePlayerData();
    }
}
