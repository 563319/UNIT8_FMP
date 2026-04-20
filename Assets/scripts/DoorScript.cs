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
    /*
    void OnTriggerEnter(Collider col)
    {
        print("oncollision called");
        
        if (col.gameObject.tag == "Player")
        {
            print("door touched player");
        
            
            if (SingletonScript.instance.playerKeys.Contains(ID))
            {
                SingletonScript.instance.playerKeys.Remove(ID);
                Destroy(gameObject);
            }
            
            
            for (int i = 0; i < SingletonScript.instance.playerKeys.Length; i++)
            {
                if (SingletonScript.instance.playerKeys[i] == ID)
                {
                    Destroy(gameObject);
                }
            }
            



        }
    }
    */
    
}
