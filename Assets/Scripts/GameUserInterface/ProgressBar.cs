using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private Image healthImage;
    [SerializeField] private TMP_Text levelText;

    public void FillImage(float fillAmount)
    {
        fillImage.fillAmount = fillAmount;
    }

    public void SetLevelText(int level)
    {
        if (level < 10)
        {
            levelText.text = "0" + level;
        }
        else
        {
            levelText.text = level.ToString();
        }
    }

    public void FillHealthBar(float fillValue)
    {
        healthImage.fillAmount = fillValue;
    }
}
