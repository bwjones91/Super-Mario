using UnityEngine;
using System.Collections;

public class GoombaCombat : MonoBehaviour {



    private PlayerProperties playerProperties;
    private GameObject mario;

    // Use this for initialization
    void Start () {
        mario = GameObject.FindGameObjectWithTag("Player");
        playerProperties = mario.GetComponent<PlayerProperties>();
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
            Vector2 marioGroundPosition = GameObject.FindGameObjectWithTag("GroundCheck").transform.position;
            if (marioGroundPosition.y > goombaPosition.y + height/3)
            {
              
                Destroy(gameObject);
            }
            else
            {
                playerProperties.ShrinkPlayerState();
            }
            print(height);
            print(marioGroundPosition.y);
            print(goombaPosition.y);
        }
    }
}
