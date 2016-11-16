using UnityEngine;
using System.Collections;

public class GoombaMovement : MonoBehaviour {


    public float moveSpeed = 1f;
    Rigidbody2D rb2d;

    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool hittingWall;



    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        if (hittingWall)
            moveSpeed = -moveSpeed;

        Vector2 moveDir = new Vector2(-moveSpeed, rb2d.velocity.y);
        rb2d.velocity = moveDir;
	
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(wallCheck.position, wallCheckRadius);
    }
}
