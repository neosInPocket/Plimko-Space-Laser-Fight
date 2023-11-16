using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEdgesZone : MonoBehaviour
{
    [SerializeField] private SpriteRenderer right;
    [SerializeField] private SpriteRenderer left;
    [SerializeField] private SpriteRenderer bottom;
    [SerializeField] private SpriteRenderer top;

    private void Awake()
    {
        var screenSize = GameExtensions.screenSize;
        var cameraPosition = Camera.main.transform.position;
        
        var edgeSize = Vector2.one;
        right.size = new Vector2(right.size.x, screenSize.y * 2);
        right.transform.position = new Vector2(cameraPosition.x + screenSize.x + edgeSize.x / 2, cameraPosition.y);

        left.size = new Vector2(left.size.x, screenSize.y * 2);
        left.transform.position = new Vector2(cameraPosition.x + -screenSize.x - edgeSize.x / 2, cameraPosition.y);
        
        top.size = new Vector2(screenSize.x * 2, top.size.y);
        top.transform.position = new Vector2(cameraPosition.x, cameraPosition.y + screenSize.y + edgeSize.y / 2);
        
        bottom.size = new Vector2(screenSize.x * 2, bottom.size.y);
        bottom.transform.position = new Vector2(cameraPosition.x, cameraPosition.y + -screenSize.y - edgeSize.y / 2);
    }
}
