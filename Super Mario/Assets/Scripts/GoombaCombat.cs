using UnityEngine;
using System.Collections;

public class GoombaCombat : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
     
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        var collider2D = gameObject.GetComponent<Collider2D>();
        float height = collider2D.bounds.size.y;
        if (coll.gameObject.tag == "Player")
        {
            Vector3 goombaPosition = this.transform.position;
            Vector3 marioPosition = coll.gameObject.transform.position;
            if (marioPosition.y > goombaPosition.y + (2*height/3))
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(coll.gameObject);
            }
            print(height);
        }
    }
}
