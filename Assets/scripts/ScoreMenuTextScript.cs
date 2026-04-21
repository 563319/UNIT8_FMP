using TMPro;
using UnityEngine;

public class ScoreMenuTextScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "BEST SCORE: " + SingletonScript.instance.highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
