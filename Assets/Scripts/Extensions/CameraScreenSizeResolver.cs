using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreenSizeResolver : MonoBehaviour
{
    private void Start()
    {
        var screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        GameExtensions.screenSize = screenSize;
    }
}
