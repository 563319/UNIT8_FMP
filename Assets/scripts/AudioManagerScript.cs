using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    [Header("-------- Audio Source --------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------- Audio Clip --------")]
    public AudioClip background;
    public AudioClip shoot;
    public AudioClip door;
    public AudioClip enemyShoot;
    public AudioClip collect;

    public AudioClip hurt;
    public AudioClip jump;
    public AudioClip heal;
    public AudioClip UiClick;
    public AudioClip UiClick2;
    public AudioClip plrDeath;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }



}
