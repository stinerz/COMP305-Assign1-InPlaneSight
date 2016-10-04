/*In Plane Sight By Christina Kuo - 300721385
Game Controller class manage scene and controls what happens when the game is over
Last modified 10/02/2016 */

using UnityEngine;
using System.Collections;

//used for ref to UI elements 
using UnityEngine.UI;

//USED FOR REF TO MANAGE SCENES 
using UnityEngine.SceneManagement; 


public class GameController : MonoBehaviour {
	//PRIVATE INSTANCE VARIABLES +++++++++++++++++++++++++++++++++++++++++
	private int _scoreValue; 
	private int _livesValue; 

	public AudioSource Fail_04A; 


	//PUBLIC INSTANCE VARIABLES ++++++++++++++++++++++++++++++++++++++++++
	public int black_birdNum = 2; 
	public int red_birdNum = 2; 
	public GameObject black_bird; 
	public GameObject red_bird; 

	//UI Objects +++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	public Text ScoreLabel; 
	public Text LivesLabel; 
	public Text FinalScoreLabel; 
	public Text GameOverLabel;
	public Button RestartButton; 

	public GameObject plane; 
	public GameObject coin; 

	//PUBLIC ACCESS METHODS ++++++++++++++++++++++++++++++++++++++++++++++
	public int LivesValue {
		get {
			return this._livesValue;
		}

		set {
			this._livesValue = value;
			if (this._livesValue <= 0) {
				this._gameOver();
			} else {
				this.LivesLabel.text = "Lives: " + this._livesValue;
			}
		}
	}

	public int ScoreValue {
		get {
			return this._scoreValue;
		}

		set {
			this._scoreValue = value;
			this.ScoreLabel.text = "Score: " + this._scoreValue;
		}
	}

	// Use this for initialization ++++++++++++++++++++++++++++++++++++++++
	void Start () {
		this.LivesValue = 3; 
		this.ScoreValue = 0; 

		this.GameOverLabel.gameObject.SetActive (false);
		this.FinalScoreLabel.gameObject.SetActive (false);
		this.RestartButton.gameObject.SetActive (false);
		this.Fail_04A = this.GetComponent<AudioSource> (); 
		for (int birdCount= 0; birdCount < this.black_birdNum; birdCount++) {
			Instantiate (this.black_bird);
		}

		for (int birdCount= 0; birdCount < this.red_birdNum; birdCount++) {
			Instantiate (this.red_bird);
		}
	
	}
	
	// Update is called once per frame ++++++++++++++++++++++++++++++++++++
	void Update () {
	
	}

	//Method for when the game is over
	private void _gameOver(){
		this.GameOverLabel.gameObject.SetActive (true); 
		//Final score will display once player dies 
		this.FinalScoreLabel.text = "FINAL SCORE: " + this.ScoreValue; 
		this.FinalScoreLabel.gameObject.SetActive (true); 
		this.RestartButton.gameObject.SetActive (true); 
		this.ScoreLabel.gameObject.SetActive (false); 
		this.LivesLabel.gameObject.SetActive (false); 
		this.LivesLabel.gameObject.SetActive (false); 
		this.Fail_04A.Play (); 
		this.plane.SetActive (false); 
		this.coin.SetActive (false); 
	}

	//loads scene when click on restart button 
	public void RestartGameButton_Click() {
		SceneManager.LoadScene ("Main");
	}
}

