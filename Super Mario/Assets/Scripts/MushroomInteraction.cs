using UnityEngine;
using System.Collections;

public class MushroomInteraction : MonoBehaviour
{
   
    private GameObject cameraTarget;
    private PlayerProperties playerProperties;
    private GameObject mario;


    void Start()
    {
        cameraTarget = GameObject.Find("cameraTarget");
        mario = GameObject.FindGameObjectWithTag("Player");
        playerProperties = mario.GetComponent<PlayerProperties>();
        print("started");
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            // coll.gameObject.GetComponent<PlayerProperties>().myPlayerState += 1;
            print("grow bitch");
            playerProperties.GrowPlayerState();
            Destroy(gameObject);
        }
    }
    

}
