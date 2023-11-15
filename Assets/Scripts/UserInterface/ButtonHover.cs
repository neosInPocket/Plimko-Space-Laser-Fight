using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image icon;
    [SerializeField] private float scaleAmount = 1.2f;
    [SerializeField] private float scaleStep = 0.005f;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(ScaleFade(scaleAmount));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(ScaleFade(1f));
    }

    private IEnumerator ScaleFade(float scaleAmount)
    {
        var scale = icon.rectTransform.localScale;

        if (scale.x > scaleAmount)
        {
            while (icon.rectTransform.localScale.x > scaleAmount)
            {
                var localScale = icon.rectTransform.localScale;
                var distance = Mathf.Abs(scaleAmount - localScale.x);  
                icon.rectTransform.localScale = new Vector3(localScale.x - (scaleStep * distance + 0.05f), localScale.y - scaleStep, localScale.z);
                yield return new WaitForFixedUpdate();
            }
        }
        else
        {
            while (icon.rectTransform.localScale.x < scaleAmount)
            {
                var localScale = icon.rectTransform.localScale;
                var distance = Mathf.Abs(scaleAmount - localScale.x);  
                icon.rectTransform.localScale = new Vector3(localScale.x + (scaleStep * distance + 0.05f), localScale.y + scaleStep, localScale.z);
                yield return new WaitForFixedUpdate();
            }
        }

        icon.rectTransform.localScale = new Vector3(scaleAmount, scaleAmount, icon.rectTransform.localScale.z);
    }
}
