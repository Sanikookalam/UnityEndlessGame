using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPoints : MonoBehaviour
{

    public int scoreToGive;

    private ScoreManager theScoreManager;

    private AudioSource coinSound;
    private AudioSource enemySound;
    private AudioSource FifthSound;

    public bool enemy;
    public bool Fifth;

    public CameraShake cameraShake;

    // Start is called before the first frame update
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        coinSound = GameObject.Find("CoinSound").GetComponent<AudioSource>();
        enemySound = GameObject.Find("EnemySound").GetComponent<AudioSource>();
        FifthSound = GameObject.Find("50").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){

        if (other.gameObject.name == "Player")
        {
            theScoreManager.AddScore(scoreToGive);
            gameObject.SetActive(false);
            if (enemy == true)
            {
                //enemySound.Play();
            }
            else if (Fifth == true)
            {
                FifthSound.Play();
            }
            {
                coinSound.Play();
            }        
        }   

    // void OnCollisionEnter2D(Collider2D col)
    // {
    //     if (col.gameObject.name == "Player")
    //     {
    //         if (enemy == true)
    //         {
    //             StartCoroutine(cameraShake.Shake(.15f , .4f));
    //         }
    //     }
    // }    
    }
}
