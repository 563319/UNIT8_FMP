using System.Resources;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GnomeScript : MonoBehaviour
{

    //0=idle
    //1=chase
    //2=shoot
    int state;

   
    public GameObject bullet;
    public Transform bulletSpawnPos;
    public float bulletSpeed = 20;

    public int enemyHealth = 60;
    float agroRadius = 30f;
    float shootingRadius = 20f;

    float shotTimer = 0f;


    float distanceToPlayer;

    private NavMeshAgent agent;

    PlayerScript player;
    Transform playerTransform;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
        playerTransform = player.transform;

        state = 0;


    }

    
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (enemyHealth <= 0)
        {
            death();

        }

        if (state==0)
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


        //print("enemy state is: " + state);
        //print("distance: " + distanceToPlayer);
        print("enemy health: " + enemyHealth);
    }
    

    void Idle() 
    {
        //do idle
        //set it to its own position so its stops moving
        agent.destination = transform.position;
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
        //do chasing
        agent.destination = playerTransform.position;

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
        Rigidbody rb;

        //do shooting
        shotTimer += Time.deltaTime;
        if (shotTimer >= 1)
        {
            GameObject clone;
            clone = Instantiate(bullet, bulletSpawnPos.position, gameObject.transform.rotation);
            rb = clone.GetComponent<Rigidbody>();

            rb.transform.LookAt(Camera.main.transform, Vector3.up);



            rb.linearVelocity = clone.transform.forward * bulletSpeed;
            shotTimer = 0;
        }
        // if player is outside shooting radius but inside agro radius
        if (distanceToPlayer > shootingRadius && distanceToPlayer < agroRadius)
        {
            
            state = 1;
        }
        //id player is outside agro and shoot radius
        if (distanceToPlayer > agroRadius)
        {
            state = 0; 
        }



    }
    void death()
    {
        
        //die stuff
        Destroy(gameObject);
    }



}
