using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class CameraFollowBehaviour : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float offset;
    [SerializeField] private float threshold;
    [SerializeField] private float cameraSpeed;

    private void Awake()
    {
        Debug.Log(Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)));
    }

    private void Update()
    {
        var distance = target.position.y + offset - transform.position.y;
        var magnitude = Mathf.Abs(distance);
        if (magnitude < threshold) return;

        var direction = distance / magnitude;
        var position = transform.position;
        position.y += direction * ((cameraSpeed + threshold) * magnitude * Time.deltaTime);
        transform.position = position;
    }
}
