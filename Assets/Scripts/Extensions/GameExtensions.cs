using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public static class GameExtensions
{
    public static Vector2 screenSize;
    
    public static Vector3 ScreenToWorldPoint3(this Vector2 vector)
    {
        return Camera.main.ScreenToWorldPoint(vector);
    }
    
    public static Vector2 ScreenToWorldPoint2(this Vector2 vector)
    {
        return Camera.main.ScreenToWorldPoint(vector);
    }
}
