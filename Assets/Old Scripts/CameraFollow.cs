using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {


	public float dampTime = 10.00f;
	private Vector3 velocity = Vector3.zero * 20;
	public Transform target;

	void Start(){
		target = GameObject.Find ("Player").transform;
	}
	
	
	// Update is called once per frame
	void Update (){
		if (target)
		{
			Vector3 point = camera.WorldToViewportPoint(target.position);
			Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.25f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
	}
}