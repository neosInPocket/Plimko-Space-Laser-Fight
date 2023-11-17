using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour player;
    [SerializeField] private ProgressBar progressBar;
    private PlayerData playerData;
    
    private void Start()
    {
        player.PlayerDamage += PlayerRecievedDamage;
        player.GoldCollected += PlayerGoldCollecterHandler;
        Restart();
    }

    public void Restart()
    {
        playerData = new PlayerData(false);
        progressBar.SetLevelText(playerData.CurrentGameProgress);
        progressBar.FillImage(0f);
        progressBar.FillHealthBar((float)playerData.CurrentLifePoints / 3f);
    }

    private void PlayerRecievedDamage(int lifesLeft)
    {
        progressBar.FillHealthBar((float)lifesLeft / 3f);
    }

    private void PlayerGoldCollecterHandler(int resultPoints)
    {
        var playerMaxPoints = LevelPointsCreator.LevelPoints();
        if (resultPoints >= playerMaxPoints)
        {
            progressBar.FillImage(1f);
        }
        else
        {
            progressBar.FillImage((float)(player.CurrentPoints) / (float)playerMaxPoints);
        }
    }

    private void OnDestroy()
    {
        if (player != null)
        {
            player.PlayerDamage -= PlayerRecievedDamage;
            player.GoldCollected -= PlayerGoldCollecterHandler;
        }
    }
}
