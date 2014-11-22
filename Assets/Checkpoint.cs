using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	public float xPos;
	public float yPos;
	public float zPos;
	public Vector3 Pos = new Vector3();

	// Use this for initialization
	void Start () {
		Position ();
		Pos = new Vector3(xPos, yPos, zPos);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Position ();
	}

	void OnTriggerEnter2D(Collider2D coll){

		if (coll.gameObject.name == "Player") {
			Pos = coll.transform.position;
			} else {
		}
	}

	void Position (){

		GameObject Player = GameObject.Find ("Player");
		xPos = Player.transform.position.x;
		yPos = Player.transform.position.y;
		zPos = Player.transform.position.z;
	}
}
