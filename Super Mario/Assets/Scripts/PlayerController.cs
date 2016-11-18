using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 1f;
    public float jumpHeight = 200f;
    bool facingRight = true;

    public Transform groundPoint;
    public float radius;
    public LayerMask groundMask;
    public float jumpHoldDuration = 2;

    Animator anim;


    bool jumpInput;
    bool jumpHoldInput;
    bool jumpHold;
    bool isGrounded;
    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

    void Update()
    {
      

        if (Input.GetKey(KeyCode.RightShift))
        {
            maxSpeed = 20;
        }
        else maxSpeed = 10;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpInput = true;
        }


        if (Input.GetKey(KeyCode.Space))
        {
            jumpHoldInput = true;
        }
        else jumpHoldInput = false;
     

      
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

        if (jumpInput)
        {
            jumpInput = false;
            if (isGrounded)
            {
                print("jump");
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
                jumpHold = true;
                Invoke("EndJumpHold", jumpHoldDuration);
            }
            else print("couldnt jump");
        }

        if (jumpHoldInput)
        {
            if(!isGrounded && jumpHold == true)
            rb2d.AddForce(new Vector2(0, 10));
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2d(Collision2D coll)
    {
        Debug.Log("collide test");
      
    }

    void EndJumpHold()
    {
        jumpHold = false;
    }


}
