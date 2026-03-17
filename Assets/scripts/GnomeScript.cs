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

    int enemyHealth = 200;
    int enemyDamage = 10;
    float agroRadius = 20f;
    float shootingRadius = 10f;

    

    float shotTimer = 0f;


    bool isidle = true;
    bool isChasing = false;
    bool isShooting = false;

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


        //Logic();

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


        
    }
    void Logic()
    {
        distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer < agroRadius && distanceToPlayer > shootingRadius)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }
        if (distanceToPlayer < shootingRadius)
        {
            isShooting = true;
        }

    }

    void Idle()
    {
        //check for player in range

        //if player in range, change to chase state

    }
    void Chasing()
    {
        //check for player outside range
        //if outside, change to idle state

        agent.destination = playerTransform.position;
        
    }
    void Shooting()
    {
        
        shotTimer += Time.deltaTime;
        
        if (shotTimer >= 1)
        {
            GameObject clone;
            clone = Instantiate(bullet, bulletSpawnPos.position, gameObject.transform.rotation);
            Rigidbody rb = clone.GetComponent<Rigidbody>();


            rb.linearVelocity = gameObject.transform.forward * bulletSpeed;
            shotTimer = 0;
        }



    }

}
