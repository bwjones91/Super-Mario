using UnityEngine;
using System.Collections;

public class PlayerFollower : MonoBehaviour {

    public GameObject cameraTarget;
    float cameraHeight = 0.0F;
    float smoothTime = 0.2F;
    float borderX = 2.0F;
    float borderY = 2.0F;

    private Vector2 velocity;
    private bool moveScreenRight;
    private bool moveScreenLeft;
    
    void Start ()
    {
        cameraHeight = transform.position.y;
    }

    void Update()
    {

        if( cameraTarget.transform.position.x > transform.position.x)
        {
            moveScreenRight = true;
        }
        if(moveScreenRight)
        {
            // transform.position = new Vector3(Mathf.SmoothDamp(transform.position.x, transform.position.x + borderX, ref velocity.x, smoothTime), 0,-1);
            transform.position = new Vector3(cameraTarget.transform.position.x, transform.position.y, -1);
        }
        if(cameraTarget.transform.position.x <= transform.position.x)
        {
            moveScreenRight = false;
        }
    }
    

}
 