using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class PlayerScript : MonoBehaviour
{
    public LineRenderer lineRend;

    public Transform bulletSpawnPos;

    public GameObject pauseMenu;

    public CharacterController controller;
    public float speed = 15f;
    public float jumpHeight = 3f;
    Vector3 velocity;
    public float gravity = -9.9f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    bool hasPressedEsc = false;


    //gunsprite anim
    public Animator gunAnim;

    void Start()
    {
        
    }

    void Update()
    {
        Player_Actions();
        HealthMax();
        AmmoMax();
        highScoreManager();

    }



    void Player_Actions()
    {
        if (SingletonScript.instance.playerHealth > 0)
        { 
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            if (Input.GetMouseButtonDown(0) && SingletonScript.instance.playerAmmo > 0)
            {
                shoot();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                print("pressed esc");
                if (hasPressedEsc == false)
                {
                    print("trying to pause");
                    pauseMenu.GetComponent<PauseMenuScript>().Pause();
                    hasPressedEsc = true;
                    return;
                }
                if (hasPressedEsc == true)
                {
                    print("trying to unpause");
                    pauseMenu.GetComponent<PauseMenuScript>().Resume();
                    hasPressedEsc = false;
                    return;
                }

            }
            
            if (SingletonScript.instance.playerHealth <= 0)
            {
                death();
            }
        }
    }
    void shoot()
    {
        StartShootingAnim();
        
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(bulletSpawnPos.position, bulletSpawnPos.forward, out hitInfo);
        if (hit)
        {
            ///
            lineRend.enabled = true;
            lineRend.SetPosition(0, bulletSpawnPos.position);
            lineRend.SetPosition(1, hitInfo.point);
            ///




            SingletonScript.instance.playerAmmo -= 1;
            
            Debug.DrawRay(bulletSpawnPos.position, bulletSpawnPos.forward, Color.red);
            Debug.Log(hitInfo.collider.gameObject.name);

            //enemy damage
            if (hitInfo.collider.gameObject.tag == "Enemy")
            {
                
                hitInfo.collider.gameObject.GetComponent<GnomeScript>().enemyHealth -= 20;
                SingletonScript.instance.score += 1;
                print("hit enemy");
            }
            
        }
        else
        {
            ///
            lineRend.enabled=false;
            ///
        }
        




    }
    
    void HealthMax()
    {
        if (SingletonScript.instance.playerHealth > 200)
        {
            SingletonScript.instance.playerHealth = 200;
        }
    }
    void AmmoMax()
    {
        if (SingletonScript.instance.playerAmmo > 12)
        {
            SingletonScript.instance.playerAmmo = 12;
        }
    }
    void OnControllerColliderHit(ControllerColliderHit col)
    {
        if (col.gameObject.tag == "Door")
        {
            if (SingletonScript.instance.playerKeys.Contains(col.gameObject.GetComponent<DoorScript>().ID))
            {
                SingletonScript.instance.playerKeys.Remove(col.gameObject.GetComponent<DoorScript>().ID);
                Destroy(col.gameObject);
            }
        }
    }
    void highScoreManager()
    {
       
        if (SingletonScript.instance.highScore < SingletonScript.instance.score)
        {
            SingletonScript.instance.highScore = SingletonScript.instance.score;
        }
    }
    void death()
    {
        //dead stuff
    }

    public void StartShootingAnim()
    {
        gunAnim.SetBool("isIdle", false);
        gunAnim.SetBool("isShooting", true);

    }
    private void OnGUI()
    {
        string text = "plr health: " + SingletonScript.instance.playerHealth;
        text += "\nplr ammo: " + SingletonScript.instance.playerAmmo;
        text += "\nscore: " + SingletonScript.instance.score;
        text += "\nHigh score: " + SingletonScript.instance.highScore;

        GUILayout.BeginArea(new Rect(10f, 450f, 1600f, 1600f));
        GUILayout.Label($"<size=18>{text}</size>");
        GUILayout.EndArea();
        
    }

}
