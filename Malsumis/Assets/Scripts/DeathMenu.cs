using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour {

    public string level;

    public void Restart()
    {
        //FindObjectOfType<GameManager>().Reset();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
