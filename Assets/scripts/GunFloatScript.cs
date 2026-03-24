using UnityEngine;

public class GunFloatScript : MonoBehaviour
{
    float speed = 1f;
    float height = 0.1f;

    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }


    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
