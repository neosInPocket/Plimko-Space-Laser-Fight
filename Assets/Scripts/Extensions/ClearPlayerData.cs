using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPlayerData : MonoBehaviour
{
    [SerializeField] private bool isDelete;
    
    private void Awake()
    {
        PlayerData playerData = new PlayerData(isDelete);
    }
}
