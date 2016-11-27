using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour {


    
    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("collide test");
        if (coll.gameObject.tag == "Player")
        {
            if (coll.gameObject.transform.position.y - .8 < transform.position.y)
            {
                Debug.Log("something");
                Destroy(gameObject);
            }
            Rigidbody2D marioRB2D = coll.gameObject.GetComponent<Rigidbody2D>();
            marioRB2D.velocity = new Vector2(marioRB2D.velocity.x, -1);
        }
    }
    
}
