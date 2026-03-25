using TMPro;
using UnityEngine;

public class SpeedrunTimerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTimer += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTimer / 60);
        int seconds = Mathf.FloorToInt(elapsedTimer % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
