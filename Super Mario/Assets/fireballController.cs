using UnityEngine;
using System.Collections;

public class fireballController : MonoBehaviour {

    private float mMoveSpeed;

    public float moveSpeed
    {
        get { return mMoveSpeed; }
        set { mMoveSpeed = value; }
    }

    Rigidbody2D rb2d;

    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool hittingWall;
    public float fireballHeight;



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
            mMoveSpeed = -mMoveSpeed;

        Vector2 moveDir = new Vector2(-mMoveSpeed, rb2d.velocity.y);
        rb2d.velocity = moveDir;

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(wallCheck.position, wallCheckRadius);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        var collider2D = gameObject.GetComponent<Collider2D>();
        if (coll.gameObject.tag == "Ground")
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, fireballHeight);
        }
    }
}
