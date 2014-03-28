using UnityEngine;
using System.Collections;

public class TuxControllerScript : MonoBehaviour {

	public float maxSpeed = 10;
	bool facingRight = true;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// Gets the horzontal input
		float move = Input.GetAxis ("Horizontal");
		// Updates the animator speed variable, allowing for a transfer of animations
		anim.SetFloat ("Speed", Mathf.Abs (move));
		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
		if((move > 0 && !facingRight) || (move < 0 && facingRight)){
			Flip();
		}
	}
		
	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
