using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject optionsPanel;

    bool isPaused = false;
    bool isOptions = false;

    public void ResetScene(int SceneID)
    {
        SceneManager.LoadScene(SceneID);
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
            ResetScene(SceneManager.GetActiveScene().buildIndex);
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

    public void Exit()
    {

    }

}
