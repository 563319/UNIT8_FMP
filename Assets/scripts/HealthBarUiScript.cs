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
        anim.SetInteger("healthValue", SingletonScript.instance.playerHealth);
    }
}
