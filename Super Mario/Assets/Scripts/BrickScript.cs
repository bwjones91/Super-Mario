using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour {


    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (coll.gameObject.transform.position.y < transform.position.y)
            {
                Destroy(gameObject);
            }
            Rigidbody2D marioRB2D = coll.gameObject.GetComponent<Rigidbody2D>();
            marioRB2D.velocity = new Vector2(marioRB2D.velocity.x, -1);
        }
    }
    
}
