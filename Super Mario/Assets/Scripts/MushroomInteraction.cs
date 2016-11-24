using UnityEngine;
using System.Collections;

public class MushroomInteraction : MonoBehaviour
{
    public GameObject bigMario;
    private GameObject cameraTarget;

    void start()
    {
        cameraTarget = GameObject.Find("cameraTarget");
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        
        if (coll.gameObject.tag == "Player")
 
            Destroy(gameObject);
        }
    

}
