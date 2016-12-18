using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int Score;
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
        //Score = 0;
        Score = PlayerPrefs.GetInt("CurrentPlayerScore"); 
        


    }


    void Update()
    {

        if (Score < 0)
            Score = 0;

        text.text = "" + Score;
    }


    public static void AddScore (int Points)
    {
        Score += Points;
        PlayerPrefs.SetInt("CurrentPlayerScore", Score);
    }

    public static void Reset()
    {
        Score = 0;
        PlayerPrefs.SetInt("CurrentPlayerScore", Score);
    }
}
