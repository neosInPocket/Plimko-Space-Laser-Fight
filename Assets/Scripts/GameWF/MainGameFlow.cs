using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameFlow : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour player;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private ProjectileShooter projectileShooter;
    
    
    private void Start()
    {
        PlayerData.Load();
        player.ResetPlayer();
    }

    public void ResetGame()
    {
        enemySpawner.DestroyObjects();
        enemySpawner.Restart();
        player.ResetPlayer();
        projectileShooter.Restart();
    }

    public void StartGame()
    {
        player.Enable();
    }
}
