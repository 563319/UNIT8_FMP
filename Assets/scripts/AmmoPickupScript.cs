using UnityEngine;

public class AmmoPickupScript : MonoBehaviour
{
    AudioManagerScript audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player") && SingletonScript.instance.playerAmmo < 12)
        {

            SingletonScript.instance.playerAmmo += 20;
            audioManager.PlaySFX(audioManager.collect);
            Destroy(gameObject);
        }
    }
}
