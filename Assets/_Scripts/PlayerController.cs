using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// PUBLIC INSTANCE VARIABLES
	public float speed ;

	//PRIVATE INSTANCE VARIABLES
	private Transform _transform;
	private Vector2 _currentPosition;
	private float inputx; //to move up-down form arrow keys 
	private float inputy;//to move forward-backword form arrow keys 

	// Use this for initialization
	void Start () {
		// Make a reference with the Transform Component
		this._transform = gameObject.GetComponent<Transform> ();


	}

	// Update is called once per frame
	void Update () {
		this._currentPosition = this._transform.position;
		this.inputx = Input.GetAxis ("Vertical");
		this.inputy = Input.GetAxis ("Horizontal");


		if (this.inputx > 0)
			this._currentPosition += new Vector2 (0,this.speed);
		if (this.inputx < 0) 
			this._currentPosition -= new Vector2 (0, this.speed);
		if (this.inputy > 0)
			this._currentPosition += new Vector2 (this.speed,0);
		if (this.inputy < 0) 
			this._currentPosition -= new Vector2 (this.speed,0);	

		this.checkPosiiton ();
		this._transform.position = this._currentPosition;

	

	}

	public void checkPosiiton() {
		if (this._currentPosition.y < -200)
			this._currentPosition.y = -200;
		if (this._currentPosition.y > 200)
			this._currentPosition.y = 200;

		if (this._currentPosition.x > -725)
			this._currentPosition.x = -725;
		if (this._currentPosition.x < -1125)
			this._currentPosition.x = -1125;

	}
}
