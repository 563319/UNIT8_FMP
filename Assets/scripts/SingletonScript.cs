using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class SingletonScript : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public static SingletonScript instance;
    ///plr stuff
    public int highScore = 0;
    public int score = 0;
    public int playerHealth = 200;
    public int playerAmmo = 0;
    //public int[] playerKeys;
    public List<int> playerKeys = new List<int>();
    public bool playerCanShoot = true;

    
    public float quickestTime;

    


    


    void Awake()
    {
        if (instance == null)
        {
            // if instance is null, store a reference to this instance
            instance = this;
            DontDestroyOnLoad(gameObject);
            //print("do not destroy");
        }
        else
        {
            // Another instance of this gameobject has been made so destroy it
            // as we already have one
            //print("do destroy");
            Destroy(gameObject);
        }
    }




    private void Start()
    {
        if (PlayerPrefs.HasKey("highScore") == true)
        {
            LoadHighScore();
            print("loaded highscore");
        }
        else
        {
            SetHighScore();
            print("set highscore");

        }
        if (PlayerPrefs.HasKey("quickestTime"))
        {
            LoadQuickestTime();
            print("loaded quickest time");
        }
        else
        {
            SetQuickestTime();
            print("set teh wuickest time");
        }


    }



    public void SetHighScore()//this is called in player when score is higher than highscore
    {

        PlayerPrefs.SetInt("highScore", highScore);//save to the prefs for future
        PlayerPrefs.Save();
    }

    private void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        SetHighScore();

    }

    public void SetQuickestTime()//this is called in player when score is higher than highscore
    {

        PlayerPrefs.SetFloat("quickestTime", quickestTime);//save to the prefs for future
        PlayerPrefs.Save();

    }

    private void LoadQuickestTime()
    {
        quickestTime = PlayerPrefs.GetFloat("quickestTime");
        SetQuickestTime();
        

    }




}
