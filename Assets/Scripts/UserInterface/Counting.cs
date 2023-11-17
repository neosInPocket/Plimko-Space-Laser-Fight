using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counting : MonoBehaviour
{
    public Action CountingCompleted;

    public void InvokeCompleted()
    {
        CountingCompleted?.Invoke();
    }
}
