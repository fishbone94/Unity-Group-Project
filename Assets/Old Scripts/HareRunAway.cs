using UnityEngine;
using System.Collections;

public class HareRunAway : MonoBehaviour {
	public float jumpPower = 30;
	private int hareSpeed = 25;
	private float direction;

	Player script;

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.Find("Player");
		script = player.GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		direction = script.someScale;
	}


	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			if(direction > 0){
				rigidbody2D.velocity = new Vector2 (hareSpeed,0);
				transform.localScale = new Vector2 (2, transform.localScale.y);
				Death();
			}else{
				rigidbody2D.velocity = new Vector2 (-hareSpeed,0);
				transform.localScale = new Vector2 (-2, transform.localScale.y);
				Death();
			}
			}
	}
	void Death (){
			Destroy (gameObject, 1);
		}
}