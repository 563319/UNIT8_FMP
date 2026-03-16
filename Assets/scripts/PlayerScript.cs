using System.Runtime.InteropServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawnPos;
    public float bulletSpeed = 50;

    public CharacterController controller;
    public float speed = 15f;
    public float jumpHeight = 3f;
    Vector3 velocity;
    public float gravity = -9.9f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    


    void Start()
    {
        
    }

    
    void Update()
    {

        Player_Actions();
        HealthMax();
        AmmoMax();
        print("health: " + SingletonScript.instance.playerHealth);
        print("ammo: " + SingletonScript.instance.playerAmmo);
        foreach (int i in SingletonScript.instance.playerKeys)
        {
            print("player key: " + i);
        }
        
    }



    void Player_Actions()
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
    }
    void shoot()
    {
        /*
        GameObject clone;
        clone = Instantiate(bullet, bulletSpawnPos.position, Camera.main.transform.rotation);
        Rigidbody rb = clone.GetComponent<Rigidbody>();
        

        rb.linearVelocity = Camera.main.transform.forward * bulletSpeed;
        */
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(bulletSpawnPos.position, bulletSpawnPos.forward, out hitInfo);
        if (hit)
        {
            print("just shot");
            Debug.DrawRay(bulletSpawnPos.position, bulletSpawnPos.forward, Color.red);
            Debug.Log(hitInfo.collider.gameObject.name);
            
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

}
