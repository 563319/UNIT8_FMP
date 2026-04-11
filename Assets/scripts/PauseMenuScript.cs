using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    //[SerializeField] GameObject uI;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        //uI.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Home()
    {
        //reset the singelton stuff because if i dont they will persist between level loads important!, except highscore obviously
        SingletonScript.instance.score = 0;
        SingletonScript.instance.playerHealth = 200;
        SingletonScript.instance.playerAmmo = 0;
        SingletonScript.instance.playerKeys = new List<int>();
        SceneManager.LoadScene(0);
        Time.timeScale = 1;

    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        //uI.SetActive(true);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Restart()
    {
        //reset the singelton stuff because if i dont they will persist between level loads important!, except highscore obviously
        SingletonScript.instance.score = 0;
        SingletonScript.instance.playerHealth = 200;
        SingletonScript.instance.playerAmmo = 0;
        SingletonScript.instance.playerKeys = new List<int>();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
