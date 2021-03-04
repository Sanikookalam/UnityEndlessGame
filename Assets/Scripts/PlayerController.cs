using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float speedMultiplier;

    public float speedIncreaseMilestone;
    private float speedMilestoneCount;

    public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;

    private bool stoppedJumping;
    private bool canDoubleJump;

    private Rigidbody2D myRigidbody;
    //public Rigidbody2D fallingObject;

    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;

    private Collider2D myCollider;
    //public bool hasEntered;

    public GameManager theGameManager;

    public AudioSource jumpSound;
    public AudioSource deathSound;
    private AudioSource enemySound;
    private AudioSource TashvighSound;


    private ScoreManager theScoreManager;
    public int scoreToGive;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D> ();
        theScoreManager = FindObjectOfType<ScoreManager>();
        theGameManager = FindObjectOfType<GameManager>();
        enemySound = GameObject.Find("EnemySound").GetComponent<AudioSource>();
        TashvighSound = GameObject.Find("Tashvigh").GetComponent<AudioSource>();

        //myCollider = GetComponent<Collider2D> ();

        jumpTimeCounter = jumpTime;

        stoppedJumping = true;
        canDoubleJump = true;

    }

    // Update is called once per frame
    void Update()
    {
        //grounded = Physics2D.IsTouchingLayers(myCollider,whatIsGround);
        
        grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,whatIsGround);

        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            moveSpeed = moveSpeed * speedMultiplier;

        }

         myRigidbody.velocity = new Vector2(moveSpeed,myRigidbody.velocity.y);
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.UpArrow))
        //if (Input.anyKeyDown)
        {
            if (grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x,jumpForce);
                stoppedJumping = false;
            }

            if (!grounded && canDoubleJump)
            {
                jumpTimeCounter = jumpTime;
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x,jumpForce);
                canDoubleJump = false;
                stoppedJumping = false;
            }
        }

        if((Input.GetKey (KeyCode.Space) || Input.GetMouseButton(0) || Input.GetKey(KeyCode.UpArrow)) && !stoppedJumping)
        //if(Input.anyKey)
        {
            if(jumpTimeCounter > 0)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x,jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.UpArrow))
        //if (Input.anyKey)
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }

        if (grounded)
        {
            jumpTimeCounter = jumpTime;
            canDoubleJump = true;
            stoppedJumping = false;
            //jumpSound.Play();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // private bool hasEntered ;
        // hasEntered = false;

        if(other.gameObject.tag == "killbox")
        {
            myRigidbody.velocity = new Vector2(moveSpeed,myRigidbody.velocity.y);
            theGameManager.RestartGame();
            deathSound.Play();
            theScoreManager.hiScoreCount = 0;
            theScoreManager.killbox=true;
        }
        else if( other.gameObject.tag == "doshman")
        {
            scoreToGive = -10;
            theScoreManager.AddScore(scoreToGive);
            moveSpeed = 4;
            myRigidbody.velocity = new Vector2(moveSpeed,myRigidbody.velocity.y);
            enemySound.Play();
            theScoreManager.hiScoreCount += scoreToGive;

            // var magnitude = 10000;
            // var force = transform.position - other.transform.position;
            // force.Normalize ();
            // GetComponent<Rigidbody2D> ().AddForce (-force * magnitude);
        }
        else if(other.gameObject.tag == "sofre")
        {
            TashvighSound.Play();
            moveSpeed = 0;
            myRigidbody.velocity = new Vector2(moveSpeed,myRigidbody.velocity.y);
            theGameManager.Win();
            if(theScoreManager.hiScoreCount > theScoreManager.endHiScoreCount ){
                theScoreManager.endHiScoreCount = theScoreManager.hiScoreCount;
            }
            PlayerPrefs.SetFloat("HighScore", theScoreManager.endHiScoreCount);

        }
    }
}
