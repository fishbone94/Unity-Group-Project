using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : Entity {

	//Player Handling
	public float gravity = 20;
	public float speed = 8;
	public float acceleration = 30;
	public float jumpHeight = 12;

	//System
	private float currentSpeed;
	private float targetSpeed;
	private Vector2 amountToMove;

	//Components
	private PlayerPhysics playerPhysics;
	private GameManager manager;

	void Start () {
		playerPhysics = GetComponent<PlayerPhysics>();
		manager = Camera.main.GetComponent<GameManager>();
	}


	void Update () {

		if (playerPhysics.movementStopped) {
			targetSpeed = 0;
			currentSpeed = 0;
		}

		targetSpeed = Input.GetAxisRaw ("Horizontal")* speed;
		currentSpeed = IncrementTowards (currentSpeed, targetSpeed, acceleration);

		if (playerPhysics.grounded) {
			// Reset gravity
			amountToMove.y = 0;

			// Jump
			if (Input.GetButtonDown ("Jump")){
				amountToMove.y = jumpHeight;
			}
		}

		amountToMove.x = currentSpeed;
		amountToMove.y -= gravity * Time.deltaTime;
		playerPhysics.move (amountToMove * Time.deltaTime);
	}

	void OnTriggerEnter(Collider c){
		if (c.tag == "Checkpoint"){
			manager.SetCheckpoint(c.transform.position);
		}
		if (c.tag == "Finish"){
			manager.EndLevel();
		}
	}

	private float IncrementTowards(float n, float target, float acc){
		if (n == target) {
			return n;
		} else {
			float dir = Mathf.Sign (target - n);
			n += acc * Time.deltaTime * dir;
			return (dir == Mathf.Sign (target - n)) ? n : target;
		}
	}
}

