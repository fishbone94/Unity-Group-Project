using UnityEngine;
using System.Collections;

public class Icicle : MonoBehaviour {

	public float falling = 9.8f;
	public bool fall;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		IcicleTrigger script;
		GameObject player = GameObject.Find("IcicleTrigger");
		script = player.GetComponent<IcicleTrigger> ();
		fall = script.triggered;
				if (fall == true) {
						Fall ();
				}
		}


	void Fall(){

		rigidbody2D.AddForce (transform.up * -falling);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		
				if (coll.gameObject.name == "Ground") {
						Destroy (gameObject, 1);
				}
	}
}
