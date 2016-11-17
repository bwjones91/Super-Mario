using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 1f;
    public float jumpHeight = 200f;
    bool facingRight = true;

    public Transform groundPoint;
    public float radius;
    public LayerMask groundMask;

    Animator anim;




    bool isGrounded;
    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb2d.AddForce(new Vector2(0, jumpHeight));
        }

      
    }

	void FixedUpdate()
    {
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        float move = Input.GetAxis("Horizontal");
        //Debug.Log(move);
        rb2d.velocity = new Vector2(move * maxSpeed * .1f, rb2d.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundPoint.position, radius, groundMask);

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
            Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
