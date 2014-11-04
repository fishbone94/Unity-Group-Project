using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float playerSpeed = 10.0f;
	public float jumpForce = 350.0f;
	[HideInInspector]
	public bool jump = false;

	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;			// Whether or not the player is grounded.


	// Use this for initialization
	void Awake(){
		// Setting up references.
		groundCheck = transform.Find("groundCheck");
	}
	
	void Update(){
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  
		
		// If the jump button is pressed and the player is grounded then the player should jump.
		if(Input.GetButtonDown("Jump") && grounded)
			jump = true;
	}

	void Start(){
	
	}
	
	// Update is called once per frame
	void FixedUpdate(){
	
		float hValue = Input.GetAxis ("Horizontal");

		rigidbody2D.velocity = new Vector2 (hValue * playerSpeed, rigidbody2D.velocity.y); 

	if(jump){
			// Add a vertical force to the player.
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}
		if (Input.GetButtonDown ("Jump"))
						rigidbody2D.AddForce (new Vector2 (0, jumpForce));
	}
}
