using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreTracker : MonoBehaviour {

	//so that we can teleport the ball back to the player
	public GameObject player;
	//used in the teleportation to stop the ball from spinning
	private Rigidbody2D ballRB;

	//so we can start and stop the timer using if statements
	public static bool gameInProgress;

	//will be incremented down in the timer
	private float timeLeft = 20;
	//allows us the reset the timer
	private float time;

	//references to the text elements to change their contents
	public Text resultText;
	public Text scoreText;
	public Text timeText;

	//holds the score to show the user and maybe compare
	private int score = 0;

	// Use this for initialization
	void Start () {
		gameInProgress = true;

		//sets the original time so we ccan reset the timer
		time = timeLeft;

		//sets the text to an empty string so the user doesn't see the test text
		resultText.text = "";
		//sets the goals to say 0
		scoreText.text = "goals: " + score;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameInProgress) {
			//increments the time down
			timeLeft -= Time.deltaTime;

			//gets the minutes left in the time
			int minutes = Mathf.FloorToInt (timeLeft / 60F);
			//gets the seconds left in the time
			int seconds = Mathf.FloorToInt (timeLeft - minutes * 60);

			//changes the integers into strings to display
			string minutesString = minutes.ToString ();
			string secondsString = seconds.ToString ("00");

			//displays the minutes and seconds on the screen in a nice format
			timeText.text = string.Format ("{0:00}:{1:00}", minutesString, secondsString);

			//ends the game if the timer runs out
			if (timeLeft < 0) {
				//turns the timer off unitl the next time the scene is opened
				gameInProgress = false;

				//resets the timer 
				timeLeft = time;

				//goes through ending sequences
				GameOver ();
			}
		}
	}

	public void GameOver(){
		//sets the timer to stay at 0
		timeText.text = "0:00";

		//tells the user how many goals they scored
		resultText.text = "You scored " + score + " goals. Click replay to play again!";
	}

	// runs when something enters the collider the script is attatched to
	void OnTriggerEnter2D (Collider2D other) {
		//sees if the thing that enters was the ball
		if (other.gameObject.CompareTag ("ball")) {
			if (gameInProgress) {
				//increases the score by one
				score++;
				//updates the score display
				scoreText.text = "goals: " + score;

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
