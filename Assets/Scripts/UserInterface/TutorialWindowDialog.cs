using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class TutorialWindowDialog : MonoBehaviour
{
    [SerializeField] private TMP_Text characterDialogText;
    [SerializeField] private float textTime = 2;
    private string currentText;
    private Action<Finger> nextReply;
    public Action TutorialCompleted;
    
    private void Start()
    {
        EnhancedTouchSupport.Enable();
        TouchSimulation.Enable();
        characterDialogText.text = "WELCOME TO TIGER BRIDGE BUILDER!";
        
        Touch.onFingerDown += Reply1;
    }

    private void Reply1(Finger finger)
    {
        currentText = "dash your ball by shooting projectile in the direction of the blue sphere, when it hits it, your ball will teleport to its place";
        nextReply = Reply2;
        StartCoroutine(CharacterTextRoutine(currentText));
        
        Touch.onFingerDown -= Reply1;
        Touch.onFingerDown += NoReply;
    }
    
    private void Reply2(Finger finger)
    {
        Touch.onFingerDown -= NoReply;
        currentText = "beware of the red spheres that attract your projectiles to themselves";
        nextReply = Reply3;
        StartCoroutine(CharacterTextRoutine(currentText));
        
        Touch.onFingerDown -= Reply2;
        Touch.onFingerDown += NoReply;
    }
    
    private void Reply3(Finger finger)
    {
        Touch.onFingerDown -= NoReply;
        currentText = "in this case, try to calculate the trajectory of the bullet in such a way as to hit the blue sphere";
        nextReply = Reply4;
        StartCoroutine(CharacterTextRoutine(currentText));
        
        Touch.onFingerDown -= Reply3;
        Touch.onFingerDown += NoReply;
    }
    
    private void Reply4(Finger finger)
     {
         Touch.onFingerDown -= NoReply;
         currentText = "dash your ball by shooting projectile in the direction of the blue sphere, when it hits it, your ball will teleport to its place";
         nextReply = Reply5;
         StartCoroutine(CharacterTextRoutine(currentText));
         
         Touch.onFingerDown -= Reply4;
         Touch.onFingerDown += NoReply;
     }
    
    private void Reply5(Finger finger)
    {
        Touch.onFingerDown -= NoReply;
        currentText = "collect coins, complete levels and buy various upgrades in the store";
        nextReply = FinalReply;
        StartCoroutine(CharacterTextRoutine(currentText));
        
        Touch.onFingerDown -= Reply5;
        Touch.onFingerDown += NoReply;
    }
    
    private void FinalReply(Finger finger)
    {
        Touch.onFingerDown -= NoReply;
        currentText = "good luck!";
        StartCoroutine(CharacterTextRoutine(currentText));
        Touch.onFingerDown -= FinalReply;
        Touch.onFingerDown += DisableReply;
    }

    private void DisableReply(Finger finger)
    {
        Touch.onFingerDown -= DisableReply;
        TutorialCompleted?.Invoke();
        gameObject.SetActive(false);
    }

    private void NoReply(Finger finger)
    {
        StopAllCoroutines();
        Touch.onFingerDown -= NoReply;
        characterDialogText.text = currentText;
        Touch.onFingerDown += nextReply;
    }
    
    private IEnumerator CharacterTextRoutine(string text)
    {
        StringBuilder stringBuilder = new StringBuilder();
        float delay = textTime / text.Length;
        
        foreach (var character in text)
        {
            stringBuilder.Append(character);
            characterDialogText.text = stringBuilder.ToString();
            yield return new WaitForSeconds(delay);
        }

        Touch.onFingerDown -= NoReply;
        Touch.onFingerDown += nextReply;
    }
}
