using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public LineRenderer lineRend;

    public Transform bulletSpawnPos;

    

    public GameObject pauseMenu;
    public GameObject deathScreen;
    //public GameObject MuzzleFlash;

    public bool hasFinishedLevel = false;

    public CharacterController controller;
    public float speed = 15f;
    public float jumpHeight = 3f;
    Vector3 velocity;
    public float gravity = -20f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    bool hasPressedEsc = false;

    //line renderer timer
    float lineTimer = 0.2f;
    bool startLineTimer = false;

    //gunsprite anim
    public Animator gunAnim;

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
        Player_Actions();
        HealthMax();
        AmmoMax();
        highScoreManager();
        LineTimerUpdate();

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

            if (Input.GetButtonDown("Fire1") && SingletonScript.instance.playerAmmo > 0)
            {
                shoot();
            }

            if (Input.GetButtonDown("Cancel"))
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
            
            
        }
        else 
        {
            death();
        }
    }
    void shoot()
    {

        
        StartShootingAnim();
        print("can shoot = false");
        SingletonScript.instance.playerCanShoot = false;

        //MuzzleFlash.SetActive(true);
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(bulletSpawnPos.position, bulletSpawnPos.forward, out hitInfo);
        if (hit)
        {
            ///
            lineRend.enabled = true;
            lineRend.SetPosition(0, bulletSpawnPos.position);
            lineRend.SetPosition(1, hitInfo.point);
            startLineTimer = true;
            




            
            
            Debug.DrawRay(bulletSpawnPos.position, bulletSpawnPos.forward, Color.red);
            Debug.Log(hitInfo.collider.gameObject.name);

            //enemy damage
            if (hitInfo.collider.gameObject.tag == "Enemy")
            {
                
                hitInfo.collider.gameObject.GetComponent<GnomeScript>().enemyHealth -= 20;
                hitInfo.collider.gameObject.GetComponent<GnomeScript>().DamageFlash();
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
                audioManager.PlaySFX(audioManager.door);
                Destroy(col.gameObject);
            }
        }
        
    }
    void highScoreManager()
    {
       
        if (SingletonScript.instance.highScore < SingletonScript.instance.score)
        {
            SingletonScript.instance.highScore = SingletonScript.instance.score;
            SingletonScript.instance.SetHighScore();
        }
        
    }
    void death()
    {

        deathScreen.GetComponent<DeathScreenScript>().Pause();
        /*
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //reset the singelton stuff because if i dont they will persist between level loads important!, except highscore obviously
        SingletonScript.instance.score = 0;
        SingletonScript.instance.playerHealth = 200;
        SingletonScript.instance.playerAmmo = 0;
        SingletonScript.instance.playerKeys = new List<int>();

        SceneManager.LoadScene(0);
        */
    }

    public void StartShootingAnim()
    {
        gunAnim.SetBool("isIdle", false);
        gunAnim.SetBool("isShooting", true);
        

    }

    void LineTimerUpdate()
    {
        if (startLineTimer == true)
        {
            if (lineTimer > 0)
            {
                lineTimer -= Time.deltaTime;
                if (lineTimer <= 0)
                {
                    lineRend.enabled = false;
                    lineTimer = 0.2f;
                    startLineTimer = false;


                }
            }
        }
    }
    private void OnGUI()
    {
        /*
        string text = "plr health: " + SingletonScript.instance.playerHealth;
        text += "\nplr ammo: " + SingletonScript.instance.playerAmmo;
        text += "\nscore: " + SingletonScript.instance.score;
        text += "\nHigh score: " + SingletonScript.instance.highScore;

        GUILayout.BeginArea(new Rect(10f, 450f, 1600f, 1600f));
        GUILayout.Label($"<size=18>{text}</size>");
        GUILayout.EndArea();
        */
        
    }

}
