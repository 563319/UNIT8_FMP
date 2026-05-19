
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GnomeScript : MonoBehaviour
{
    public Animator anim;
    bool isDead = false;


    //0=idle
    //1=chase
    //2=shoot
    int state;

    public SpriteRenderer SprRenderer;
    float flashTimer = 0.2f;
    bool startFlashTimer = false;

    float deathTimer = 10f;
    bool startDeathTimer = false;

    public GameObject bullet;
    public Transform bulletSpawnPos;
    public float bulletSpeed = 20;

    public int enemyHealth = 60;
    float agroRadius = 30f;
    float shootingRadius = 20f;

    float shotTimer = 0f;

    bool canShoot = true;

    float distanceToPlayer;

    private NavMeshAgent agent;

    PlayerScript player;
    Transform playerTransform;

    public Vector3 shootOffset;

    AudioManagerScript audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
        playerTransform = player.transform;

        state = 0;
        shootOffset = new Vector3(0, 0, 0);


    }

    
    void Update()
    {

        /*   to see enemy raycast
        Vector3 pos = bulletSpawnPos.position + shootOffset;

        Vector3 direction = (player.transform.position - transform.position).normalized;

        //raycast so gnome wont shoot behind a wall
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(pos, direction, out hitInfo, 50f);
        Debug.DrawRay(pos, direction * 50f, Color.red);
        */




        //print("distance to player = " + distanceToPlayer);
        distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (enemyHealth <= 0)
        {
            EnemyDeath();

        }
        if (isDead == false)
        {
            if (state == 0)
            {
                Idle(); //the state is responsible for changing to the next state
            }

            if (state == 1)
            {
                Chasing();
            }

            if (state == 2)
            {
                Shooting();
            }
            if (startFlashTimer == true)
            {
                if (flashTimer > 0)
                {
                    flashTimer -= Time.deltaTime;
                    if (flashTimer <= 0)
                    {
                        SprRenderer.color = Color.white;
                        flashTimer = 0.2f;
                        startFlashTimer = false;


                    }
                }
            }
            
        }
        if (startDeathTimer == true)
        {
            if (deathTimer > 0)
            {
                deathTimer -= Time.deltaTime;
                if (deathTimer <= 0)
                {

                    Destroy(gameObject);
                    deathTimer = 10f;
                    startDeathTimer = false;


                }
            }
        }
        
        //print("enemy state is: " + state);
        //print("distance: " + distanceToPlayer);
        print("enemy can shoot = " + canShoot);

    }
    

    void Idle() 
    {
        anim.SetBool("isMoving", false);
        anim.SetBool("isShooting", false);

        //do idle
        if (isDead == false)
        {
            //set it to its own position so its stops moving
            agent.destination = transform.position;
        }
            
        //if player is in agro radius start chasing
        if (distanceToPlayer < agroRadius && distanceToPlayer > shootingRadius)
        {
            state = 1;
        }
        if (distanceToPlayer < shootingRadius)
        {
            state = 2;
        }

    }
    void Chasing()
    {
        anim.SetBool("isMoving", true);
        anim.SetBool("isShooting", false);
        //do chasing
        if (isDead == false)
        {
            agent.destination = playerTransform.position;
        }
        
        
        

        //if player goes out of agro radius go idle
        if (distanceToPlayer > agroRadius)
        {
            state = 0;
        }
        //if player goes into shooting radius start shooting
        if (distanceToPlayer < shootingRadius)
        {
            state = 2;
        }
        

    }
    void Shooting()
    {
        
        anim.SetBool("isShooting", true);
        if (agent.velocity.magnitude > 0.1f)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        


        print("shot timer = " + shotTimer);
        
        //do shooting
        shotTimer += Time.deltaTime;
   
        if (shotTimer >= 1 && CheckIfWallInFront() == false)
        {
            
            print("gnome shot timer >=1");
            Rigidbody rb;
            GameObject clone;
            clone = Instantiate(bullet, bulletSpawnPos.position, gameObject.transform.rotation);
            rb = clone.GetComponent<Rigidbody>();

            rb.transform.LookAt(Camera.main.transform, Vector3.up);



            rb.linearVelocity = clone.transform.forward * bulletSpeed;
            audioManager.PlaySFX(audioManager.enemyShoot);
            //shotTimer = 0;
        }
        if (shotTimer >= 1)
        {
            shotTimer = 0;
        }

        // if player is outside shooting radius but inside agro radius
        if (distanceToPlayer > shootingRadius && distanceToPlayer < agroRadius)
        {
            
            state = 1;
        }
        //id player is outside agro and shoot radius
        else if (distanceToPlayer > agroRadius)
        {
            
            state = 0; 
        }



    }
    void EnemyDeath()
    {
        print("enemy death");
        SprRenderer.color = Color.white;
        //die stuff
        
        startDeathTimer = true;
        anim.SetBool("isDead", true);
        anim.SetBool("isMoving", false);
        anim.SetBool("isShooting", false);
        isDead = true;

    }

    public void DamageFlash()
    {
        SprRenderer.color = Color.red;
        startFlashTimer = true;
         
    }
    public bool CheckIfWallInFront()
    {

        Vector3 pos = bulletSpawnPos.position + shootOffset;

        Vector3 direction = (player.transform.position - transform.position).normalized;

        //raycast so gnome wont shoot behind a wall
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(pos, direction, out hitInfo, 50f);
        Debug.DrawRay(pos, direction * 50f, Color.red);
        
        //Debug.Log(hitInfo.collider.gameObject.name);
        if (hit)
        {

            
            
            
            if (hitInfo.collider.gameObject.layer == 3)
            {
                canShoot = false;
                return true;
                //theres a wall
                

            }
            else

            {
                canShoot = true;
                return false;
                
            }

        }
        else
        {
            canShoot = true;
            return false;
           
        }
    }
   



}
