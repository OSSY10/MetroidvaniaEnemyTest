using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenuPanel;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            pauseMenuPanel.SetActive(isPaused);
            Time.timeScale = isPaused ? 0 : 1;
        }
    }

    public void Resume()
    {
        isPaused = false;
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1;
    }

    [SerializeField] private string mainMenu = "Start";

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}


