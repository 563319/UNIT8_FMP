using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public int ID;
    
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

            SingletonScript.instance.playerKeys.Add(ID);
            Destroy(gameObject);
        }
    }
}
