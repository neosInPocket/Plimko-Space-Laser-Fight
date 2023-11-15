
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsTransparency : MonoBehaviour
{
    [SerializeField] private Image[] buttons;

    private void Start()
    {
        foreach (var button in buttons)
        {
            button.alphaHitTestMinimumThreshold = 1f;
        }
    }
}
