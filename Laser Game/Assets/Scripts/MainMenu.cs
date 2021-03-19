using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject levelsPanel;

    bool isLevels = false;
    bool isOptions = false;

    private void Update()
    {
        if ((isOptions || isLevels) && Input.GetKeyDown(KeyCode.Escape))
        {
            isLevels = false;
            isOptions = false;

            optionsPanel.SetActive(false);
            levelsPanel.SetActive(false);
        }
        
        
        if (isLevels)
        {
            levelsPanel.SetActive(isLevels);
        }
        else
        {
            levelsPanel.SetActive(isLevels);
        }

        if (isOptions)
        {
            optionsPanel.SetActive(isOptions);
        }
        else
        {
            optionsPanel.SetActive(isOptions);
        }
    }

    public void LevelsGame()
    {
        isLevels = !isLevels;
    }

    public void OptionsGame()
    {
        isOptions = !isOptions;
    }

    public void exitGame()
    {
        Application.Quit();
    }


    //Now options menu functionality


    public AudioMixer Master;
    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetSFXLvl(float sfxLvl)
    {
        Master.SetFloat("sfxVol", sfxLvl);
    }

    public void SetMusicLvl(float musicLvl)
    {
        Master.SetFloat("musicVol", musicLvl);
    }

    public void setGraphics(int graphicsIndex)
    {
        QualitySettings.SetQualityLevel(graphicsIndex);
    }

    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
