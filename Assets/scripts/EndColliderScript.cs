using UnityEngine;

public class EndColliderScript : MonoBehaviour
{
    public EndScreenScript endScreen;
    public PlayerScript plr;
    AudioManagerScript audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == ("Player"))
        {
            print("collided with end collider");
            //audioManager.PlaySFX(audioManager.collect);
            plr.hasFinishedLevel = true;
            //bring up end screen
            endScreen.Pause();
            
        }

    }
}
