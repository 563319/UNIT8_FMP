using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUiScript : MonoBehaviour
{
    public TextMeshProUGUI AmmoText;
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
            anim.SetInteger("Ammo", SingletonScript.instance.playerAmmo);
            AmmoText.text = SingletonScript.instance.playerAmmo.ToString() + "/12";
        }
    }
}
