using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public Toggle fullscreenToggle;
    public Dropdown resDropdown;
    public Slider musicSlider;
    public Button saveButton;

    public Resolution[] resolutions;
    public GameSettings gameSettings;


    void OnEnable()
    {
        gameSettings = new GameSettings();

        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(); });
        resDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        musicSlider.onValueChanged.AddListener(delegate { OnVolumeChange(); });
        saveButton.onClick.AddListener(delegate { OnSaveButtonClick(); });

        resolutions = Screen.resolutions;
        foreach(Resolution res in resolutions)
        {
            resDropdown.options.Add(new Dropdown.OptionData(
                res.ToString()));
        }

        LoadSettings();
    }

    public void OnFullscreenToggle()
    {
       gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resDropdown.value].width, resolutions[resDropdown.value].height, Screen.fullScreen);
        gameSettings.resIndex = resDropdown.value;
    }

    public void OnVolumeChange()
    {
        gameSettings.musicVolume = musicSlider.value;
    }

    public void OnSaveButtonClick()
    {
        SaveSettings();
    }

    public void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);
    }

    public void LoadSettings()
    {
        gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));

        musicSlider.value = gameSettings.musicVolume;
        resDropdown.value = gameSettings.resIndex;
        fullscreenToggle.isOn = gameSettings.fullscreen;
        Screen.fullScreen = gameSettings.fullscreen;

        resDropdown.RefreshShownValue();
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
