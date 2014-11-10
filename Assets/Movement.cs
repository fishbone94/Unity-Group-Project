using UnityEngine;
using System.Collections;
public class Movement : MonoBehaviour {
	public bool grounded = true;
	public float jumpPower = 150;
	private bool hasJumped = false;
	private int MIN_PLAYER_SPEED = 200;
	private int MAX_PLAYER_SPEED = 700;
	private float MATCH_LIGHT_INTENSITY_MAX = 8f;
	public float someScale;
	private int playerSpeed {
				get;
				set;
	}
	
	// Use this for initialization
	void Start () {
		someScale = transform.localScale.x;

	}
	// Update is called once per frame
	void Update () {
		UpdatePlayerSpeed ();
		light.intensity = (MATCH_LIGHT_INTENSITY_MAX * (float) MatchObject.MatchSingleton.MatchBrightnessPercentage)/100;
			// Do something
		if(!grounded && rigidbody2D.velocity.y == 0) {
			grounded = true;
		}
		if (Input.GetButtonDown("Jump") && grounded == true) {
			hasJumped = true;
		}


}
	void FixedUpdate (){
		Movement2 ();
		Flip ();
		if(hasJumped){
			rigidbody2D.AddForce(transform.up*jumpPower);
			grounded = false;
			hasJumped = false;
		}
	}
	
	void Movement2(){
		if (grounded) {
			float hValue = Input.GetAxis ("Horizontal");
//			float floatPlayerSpeed = (float) playerSpeed;
			rigidbody2D.velocity = new Vector2 ((hValue * playerSpeed)/100, rigidbody2D.velocity.y);
				}
	}
	void Flip(){
				if (Input.GetKeyDown (KeyCode.LeftArrow)) {
						transform.localScale = new Vector2 (-1, transform.localScale.y);
			someScale = -1;
				} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
						transform.localScale = new Vector2 (1, transform.localScale.y);
			someScale = 1;
				} else {
				}
		}

	void UpdatePlayerSpeed(){
		if (MatchObject.MatchSingleton.MatchBrightness > 0) {
						playerSpeed = MAX_PLAYER_SPEED - MIN_PLAYER_SPEED;	
				} else if (MatchObject.MatchSingleton.MatchBrightness == 0 && playerSpeed > MIN_PLAYER_SPEED) {
						playerSpeed = (int)(playerSpeed - 1);
				} else
						playerSpeed = MIN_PLAYER_SPEED;
	}
	
}