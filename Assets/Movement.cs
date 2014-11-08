using UnityEngine;
using System.Collections;
public class Movement : MonoBehaviour {
	public bool grounded = true;
	public float jumpPower = 150;
	private bool hasJumped = false;
	private int MAX_PLAYER_SPEED = 5;
	private float MATCH_LIGHT_INTENSITY_MAX = 8f;
	private float someScale = 1;
	private int playerSpeed{
		get;
		set;
	}
	
	// Use this for initialization
	void Start () {
		someScale = transform.localScale.x;
	}
	// Update is called once per frame
	void Update () {
		playerSpeed = MAX_PLAYER_SPEED * MatchObject.MatchSingleton.MatchBrightnessPercentage;
		light.intensity = (MATCH_LIGHT_INTENSITY_MAX * (float) MatchObject.MatchSingleton.MatchBrightnessPercentage)/100;
		Movement2 ();
		// Do something
		if(!grounded && rigidbody2D.velocity.y == 0) {
			grounded = true;
		}
		if (Input.GetButtonDown("Jump") && grounded == true) {
			hasJumped = true;
		}
}
	void FixedUpdate (){
		if(hasJumped){
			rigidbody2D.AddForce(transform.up*jumpPower);
			grounded = false;
			hasJumped = false;
		}
	}
	
	void Movement2(){
		if (grounded) {
			Flip();
			float hValue = Input.GetAxis ("Horizontal");
//			float floatPlayerSpeed = (float) playerSpeed;
			rigidbody2D.velocity = new Vector2 ((hValue * playerSpeed)/100, rigidbody2D.velocity.y);
				}
	}
	void Flip(){
				if (Input.GetKeyDown (KeyCode.LeftArrow)) {
						transform.localScale = new Vector2 (-someScale, transform.localScale.y);
				} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
						transform.localScale = new Vector2 (someScale, transform.localScale.y);
				} else {
				}
		}


}