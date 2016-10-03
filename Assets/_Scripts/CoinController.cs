using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {
	// PRIVATE INSTANCE VARIABLES +++++++++++++++++++++++++++++
	private int _speed;
	private Transform _transform;
	private Vector2 _newPosition; 

	// PUBLIC PROPERTIES
	public int Speed {
		get {
			return this._speed;
		}
		set {
			this._speed = value;
		}
	}


	// Use this for initialization
	void Start () {
		this._transform = this.GetComponent<Transform> ();
		this._reset ();
	}

	// Update is called once per frame
	void Update () {
		this._move ();
		this._checkBoundary ();
	}

	/**
	 * this method moves the game object down the screen by _speed px every frame
	 */
	private void _move() {
		this._newPosition = this._transform.position;

		_newPosition.x -= this._speed;

		this._transform.position = _newPosition;
	}

	//Method check game object meets right-border ++++++++++++++++++++++++++
	private void _checkBoundary(){
		if (this._transform.position.x <= -350f) {
			this._reset (); 
		}
	}

	//resets the game object to the original position
	private void _reset() {
		this._speed = 5;
		this._transform.position = new Vector2 (350f, Random.Range(-190f, 190f)); 
	}
}