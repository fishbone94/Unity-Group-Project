using UnityEngine;
using System.Collections;

public class HareRunAway : MonoBehaviour {
	public float jumpPower = 30;
	private int hareSpeed = 25;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}


	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			rigidbody2D.velocity = new Vector2 (hareSpeed,0);
			Death();
			}
	}
	void Death (){
			Destroy (gameObject, 1);
		}
}