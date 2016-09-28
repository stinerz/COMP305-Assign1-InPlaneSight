using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour {
	//Private Instance Variables 
	private int _speed; 
	private Transform _transform; 
	private Vector2 _position; 

	public int Speed{
		get{
			return this._speed;
		}

		set{ 
			this._speed = value; 
		}

	}

	// Use this for initialization
	void Start () {
		//transform component from the object, getting ref and storing in private class 
		this._transform = this.GetComponent<Transform> (); 

		//sets the speed 
		this._speed = 4; 

	}

	// Update is called once per frame
	void Update (){
		this._move (); 
		this._checkBoundary ();
	}

	void _move () {
		//ref Vector2
		this._position = this._transform.position; 

		//add speed to position, moving to the left  
		this._position.x -= this._speed; 

		//assign position to new position
		this._transform.position = this._position; 
	}

	//Method check game object meets right-border
	void _checkBoundary(){
		if (this._transform.position.x <= -350f) {
			this._reset (); 
		}
	}

	//Method resets the game object to original position
	void _reset(){
		//this will shift the object back
		//randomly place coins on background 
		this._transform.position = new Vector2 (350f, Random.Range(-190f, 190f)); 
	}
}
