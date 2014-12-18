using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	public float speed = 2;
	public float direction = 1;

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * direction * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider c){
		if (c.tag == "Ground"){
			direction = -direction;
		}
	}
}
