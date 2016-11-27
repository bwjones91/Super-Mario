using UnityEngine;
using System.Collections;

public class FireballCombat : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        print(coll.gameObject.tag);
        var collider2D = gameObject.GetComponent<Collider2D>();
        float height = collider2D.bounds.size.y;
        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(gameObject); 
            Destroy(coll.gameObject);
        }
    }
}
