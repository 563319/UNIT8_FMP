using UnityEngine;

public class TestSFXMenuScript : MonoBehaviour
{
    AudioManagerScript audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
    }

    public void TestSFX()
    {
        audioManager.PlaySFX(audioManager.shoot);
    }
}
