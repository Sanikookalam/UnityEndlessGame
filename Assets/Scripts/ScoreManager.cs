using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text hiScoreText;
    public Text endHiScoreText;

    public float scoreCount;
    public float hiScoreCount;
    public float endHiScoreCount;


    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("HighScore")){
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");
            endHiScoreCount = hiScoreCount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            if(hiScoreCount > endHiScoreCount){
                endHiScoreCount = hiScoreCount;
            }
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);
        }

        scoreText.text = "Score: " + scoreCount;
        hiScoreText.text = "High Score: "+ hiScoreCount;
        endHiScoreText.text = "Your Highest Score is :"+ endHiScoreCount;
    }

    public void AddScore(int pointsToAdd)
    {
        scoreCount += pointsToAdd;

    }
}
