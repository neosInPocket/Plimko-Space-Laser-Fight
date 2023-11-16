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
        playerData = new PlayerData(false);
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
        goldText.text = playerData.CurrentGold.ToString();
    }
    
    private void RefreshLifeStars()
    {
        foreach (var life in lifePoints)
        {
            life.enabled = false;
        }

        for (int i = 0; i < playerData.CurrentLifePoints; i++)
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

        for (int i = 0; i < playerData.CurrentProjectileSpeedPoints; i++)
        {
            speedPoints[i].enabled = true;
        }
    }

    private void RefreshLifeButton()
    {
        bool value = playerData.CurrentGold - 100 < 0 || playerData.CurrentLifePoints == 3;
        lifeButton.interactable = !value;
    }
    
    private void RefreshSpeedButton()
    {
        bool value = playerData.CurrentGold - 50 < 0 || playerData.CurrentProjectileSpeedPoints == 3;
        projectileSpeedButton.interactable = !value;
    }

    public void BuySpeedUpgrade()
    {
        playerData.CurrentGold -= 50;
        playerData.CurrentProjectileSpeedPoints += 1;
        playerData.SavePlayerData();
        RefreshStoreItems();
    }
    
    public void BuyLifeUpgrade()
    {
        playerData.CurrentGold -= 100;
        playerData.CurrentLifePoints += 1;
        playerData.SavePlayerData();
        RefreshStoreItems();
    }
}
