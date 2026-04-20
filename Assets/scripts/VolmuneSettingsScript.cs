using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolmuneSettingsScript : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }

       
    }

    public void SetMusicVolume()
    {
        float musicVolume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(musicVolume)*20);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);

    }
    public void SetSFXVolume()
    {
        float sfxVolume = SFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(sfxVolume)*20);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);

    }
    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        SetMusicVolume();
        SetSFXVolume();
    }


}
