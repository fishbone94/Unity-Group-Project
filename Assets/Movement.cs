using UnityEngine;
using System.Collections;
public class Movement : MonoBehaviour {
	public bool grounded = true;
	public float jumpPower = 150;
	private bool hasJumped = false;
	public int playerSpeed = 5;
	
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
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
	
	void Movement2()
	{
		float hValue = Input.GetAxis ("Horizontal");
		
		rigidbody2D.velocity = new Vector2 (hValue * playerSpeed, rigidbody2D.velocity.y);
		
		
	}
}