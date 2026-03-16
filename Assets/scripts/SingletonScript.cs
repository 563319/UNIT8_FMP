using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class SingletonScript : MonoBehaviour
{
    public static SingletonScript instance;
    //plr stuff
    public int highScore = 0;
    public int score = 0;
    public int playerHealth = 100;
    public int playerAmmo = 0;
    //public int[] playerKeys;
    public List<int> playerKeys = new List<int>();
    

    void Awake()
    {
        if (instance == null)
        {
            // if instance is null, store a reference to this instance
            instance = this;
            DontDestroyOnLoad(gameObject);
            print("do not destroy");
        }
        else
        {
            // Another instance of this gameobject has been made so destroy it
            // as we already have one
            print("do destroy");
            Destroy(gameObject);
        }
    }


    //these methods are globally accessible
    public void SetHighScore(int score)
    {
        highScore = score;
    }
    public int GetHighScore()
    {
        return highScore;
    }
}
