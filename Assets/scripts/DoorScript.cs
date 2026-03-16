using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public int ID;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.CompareTag("Player"))
        {
            print("door touched player");
        
            if (SingletonScript.instance.playerKeys.Contains(ID))
            {
                SingletonScript.instance.playerKeys.Remove(ID);
                Destroy(gameObject);
            }



        }
    }
}
