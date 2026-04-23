using TMPro;
using UnityEngine;

public class TimeMenuTextScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int minutes = Mathf.FloorToInt(SingletonScript.instance.quickestTime / 60);
        int seconds = Mathf.FloorToInt(SingletonScript.instance.quickestTime % 60);
        timeText.text = string.Format("BEST TIME: {0:00}:{1:00}", minutes, seconds);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
