using UnityEngine;

public class HealthBarUiScript : MonoBehaviour
{
    public Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SingletonScript.instance != null)
        {
            anim.SetInteger("healthValue", SingletonScript.instance.playerHealth);
        }
    }
}
