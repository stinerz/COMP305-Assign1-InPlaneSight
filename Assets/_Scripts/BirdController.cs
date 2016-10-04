/*In Plane Sight By Christina Kuo - 300721385
Bird Controller class controls Bird Prefab 
Last modified 10/01/2016 */
using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour {
	//Private Instance Variables +++++++++++++++++++++++++++++++++++++++++++
	private int _speed; 
	private int _drift; 
	private Transform _transform; 
	private Vector2 _position; 

	//Public Properties ++++++++++++++++++++++++++++++++++++++++++++++++++++
	public int Speed{
		get{
			return this._speed;
		}

		set{ 
			this._speed = value; 
		}

	}

	public int Drift{
		get{ 
			return this._drift;
		}
		set{ 
			this._drift = value; 
		}
	}

	// Use this for initialization +++++++++++++++++++++++++++++++++++++++++
	void Start () {
		//transform component from the object, getting ref and storing in private class 
		this._transform = this.GetComponent<Transform> (); 

		//sets the speed 
		this._reset (); 

	}

	// Update is called once per frame
	void Update (){
		this._move (); 
		this._checkBoundary ();
	}

	private void _move () {
		//ref Vector2
		this._position = this._transform.position; 

		//add speed to position, moving to the left  
		this._position.x -= this._speed; 
		this._position.y += this._drift; 

		//assign position to new position
		this._transform.position = this._position; 
	}

	//Method check game object meets right-border ++++++++++++++++++++++++++
	private void _checkBoundary(){
		if (this._transform.position.x <= -350f) {
			this._reset (); 
		}
	}

	//Method resets the game object to original position +++++++++++++++++++
	private void _reset(){
		this.Speed = Random.Range (3, 6); 
		this.Drift = Random.Range (-2, 4); 
		//this will shift the object back
		//randomly place coins on background 
		this._transform.position = new Vector2 (350f, Random.Range(-190f, 190f)); 
	}
}
