using UnityEngine;
using UnityEngine.UI;

public class EndShootingScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject MuzzleFlash;

    public Light gunLight;

    Animator animator;
    AudioManagerScript audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        


    }

    public void EndShootingAnim()
    {

        SingletonScript.instance.playerCanShoot = true;
        animator.SetBool("isIdle", true);
        animator.SetBool("isShooting", false);
        print("can shoot = true");
        




    }
    public void EndMuzzleFlash()
    {
        
        MuzzleFlash.SetActive(false);
        
    }

    public void StartMuzzleFlash()
    {
        
        MuzzleFlash.SetActive(true);
        
    }
    public void EndLightFlash()
    {

        gunLight.gameObject.SetActive(false);

    }

    public void StartLightFlash()
    {
        
        gunLight.gameObject.SetActive(true);

    }
    public void PlayGunSound()
    {
        audioManager.PlaySFX(audioManager.shoot);
    }
    public void RemoveBullet()
    {
        SingletonScript.instance.playerAmmo -= 1;
    }
}
