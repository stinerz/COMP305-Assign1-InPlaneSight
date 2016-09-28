using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {
	// Movement modifier applied to directional movement.
	public float playerSpeed = 10.0f;
	// What the current speed of our player is
	private float currentSpeed = 0.0f;
	// The last movement that we've made
	private Vector3 lastMovement = new Vector3();


	public Camera mainCamera;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		// Move the player's body
		Movement();

	}
		
	// Will move the player based off of keys pressed
	void Movement()
	{
		// The movement that needs to occur this frame
		Vector3 movement = new Vector3();
		// Check for input
		movement.x += Input.GetAxis ("Horizontal");
		movement.y += Input.GetAxis ("Vertical");
		/*
		* If we pressed multiple buttons, make sure we're only
		* moving the same length.
		*/
		movement.Normalize ();
		// Check if we pressed anything
		if(movement.magnitude > 0)
		{
			// If we did, move in that direction
			currentSpeed = playerSpeed;
			this.transform.Translate(movement * Time.deltaTime * playerSpeed, Space.World);
			lastMovement = movement;

			mainCamera.transform.Translate (movement * Time.deltaTime * playerSpeed, Space.World);
		}
		else
		{
			// Otherwise, move in the direction we were going
			this.transform.Translate(lastMovement * Time.deltaTime *
				currentSpeed, Space.World);

			mainCamera.transform.Translate(lastMovement * Time.deltaTime *currentSpeed, Space.World);

			// Slow down over time
			//currentSpeed *= 3f;
		}
	}

}
