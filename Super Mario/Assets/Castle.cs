using UnityEngine;
using System.Collections;

public class Castle : MonoBehaviour {
    
    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	   
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        anim.SetTrigger("End Level");
    }

}
