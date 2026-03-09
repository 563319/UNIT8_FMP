using UnityEngine;

public class BillBoardScript : MonoBehaviour
{
    private Transform cameraTransform;
    private void Awake()
    {
        

    }
    void Start()
    {
        cameraTransform = Camera.main.transform;

    }

    


    void Update()
    {

        transform.LookAt(cameraTransform, Vector3.up);
        transform.Rotate(0f, 180f, 0f);

    }
}
