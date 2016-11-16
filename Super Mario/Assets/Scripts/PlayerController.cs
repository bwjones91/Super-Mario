using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 1f;
    bool facingRight = true;

    void Start()
    {

    }

	void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        Debug.Log(move);
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed * .1f, GetComponent<Rigidbody2D>().velocity.y);

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
