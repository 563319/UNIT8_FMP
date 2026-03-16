using UnityEngine;

public class AmmoPickupScript : MonoBehaviour
{
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {

            SingletonScript.instance.playerAmmo += 20;
            Destroy(gameObject);
        }
    }
}
