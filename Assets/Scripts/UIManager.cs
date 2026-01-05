using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Main Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject settingsPanel;

    [Header("Settings Sub Panels")]
    [SerializeField] private GameObject displaySettingsPanel;
    [SerializeField] private GameObject audioSettingsPanel;
    [SerializeField] private GameObject controlsSettingsPanel;

    private void Start()
    {
        OpenMainMenu();
    }

    public void OpenMainMenu()
    {
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("TwoD");
    }

    public void OpenSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);

        OpenSettingsRoot();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void OpenSettingsRoot()
    {
        displaySettingsPanel.SetActive(false);
        audioSettingsPanel.SetActive(false);
        controlsSettingsPanel.SetActive(false);
    }

    public void OpenDisplaySettings()
    {
        OpenSettingsRoot();
        displaySettingsPanel.SetActive(true);
    }

    public void OpenAudioSettings()
    {
        OpenSettingsRoot();
        audioSettingsPanel.SetActive(true);
    }

    public void OpenControlsSettings()
    {
        OpenSettingsRoot();
        controlsSettingsPanel.SetActive(true);
    }

    public void BackToSettingsMenu()
    {
        OpenSettingsRoot();
    }

    public void BackToMainMenu()
    {
        OpenMainMenu();
    }
}
