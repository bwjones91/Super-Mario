using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private float runSpeed;
    public float regularSpeed;
    public float boostedSpeed;
    public float jumpHeight = 200f;
    public float move;
    public bool facingRight { get; private set; }

    public Transform groundPoint;
    public float radius;
    public LayerMask groundMask;
    public float jumpHoldDuration = 2;

    Animator anim;

    bool duckInput;

    bool jumpInput;
    bool jumpHoldInput;
    bool jumpHold;
    bool isGrounded;
    Rigidbody2D rb2d;

    PlayerProperties playerProperties;
    BoxCollider2D boxCollider2D;
    PolygonCollider2D polygonCollider2D;


    void Start()
    {
        facingRight = true;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerProperties = GetComponent<PlayerProperties>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {


        if (Input.GetKey(KeyCode.RightShift))
        {
            runSpeed = boostedSpeed;
        }
        else runSpeed = regularSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpInput = true;
        }


        if (Input.GetKey(KeyCode.Space))
        {
            jumpHoldInput = true;
        }
        else jumpHoldInput = false;

        if (Input.GetKeyDown(KeyCode.S))
        {
            enterDuck();
        }
        if (Input.GetKeyUp(KeyCode.S))
        { 
             exitDuck();
        }


     

      
    }

	void FixedUpdate()
    {
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        anim.SetBool("Grounded", isGrounded);

        move = Input.GetAxis("Horizontal");
        //Debug.Log(move);
        rb2d.velocity = new Vector2(move * runSpeed * .1f, rb2d.velocity.y);

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

    void enterDuck()
    {
        boxCollider2D.enabled = false;
        polygonCollider2D.enabled = false;
    }

    void exitDuck()
    {
        boxCollider2D.enabled = true;
        polygonCollider2D.enabled = true;
    }


}
