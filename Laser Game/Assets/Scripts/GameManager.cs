using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject optionsPanel;

    bool isPaused = false;
    bool isOptions = false;

    //The real management part

    public void ResetScene()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        isPaused = false;
    }

    private void Update()
    {
        if(!isOptions && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        else if(isOptions && Input.GetKeyDown(KeyCode.Escape))
        {
            OptionsGame();
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetScene();
        }

        if (isPaused)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(isPaused);
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(isPaused);
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

    public void PauseGame()
    {
        isPaused = !isPaused;        
    }

    public void OptionsGame()
    {
        isOptions = !isOptions;
    }

    public void exitMenu(int MenuScene)
    {
        SceneManager.LoadScene(MenuScene);
    }

    public void NextLevel(int next)
    {
        SceneManager.LoadScene(next);
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

        for(int i = 0; i < resolutions.Length; i++)
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

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetSFXLvl(float sfxLvl)
    {
        Master.SetFloat("sfxVol", sfxLvl);
    }

    public void SetMusicLvl(float musicLvl)
    {
        Master.SetFloat("musicVol", musicLvl);
    }

    public void setGraphics (int graphicsIndex)
    {
        QualitySettings.SetQualityLevel(graphicsIndex);
    }

    public void setFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
        
}
