using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour {

    void OnCollisionEnter2d(Collision2D coll)
    {
       
        if (coll.gameObject.tag == ("Player"))
        {
            Debug.Log("DELETE THIS BITCH");
            Destroy(gameObject);
        }
    }
}
