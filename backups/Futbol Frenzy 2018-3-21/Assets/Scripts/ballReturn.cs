using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballReturn : MonoBehaviour {

	public GameObject player;
	private Rigidbody2D ballRB;

	// Use this for initialization
	void Start () {
		
	}
	
	// runs when something enters the collider the script is attatched to
	void OnTriggerEnter2D (Collider2D other) {
		//sees if the thing that enters was the ball
		if(other.gameObject.CompareTag ("ball")){
			//teleports the ball back to in front of the player
			other.transform.position = new Vector2(player.transform.position.x + 2, player.transform.position.y);

			//gets the rigidbody of the ball to use to alter its motion
			ballRB = other.GetComponent<Rigidbody2D> ();
			//stops the ball's motion
			ballRB.velocity = Vector2.zero;
			//stops the ball's spinning
			ballRB.angularVelocity = 0;
		}
	}
}
