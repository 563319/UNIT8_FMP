using UnityEngine;
using UnityEngine.UI;

public class EndShootingScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject MuzzleFlash;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
       


    }

    public void EndShootingAnim()
    {
        
        animator.SetBool("isIdle", true);
        animator.SetBool("isShooting", false);

    }
    public void EndMuzzleFlash()
    {
        MuzzleFlash.SetActive(false);
    }

}
