using TMPro;
using UnityEngine;

public class EndScreenCurrentScoreScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "SCORE: " + SingletonScript.instance.score.ToString();
    }
}
