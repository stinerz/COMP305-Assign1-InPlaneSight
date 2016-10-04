﻿using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {
	//PRIVATE INSTANCE ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	//private Transform _transform; 
	private Vector2 _position; 
	// Movement modifier applied to directional movement.
	public float playerSpeed = 10.0f;
	// What the current speed of our player is
	private float currentSpeed = 0.0f;
	// The last movement that we've made
	private Vector3 lastMovement = new Vector3();


	//PUBLIC INSTANCE VARIABLES  +++++++++++++++++++++++++++++
	public GameController gameController; 
	public AudioSource Pickup_Coin3; 
	public AudioSource Hit_Hurt8; 

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame +++++++++++++++++++++++++++++
	void Update () {
		// Move the player's body
		this._Movement();

	}
		
	// Player will play based off keys pressed +++++++++++++++++++++++++++++
	private void _Movement()
	{
		// The movement that needs to occur this frame
		Vector3 movement = new Vector3();
		// Check for input
		movement.x += Input.GetAxis ("Horizontal");
		movement.y += Input.GetAxis ("Vertical");
		movement.Normalize (); //Ensure direction is moving the same 

		// Check if we pressed anything
		if(movement.magnitude > 0)
		{
			// If we did, move in that direction
			currentSpeed = playerSpeed;
			this.transform.Translate(movement * Time.deltaTime * playerSpeed, Space.World);
			lastMovement = movement;
		}
		else
		{
			// Otherwise, move in the direction we were going
			this.transform.Translate(lastMovement * Time.deltaTime *
				currentSpeed, Space.World);
		}
	}

	//When the player collids with objects in the game +++++++++++++++++++++++++++++
	private void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.CompareTag ("Coin")) {
			this.Pickup_Coin3.Play ();
			this.gameController.ScoreValue += 10;
			 
		}		

		if (other.gameObject.CompareTag ("Bird")) {
			this.Hit_Hurt8.Play ();
			this.gameController.LivesValue -= 1;
		}

	}

}
