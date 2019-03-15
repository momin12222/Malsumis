using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public string level;
    public GameObject pauseMenu;
    public GameObject pauseImg;
    public GameObject deathImg;
    public Button resume;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            Resume();
        }
        else if (GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().currentHP == 0)
        {
            Death();
        }
    }

    public void Death()
    {
        pauseImg.SetActive(false);
        deathImg.SetActive(true);
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        resume.gameObject.SetActive(false);
    }

    public void Pause()
    {
        pauseImg.SetActive(true);
        deathImg.SetActive(false);
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        resume.gameObject.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void Continue(GameObject obj)
    {
        Time.timeScale = 1f;
        obj.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(level);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
