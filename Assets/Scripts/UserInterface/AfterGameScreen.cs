using TMPro;
using UnityEngine;

public class AfterGameScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text retryButtonText;
    [SerializeField] private TMP_Text rewardText;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private GameObject tryAgainNextTimeText;
    [SerializeField] private GameObject coinsContainer;
    
    public void ShowResult(bool isWon, int coins = 0)
    {
        if (!isWon)
        {
            retryButtonText.text = "RETRY";
            resultText.text = "YOU LOSE";
            coinsContainer.gameObject.SetActive(false);
            tryAgainNextTimeText.gameObject.SetActive(true);
        }
        else
        {
            retryButtonText.text = "NEXT LEVEL";
            resultText.text = "YOU WIN";
            coinsContainer.gameObject.SetActive(true);
            rewardText.text = "+" + coins.ToString();
            tryAgainNextTimeText.gameObject.SetActive(false);
        }
    }
}
