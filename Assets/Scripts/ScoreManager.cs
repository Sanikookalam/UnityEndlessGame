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

    public float pointsPerSecond;


    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("HighScore")){
            endHiScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreCount += pointsPerSecond * Time.deltaTime;

        if (scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", endHiScoreCount);
        }
        if (scoreCount > endHiScoreCount)
        {
            PlayerPrefs.SetFloat("HighScore", endHiScoreCount);
        }

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        hiScoreText.text = "High Score: "+ Mathf.Round(hiScoreCount);
        endHiScoreText.text = "Your Highest Score is :"+ endHiScoreCount;
    }

    public void AddScore(int pointsToAdd)
    {
        scoreCount += pointsToAdd;

    }
}
