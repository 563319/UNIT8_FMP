using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EndScreenScript : MonoBehaviour
{
    [SerializeField] GameObject endScreen;
    //[SerializeField] GameObject uI;
    public GameObject newButtonHome;
    public void Pause()
    {

        endScreen.SetActive(true);
        //uI.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(newButtonHome);
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
