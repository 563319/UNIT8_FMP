using TMPro;
using UnityEngine;

public class TimeMenuTextScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeText.text = "BEST TIME: " + SingletonScript.instance.highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
