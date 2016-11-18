using UnityEngine;
using System.Collections;

public class Texture : MonoBehaviour {

    public float moveSpeed = 1f;
    Rigidbody2D rb2d;



	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb2d.velocity.y);
        rb2d.velocity = moveDir;
    }
}
