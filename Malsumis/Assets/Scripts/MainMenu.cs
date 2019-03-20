using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string level;
    public GameObject fade;

    public void Play()
    {
        StartCoroutine(fadeWait(1f, fade, level));
    }

    public void LoadScene(string sceneName)
    {
        print("Load");
        StartCoroutine(fadeWait(1f, fade, sceneName));
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator fadeWait(float time, GameObject fade, string sceneName)
    {
        fade.SetActive(true);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneName);
    }
}
