using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour {


    
    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("collide test");
        if (coll.gameObject.tag == "Player")
        {
            if (coll.gameObject.transform.position.y < transform.position.y)
            {
                Debug.Log("something");
                Destroy(gameObject);
            }
        }
    }
    
}
