using UnityEngine;

public class HealthPickupScript : MonoBehaviour
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
        if (col.gameObject.CompareTag("Player") && SingletonScript.instance.playerHealth < 200)
        {
            audioManager.PlaySFX(audioManager.collect);
            SingletonScript.instance.playerHealth += 80;
            Destroy(gameObject);
        }
    }
}
