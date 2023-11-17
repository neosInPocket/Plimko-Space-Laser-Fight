using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameFlow : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour player;
    
    private PlayerData playerData;
    
    private void Start()
    {
        playerData = new PlayerData(false);
    }

    public void ResetGame()
    {
        player.ResetPlayer();
    }

    public void StartGame()
    {
        player.Enable();
    }
}
