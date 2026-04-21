using UnityEngine;
using UnityEngine.UI;

public class MouseSettingsScript : MonoBehaviour
{
    [SerializeField] private Slider sensitivitySlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("sensitivity"))
        {
            LoadSensitivity();
        }
        else
        {
            SetSensitivity();
            
        }


    }

    public void SetSensitivity()
    {
        float mouseSensitivity = sensitivitySlider.value;
        //mouseSensitivity = Mathf.Log10(mouseSensitivity) * 20;



        SingletonScript.instance.mouseSensitivity = mouseSensitivity;//save to the game

        PlayerPrefs.SetFloat("sensitivity", mouseSensitivity);//save to the prefs for future

    }
    
    private void LoadSensitivity()
    {
        sensitivitySlider.value = PlayerPrefs.GetFloat("sensitivity");
        SetSensitivity();
        
    }
}
