using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llamaController : MonoBehaviour {

	Rigidbody2D rb;
	Animator anim;

	public float maxSpeed = 10f;
	private bool facingRight = false;

	void Start () {
		//makes it so that we can use the rigidbody component
		rb = GetComponent<Rigidbody2D> ();
		//makes it so that we can use the animator controller
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate () {


		//makes sure there's a game in progress before letting you move
		//if (REPLACE.gameInProgress == true) {
			//tells us how we want to move the character
			float move = Input.GetAxis ("Horizontal");

			//sets the speed in the animator controller
			anim.SetFloat ("Speed", Mathf.Abs (move));

			//makes the character itself move
			rb.velocity = new Vector2 (move * maxSpeed, rb.velocity.y);

			//if we're moving right and not facing right, flip us
			if (move > 0 && !facingRight) {
				Flip ();
				//if we're moving right and not facing right, flip us
			} else if (move < 0 && facingRight) {
				Flip ();
			}
		//}
	}

	//flips the character so we're facing the other direction
	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
