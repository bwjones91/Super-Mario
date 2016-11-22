using UnityEngine;
using System.Collections;

public class QuestionMarkBox : MonoBehaviour
{


    private float height;
    public GameObject prefab;


    void Start()
    {
        var collider2D = gameObject.GetComponent<Collider2D>();
        height = collider2D.bounds.size.y;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            Vector3 blockPosition = this.transform.position;
            Vector3 marioPosition = coll.gameObject.transform.position;

            if (marioPosition.y < blockPosition.y - height / 2)
            {
                Instantiate(prefab, new Vector3(transform.position.x, transform.position.y + height, 0), Quaternion.identity);
            }

        }
    }
}

