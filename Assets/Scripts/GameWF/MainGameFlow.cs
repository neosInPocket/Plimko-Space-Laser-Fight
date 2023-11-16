using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameFlow : MonoBehaviour
{
    private PlayerData playerData;
    
    private void Awake()
    {
        playerData = new PlayerData(false);
    }
}
