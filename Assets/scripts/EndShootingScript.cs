using UnityEngine;
using UnityEngine.UI;

public class EndShootingScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject MuzzleFlash;

    public Light gunLight;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        


    }

    public void EndShootingAnim()
    {
        print("END shoot animation!");
        animator.SetBool("isIdle", true);
        animator.SetBool("isShooting", false);
        

    }
    public void EndMuzzleFlash()
    {
        print("end muzzle flash");
        MuzzleFlash.SetActive(false);
        
    }

    public void StartMuzzleFlash()
    {
        print("start muzzle flash");
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

}
