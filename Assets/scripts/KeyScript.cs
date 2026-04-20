using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public int ID;

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
        if (col.gameObject.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.collect);
            SingletonScript.instance.playerKeys.Add(ID);
            //SingletonScript.instance.playerKeys = new int[ID];
            Destroy(gameObject);
        }
    }
}
