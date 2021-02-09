﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private ScoreManager theScoreManager;

    public DeathMenu theDeathScreen; 


    // Start is called before the first frame update
    void Start()
    {
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager> ();

        //screen.orientation = ScreenOrientation.Landscape;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        thePlayer.gameObject.SetActive(false);

        //StartCoroutine("RestartGameCo");

        theDeathScreen.gameObject.SetActive(true);
    }

    public void Reset()
    {
        theDeathScreen.gameObject.SetActive(false);
        thePlayer.transform.position = playerStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
    }

    /*public IEnumerator RestartGameCo()
    {
        //theScoreManager.scoreincreasing = false;
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        thePlayer.transform.position = playerStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        //theScoreManager.scoreincreasing = true;
    }*/

}
