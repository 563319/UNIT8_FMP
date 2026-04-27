using TMPro;
using UnityEngine;

public class EndScreenCurrentTimeScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    public SpeedrunTimerScript speedrunTimerScript;
    public float elapsedTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float elapsedTimer = speedrunTimerScript.elapsedTimer;
        int minutes = Mathf.FloorToInt(elapsedTimer / 60);
        int seconds = Mathf.FloorToInt(elapsedTimer % 60);
        timerText.text = string.Format("TIME: {0:00}:{1:00}", minutes, seconds);

    }

    // Update is called once per frame
    void Update()
    {
        float elapsedTimer = speedrunTimerScript.elapsedTimer;
    }
}
