using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalieController : MonoBehaviour {

	//gets the ball's Rigidbody to send it to the player
	private Rigidbody2D ballRB;
	//gets the player so we can access their position
	public GameObject player;

	//holds the variable from the other script that says if the game is in progress
	private bool gameInProgress;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameInProgress = scoreTracker.gameInProgress;
	}

	// runs when something enters the collider the script is attatched to
	void OnTriggerEnter2D (Collider2D other) {
		//generates a random boolean value to decide if the ball should pass or not
		bool shouldBlockBall = (Random.value > 0.5f);

		//uses the random value we generated to let or not let the ball through
		if(shouldBlockBall){
			//sees if the thing that enters was the ball
			if (other.gameObject.CompareTag ("ball")) {
				if (gameInProgress) {
					//teleports the ball back to in front of the player
					other.transform.position = new Vector2 (player.transform.position.x + 2, player.transform.position.y);

					//gets the rigidbody of the ball to use to alter its motion
					ballRB = other.GetComponent<Rigidbody2D> ();
					//stops the ball's motion
					ballRB.velocity = Vector2.zero;
					//stops the ball's spinning
					ballRB.angularVelocity = 0;
				}
			}
		}
	}
}
