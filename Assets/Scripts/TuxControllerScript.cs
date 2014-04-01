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
		float moveLeft = Input.GetAxis ("Horizontal");
		// Updates the animator speed variable, allowing for a transfer of animations
		anim.SetFloat ("HorizSpeed", Mathf.Abs (moveLeft));
		rigidbody2D.velocity = new Vector2(moveLeft * maxSpeed, rigidbody2D.velocity.y);
		if((moveLeft > 0 && !facingRight) || (moveLeft < 0 && facingRight)){
			Flip();
		}

		// Get the vertical velocity
		float vertVel = Mathf.Abs (rigidbody2D.velocity.y);
		anim.SetFloat ("VertSpeed", vertVel);

	}
		
	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
