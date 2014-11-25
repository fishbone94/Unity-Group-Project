using UnityEngine;
using System.Collections;

public class IcicleTrigger : MonoBehaviour {

	public bool triggered = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll){
		
		if (coll.gameObject.name == "Player") {
			triggered = true;
			Destroy (gameObject, 5);
		} else {
		}
	}
}
