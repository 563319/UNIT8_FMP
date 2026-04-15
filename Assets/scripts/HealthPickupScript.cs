using UnityEngine;

public class HealthPickupScript : MonoBehaviour
{
    
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
            
            SingletonScript.instance.playerHealth += 80;
            Destroy(gameObject);
        }
    }
}
