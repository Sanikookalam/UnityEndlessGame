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

    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;

    private Collider2D myCollider;

    public GameManager theGameManager;

    public AudioSource jumpSound;
    public AudioSource deathSound;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D> ();

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
            moveSpeed = 3;
            
            myRigidbody.velocity = new Vector2(moveSpeed,myRigidbody.velocity.y);

            theGameManager.RestartGame();
            deathSound.Play();
        }
        // else if( other.gameObject.CompareTag("doshman") && !hasEntered)
        // {
        //     hasEntered = true;
        //     moveSpeed = myRigidbody.velocity.x/2;
        //     myRigidbody.velocity = new Vector2(moveSpeed,myRigidbody.velocity.y);
        // }
        else if(other.gameObject.tag == "sofre")
        {
            moveSpeed = 0;
            myRigidbody.velocity = new Vector2(moveSpeed,myRigidbody.velocity.y);
            theGameManager.Win();
        }
    }
}
