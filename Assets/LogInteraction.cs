using UnityEngine;
using System.Collections;

public class LogInteraction : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D c) {
		GameObject log = GameObject.Find ("Log");
		if (c.gameObject.tag == "Player") {
			if (Input.GetKeyDown(KeyCode.E))
				LowerLog(log);
		}
	}
	
	void LowerLog(GameObject log) {
		log.rigidbody.AddForceAtPosition (new Vector3 (5,0), new Vector3 (1,1));
	}

}
