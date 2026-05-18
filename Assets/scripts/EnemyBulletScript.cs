using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    float destroyTimer = 0;
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

        destroyTimer += Time.deltaTime;

        if (destroyTimer > 6)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 3)
        {
            print("hit layer3");
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Player")
        {
            print("destroyed by player");
            Destroy(gameObject);
            SingletonScript.instance.playerHealth -= 20;
            //audioManager.PlaySFX(audioManager.enemyShoot);
        }
    }
}
