using UnityEngine;

public class BulletScript : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 3)
        {
            Destroy(gameObject);
        }
    }
}
