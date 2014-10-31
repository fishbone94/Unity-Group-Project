using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float playerSpeed = 10.0f;
	public float jumpForce = 344.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		float hValue = Input.GetAxis ("Horizontal");

		rigidbody2D.velocity = new Vector2 (hValue * playerSpeed, rigidbody2D.velocity.y); 

		if (Input.GetButtonDown ("Jump"))

						rigidbody2D.AddForce (new Vector2 (0, jumpForce));
	}
}
