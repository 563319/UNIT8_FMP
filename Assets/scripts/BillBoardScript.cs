using UnityEngine;

public class BillBoardScript : MonoBehaviour
{
    private Transform cameraTransform;
    
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    
    void Update()
    {
        transform.LookAt(cameraTransform);
        transform.Rotate(0f, 180f, 0f);
    }
}
