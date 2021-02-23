using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoshmanController : MonoBehaviour
{

    private Rigidbody2D myRigidbody;
    public float xMoveSpeed;
    public float yMoveSpeed;
    public int  s;
    private CircleCollider2D circle;
    private BoxCollider2D box;
    private PolygonCollider2D polygon;

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
            if (GetComponent<BoxCollider2D>() != null)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            else if (GetComponent<PolygonCollider2D>() != null)
            {
                gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            }
            else if (GetComponent<CircleCollider2D>() != null)
            {
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
            }

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
