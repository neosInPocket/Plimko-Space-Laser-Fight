using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleButtonsAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform playButton;
    [SerializeField] private RectTransform settingsButton;
    [SerializeField] private RectTransform storeButton;
    [SerializeField] private CanvasGroup playCanvasGroup;
    [SerializeField] private CanvasGroup settingsCanvasGroup;
    [SerializeField] private CanvasGroup storeCanvasGroup;
    [SerializeField] private RectTransform storeIcon;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Color targetColor;
    [SerializeField] private float fadeSpeed;
    [SerializeField] private float threshold;
    [SerializeField] private float buttonsThreshold;
    
    [Header(header: "Panels animations")]
    [SerializeField] private CanvasGroup playPanelCanvasGroup;
    [SerializeField] private CanvasGroup settingsPanelCanvasGroup;
    [SerializeField] private CanvasGroup storePanelCanvasGroup;
    [SerializeField] private float panelFadeSpeed;
    [SerializeField] private float panelsThreshold = 0.01f;

    private void Start()
    {
        playPanelCanvasGroup.alpha = 1f;
        settingsPanelCanvasGroup.alpha = 0;
        storePanelCanvasGroup.alpha = 0;
        LoadStartScreenAnimation();
    }

    public void LoadStartScreenAnimation()
    {
        StartCoroutine(EnableStartAnimation());
    }

    public void LoadSettingsScreenAnimation()
    {
        StartCoroutine(EnableSettingsAnimation());
    }
    
    public void LoadStoreScreenAnimation()
    {
        StartCoroutine(EnableStoreAnimation());
    }
    
    public void LoadPlayScreenAnimation()
    {
        StartCoroutine(EnablePlayAnimation());
    }

    public void StoreToStartPanel()
    {
        StartCoroutine(StoreToStartPanelAnimation());
    }

    public void SettingsToStartPanel()
    {
        StartCoroutine(SettingsToStartPanelAnimation());
    }

    private IEnumerator EnableStartAnimation()
    {
        playPanelCanvasGroup.blocksRaycasts = false;
        settingsPanelCanvasGroup.blocksRaycasts = false;
        storePanelCanvasGroup.blocksRaycasts = false;
        storeButton.rotation = Quaternion.Euler(0, 0, -120);
        settingsButton.rotation = Quaternion.Euler(0, 0, 120);
        playButton.rotation = Quaternion.Euler(0, 0, 0);
        storeIcon.rotation = Quaternion.Euler(0, 0, 120);
        storeCanvasGroup.alpha = 0;
        playCanvasGroup.alpha = 0;
        settingsCanvasGroup.alpha = 0;

        while (settingsButton.rotation.eulerAngles.z < 121)
        {
            var distance = Mathf.Abs(settingsButton.rotation.eulerAngles.z);
            
            storeButton.rotation = Quaternion.Euler(0, 0, storeButton.rotation.eulerAngles.z + (rotationSpeed *
                (distance + threshold) / 120 * Time.deltaTime));
            settingsButton.rotation = Quaternion.Euler(0, 0, settingsButton.rotation.eulerAngles.z - (rotationSpeed * (distance + threshold) / 120 * Time.deltaTime));
            storeIcon.rotation = Quaternion.Euler(0, 0, storeIcon.rotation.eulerAngles.z + (rotationSpeed * (distance + threshold) / 120 * Time.deltaTime));
            playCanvasGroup.alpha += (fadeSpeed * (playCanvasGroup.alpha + buttonsThreshold) * Time.deltaTime);
            storeCanvasGroup.alpha += (fadeSpeed * (storeCanvasGroup.alpha + buttonsThreshold) * Time.deltaTime);
            settingsCanvasGroup.alpha += (fadeSpeed * (settingsCanvasGroup.alpha + buttonsThreshold) * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        
        storeButton.rotation = Quaternion.Euler(0, 0, 0);
        settingsButton.rotation = Quaternion.Euler(0, 0, 0);
        storeCanvasGroup.alpha = 1;
        playCanvasGroup.alpha = 1;
        settingsCanvasGroup.alpha = 1;
        playPanelCanvasGroup.blocksRaycasts = true;
    }
    
    private IEnumerator EnableSettingsAnimation()
    {
        playPanelCanvasGroup.blocksRaycasts = false;
        settingsPanelCanvasGroup.blocksRaycasts = false;
        storePanelCanvasGroup.blocksRaycasts = false;
        
        while (settingsButton.rotation.eulerAngles.z < 120)
        {
            var distance = Mathf.Abs(120 - settingsButton.rotation.eulerAngles.z);
            
            storeButton.rotation = Quaternion.Euler(0, 0, storeButton.rotation.eulerAngles.z - (rotationSpeed * (distance + threshold) / 120 * Time.deltaTime));
            settingsButton.rotation = Quaternion.Euler(0, 0, settingsButton.rotation.eulerAngles.z + (rotationSpeed * (distance + threshold) / 120 * Time.deltaTime));
            storeIcon.rotation = Quaternion.Euler(0, 0, storeIcon.rotation.eulerAngles.z + (rotationSpeed * (distance + threshold) / 120 * Time.deltaTime));
            playCanvasGroup.alpha -= fadeSpeed * (playCanvasGroup.alpha + buttonsThreshold) * Time.deltaTime;
            storeCanvasGroup.alpha -= fadeSpeed * (storeCanvasGroup.alpha + buttonsThreshold) * Time.deltaTime;
            
            yield return new WaitForEndOfFrame();
        }
        
        storeButton.rotation = Quaternion.Euler(0, 0, -120);
        playButton.rotation = Quaternion.Euler(0, 0, 0);
        settingsButton.rotation = Quaternion.Euler(0, 0, 120);
        storeCanvasGroup.alpha = 0;
        playCanvasGroup.alpha = 0;
        
        while (playPanelCanvasGroup.alpha > 0)
        {
            playPanelCanvasGroup.alpha -= panelFadeSpeed * (playPanelCanvasGroup.alpha + panelsThreshold) * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        
        while (settingsPanelCanvasGroup.alpha < 1)
        {
            settingsPanelCanvasGroup.alpha += panelFadeSpeed * (1 - (settingsPanelCanvasGroup.alpha - panelsThreshold)) * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        
        settingsPanelCanvasGroup.blocksRaycasts = true;
    }
    
    private IEnumerator EnablePlayAnimation()
    {
        playPanelCanvasGroup.blocksRaycasts = false;
        settingsPanelCanvasGroup.blocksRaycasts = false;
        storePanelCanvasGroup.blocksRaycasts = false;
        
        while (settingsButton.rotation.eulerAngles.z < 120)
        {
            var distance = Mathf.Abs(120 - settingsButton.rotation.eulerAngles.z);
            
            storeButton.rotation = Quaternion.Euler(0, 0, storeButton.rotation.eulerAngles.z - (rotationSpeed *
                (distance + threshold) / 120 * Time.deltaTime));
            settingsButton.rotation = Quaternion.Euler(0, 0, settingsButton.rotation.eulerAngles.z + (rotationSpeed * (distance + threshold) / 120 * Time.deltaTime));
            storeIcon.rotation = Quaternion.Euler(0, 0, storeIcon.rotation.eulerAngles.z + (rotationSpeed * (distance + threshold) / 120 * Time.deltaTime));
            settingsCanvasGroup.alpha = settingsCanvasGroup.alpha - (fadeSpeed * (settingsCanvasGroup.alpha + buttonsThreshold) * Time.deltaTime);
            storeCanvasGroup.alpha = storeCanvasGroup.alpha - (fadeSpeed * (storeCanvasGroup.alpha + buttonsThreshold) * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        
        storeButton.rotation = Quaternion.Euler(0, 0, -120);
        playButton.rotation = Quaternion.Euler(0, 0, 0);
        settingsButton.rotation = Quaternion.Euler(0, 0, 120);
        storeCanvasGroup.alpha = 0;
        settingsCanvasGroup.alpha = 0;
        SceneManager.LoadScene("GameScene");
    }
    
    private IEnumerator EnableStoreAnimation()
    {
        playPanelCanvasGroup.blocksRaycasts = false;
        settingsPanelCanvasGroup.blocksRaycasts = false;
        storePanelCanvasGroup.blocksRaycasts = false;
        
        while (settingsButton.rotation.eulerAngles.z < 120)
        {
            var distance = Mathf.Abs(120 - settingsButton.rotation.eulerAngles.z);
            
            storeButton.rotation = Quaternion.Euler(0, 0, storeButton.rotation.eulerAngles.z - (rotationSpeed * (distance + threshold) / 120 * Time.deltaTime));
            settingsButton.rotation = Quaternion.Euler(0, 0, settingsButton.rotation.eulerAngles.z + (rotationSpeed * (distance + threshold) / 120 * Time.deltaTime));
            storeIcon.rotation = Quaternion.Euler(0, 0, storeIcon.rotation.eulerAngles.z + (rotationSpeed * (distance + threshold) / 120 * Time.deltaTime));
            playCanvasGroup.alpha = playCanvasGroup.alpha - (fadeSpeed * (playCanvasGroup.alpha + buttonsThreshold) * Time.deltaTime);
            settingsCanvasGroup.alpha = settingsCanvasGroup.alpha - (fadeSpeed * (settingsCanvasGroup.alpha + buttonsThreshold) * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        
        storeButton.rotation = Quaternion.Euler(0, 0, -120);
        playButton.rotation = Quaternion.Euler(0, 0, 0);
        settingsButton.rotation = Quaternion.Euler(0, 0, 120);
        settingsCanvasGroup.alpha = 0;
        playCanvasGroup.alpha = 0;
        
        while (playPanelCanvasGroup.alpha > 0)
        {
            playPanelCanvasGroup.alpha -= panelFadeSpeed * (playPanelCanvasGroup.alpha + panelsThreshold) * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        
        while (storePanelCanvasGroup.alpha < 1)
        {
            storePanelCanvasGroup.alpha += panelFadeSpeed * (1 - (storePanelCanvasGroup.alpha - panelsThreshold)) * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        
        storePanelCanvasGroup.blocksRaycasts = true;
    }
    
    private IEnumerator StoreToStartPanelAnimation()
    {
        playPanelCanvasGroup.blocksRaycasts = false;
        settingsPanelCanvasGroup.blocksRaycasts = false;
        storePanelCanvasGroup.blocksRaycasts = false;
        
        while (storePanelCanvasGroup.alpha > 0)
        {
            storePanelCanvasGroup.alpha -= panelFadeSpeed * (1 - (storePanelCanvasGroup.alpha - panelsThreshold)) * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        storePanelCanvasGroup.alpha = 0;
        playPanelCanvasGroup.alpha = 1;
        
        StartCoroutine(EnableStartAnimation());
    }
    
    private IEnumerator SettingsToStartPanelAnimation()
    {
        playPanelCanvasGroup.blocksRaycasts = false;
        settingsPanelCanvasGroup.blocksRaycasts = false;
        storePanelCanvasGroup.blocksRaycasts = false;
        
        while (settingsPanelCanvasGroup.alpha > 0)
        {
            settingsPanelCanvasGroup.alpha -= panelFadeSpeed * (1 - (settingsPanelCanvasGroup.alpha - panelsThreshold)) * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        settingsPanelCanvasGroup.alpha = 0;
        playPanelCanvasGroup.alpha = 1;
        
        StartCoroutine(EnableStartAnimation());
    }
}
