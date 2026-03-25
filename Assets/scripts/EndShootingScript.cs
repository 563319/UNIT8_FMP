using UnityEngine;

public class EndShootingScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


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

}
