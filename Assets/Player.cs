using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour{
	
	public bool grounded = true;
	public float jumpPower = 150;
	public float someScale;
	public int speedDecreaseRate = 1;
	public Vector3 Position ;
	
	private int MIN_PLAYER_SPEED = 200;
	private int MAX_PLAYER_SPEED = 500;
	private float MATCH_LIGHT_INTENSITY_MAX = 8f;
	private bool hasJumped = false;
	private int playerSpeed {
		get;
		set;
	}

	Checkpoint script;
	
	// Use this for initialization
	void Start (){

		someScale = transform.localScale.x;
		GameObject Checkpoint = GameObject.Find("Checkpoint");
		script = Checkpoint.GetComponent<Checkpoint> ();
		}

	// Update is called once per frame
	void Update (){

		Position = script.Pos;
		UpdatePlayerSpeed ();
		Flip ();
		light.intensity = (MATCH_LIGHT_INTENSITY_MAX * (float)MatchObject.MatchSingleton.MatchBrightnessPercentage) / 100;
		// Do something

		if (Input.GetButtonDown ("Jump") && grounded == true) {
			hasJumped = true;
		}
	}
	
	void FixedUpdate (){

		Movement ();
		if (hasJumped) {
			rigidbody2D.AddForce (transform.up * jumpPower);
			grounded = false;
			hasJumped = false;
		}
	}
	
	void Movement (){
		
		if (grounded) {
			float hValue = Input.GetAxis ("Horizontal");
			//			float floatPlayerSpeed = (float) playerSpeed;
			rigidbody2D.velocity = new Vector2 ((hValue * playerSpeed) / 100, rigidbody2D.velocity.y);
		}
	}
	
	void Flip (){
		
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			transform.localScale = new Vector2 (-1, transform.localScale.y);
			someScale = -1;
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			transform.localScale = new Vector2 (1, transform.localScale.y);
			someScale = 1;
		} else {
		}
	}
	
	void UpdatePlayerSpeed (){
		
		if (MatchObject.MatchSingleton.MatchBrightness > 0) {
			playerSpeed = MAX_PLAYER_SPEED;	
		} else if (MatchObject.MatchSingleton.MatchBrightness == 0 && playerSpeed > MIN_PLAYER_SPEED) {
			playerSpeed = (int)(playerSpeed - speedDecreaseRate);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {

				if (coll.gameObject.name == "Ground") {
						grounded = true;
				} else if (coll.gameObject.name == "Trap") {
						Respawn ();
				} else {
				}
	}

	void Respawn(){

		transform.localScale = new Vector2 (1, transform.localScale.y);
		someScale = 1;
		gameObject.transform.position = Position;
	}
}