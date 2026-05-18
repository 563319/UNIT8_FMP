using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject newButtonOptions;
    public GameObject newButtonQuit;
    public GameObject newButtonHelp;
    public GameObject newButtonMain;

    /*
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
    */
    AudioManagerScript audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
    }



    public void playGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlayUIsound()
    {

        audioManager.PlaySFX(audioManager.UiClick);
    }
    public void PlayUIsound2()
    {
        audioManager.PlaySFX(audioManager.UiClick2);
    }

    public void ReassignOptions()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(newButtonOptions);
    }
    public void ReassignQuit()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(newButtonQuit);
    }
    public void ReassignHelp()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(newButtonHelp);
    }
    public void ReassignMain()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(newButtonMain);
    }
}
