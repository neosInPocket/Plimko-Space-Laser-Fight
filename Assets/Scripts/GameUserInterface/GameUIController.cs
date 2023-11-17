using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour player;
    [SerializeField] private ProgressBar progressBar;
    [SerializeField] private TutorialWindowDialog tutorialWindowDialog;
    [SerializeField] private Counting counting;
    [SerializeField] private MainGameFlow mainGameFlow;
    [SerializeField] private AfterGameScreen afterGameScreen;
    
    private void Start()
    {
        player.PlayerDamage += PlayerRecievedDamage;
        player.GoldCollected += PlayerGoldCollecterHandler;
        Restart();
    }

    public void Restart()
    {
        afterGameScreen.gameObject.SetActive(false);
        mainGameFlow.ResetGame();
        
        PlayerData.Load();
        progressBar.SetLevelText(PlayerData.CurrentProgress);
        progressBar.FillImage(0f);
        progressBar.FillHealthBar((float)PlayerData.CurrentLifes / 3f);

        if (PlayerData.FirstGame == 1)
        {
            PlayerData.FirstGame = 0;
            PlayerData.Save();
            
            tutorialWindowDialog.gameObject.SetActive(true);
            tutorialWindowDialog.TutorialCompleted += TutorialCompleted;
        }
        else
        {
            counting.CountingCompleted += CountingCompleted;
            counting.gameObject.SetActive(true);
        }
    }

    private void CountingCompleted()
    {
        counting.gameObject.SetActive(false);
        counting.CountingCompleted -= CountingCompleted;
        mainGameFlow.StartGame();
    }

    private void TutorialCompleted()
    {
        tutorialWindowDialog.TutorialCompleted -= TutorialCompleted;
        counting.CountingCompleted += CountingCompleted;
        counting.gameObject.SetActive(true);
    }

    private void PlayerRecievedDamage(int lifesLeft)
    {
        if (lifesLeft <= 0)
        {
            afterGameScreen.gameObject.SetActive(true);
            afterGameScreen.ShowResult(false);
        }
        
        progressBar.FillHealthBar((float)lifesLeft / 3f);
    }

    private void PlayerGoldCollecterHandler(int resultPoints)
    {
        var playerMaxPoints = LevelPointsCreator.LevelPoints();
        var reward = LevelPointsCreator.LevelRewardCoins();
        if (resultPoints >= playerMaxPoints)
        {
            progressBar.FillImage(1f);
            afterGameScreen.gameObject.SetActive(true);
            afterGameScreen.ShowResult(true, reward);
            PlayerData.CurrentProgress++;
            PlayerData.CurrentGold += reward;
            PlayerData.Save();
            player.Disable();
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

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
