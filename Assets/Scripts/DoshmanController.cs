using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoshmanController : MonoBehaviour
{

    private Rigidbody2D myRigidbody;
    public float xMoveSpeed;
    public float yMoveSpeed;
    public int  s;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D> ();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {   
        if(other.gameObject.tag == "Player"){
            myRigidbody.velocity = new Vector2(xMoveSpeed,yMoveSpeed);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            DeactivateMe();
        }

        void DeactivateMe (){
            StartCoroutine(RemoveAfterSeconds(s));
        }
 
        IEnumerator RemoveAfterSeconds (int seconds){
            yield return new WaitForSeconds(seconds);
            gameObject.SetActive(false);
        }      

    }
}
