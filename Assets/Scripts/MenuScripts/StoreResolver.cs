using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class StoreResolver : MonoBehaviour
{
    [SerializeField] private List<Image> lifePoints;
    [SerializeField] private List<Image> speedPoints;
    [SerializeField] private Button lifeButton;
    [SerializeField] private Button projectileSpeedButton;
    [SerializeField] private TMP_Text goldText;
    private PlayerData playerData;
    
    private void Start()
    {
        PlayerData.Load();
        RefreshStoreItems();
    }

    private void RefreshStoreItems()
    {
        RefreshLifeStars();
        RefreshSpeedPoints();
        RefreshLifeButton();
        RefreshSpeedButton();
        RefreshPlayerGoldText();
    }

    private void RefreshPlayerGoldText()
    {
        goldText.text = PlayerData.CurrentGold.ToString();
    }
    
    private void RefreshLifeStars()
    {
        foreach (var life in lifePoints)
        {
            life.enabled = false;
        }

        for (int i = 0; i < PlayerData.CurrentLifes; i++)
        {
            lifePoints[i].enabled = true;
        }
    }
    
    private void RefreshSpeedPoints()
    {
        foreach (var point in speedPoints)
        {
            point.enabled = false;
        }

        for (int i = 0; i < PlayerData.CurrentProjectileSpeed; i++)
        {
            speedPoints[i].enabled = true;
        }
    }

    private void RefreshLifeButton()
    {
        bool value = PlayerData.CurrentGold - 100 < 0 || PlayerData.CurrentLifes == 3;
        lifeButton.interactable = !value;
    }
    
    private void RefreshSpeedButton()
    {
        bool value = PlayerData.CurrentGold - 50 < 0 || PlayerData.CurrentProjectileSpeed == 3;
        projectileSpeedButton.interactable = !value;
    }

    public void BuySpeedUpgrade()
    {
        PlayerData.CurrentGold -= 50;
        PlayerData.CurrentProjectileSpeed += 1;
        PlayerData.Save();
        RefreshStoreItems();
    }
    
    public void BuyLifeUpgrade()
    {
        PlayerData.CurrentGold -= 100;
        PlayerData.CurrentLifes += 1;
        PlayerData.Save();
        RefreshStoreItems();
    }
}
