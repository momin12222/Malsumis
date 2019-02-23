using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public string level;
    public GameObject pauseMenu;
    public Text screenText;
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
            GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().currentHP = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().startHP;
        }
    }

    public void Death()
    {
        screenText.text = "Death";
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        resume.gameObject.SetActive(false);
    }

    public void Pause()
    {
        screenText.text = "Pause";
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        resume.gameObject.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(level);
        pauseMenu.SetActive(false);
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
