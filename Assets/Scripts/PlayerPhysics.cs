using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BoxCollider))]
public class PlayerPhysics : MonoBehaviour {

	public LayerMask collisionMask;

	private BoxCollider collider;
	private Vector3 size;
	private Vector3 center;

	private float skin = .005f;

	private Transform platform;
	private Vector3 platformPositionOld;
	private Vector3 deltaPlatformPos;


	[HideInInspector]
	public bool grounded;
	[HideInInspector]
	public bool movementStopped;

	Ray ray;
	RaycastHit hit;

	void Start(){
		collider = GetComponent<BoxCollider> ();
		size = collider.size;
		center = collider.center;
	}

	public void move(Vector2 moveAmount){

		float deltaY = moveAmount.y;
		float deltaX = moveAmount.x;
		Vector2 position = transform.position;

		if (platform){
			deltaPlatformPos = platform.position - platformPositionOld;
		} else {
			deltaPlatformPos = Vector3.zero;
		}

		#region Vertical Collisions
		//Check top and bottom collisions
		grounded = false;

		for (int i = 0; i < 3; i++) {
			float dir = Mathf.Sign (deltaY);
			float x = (position.x + center.x - size.x/2) + size.x/2 * i; //left,center,right of collider
			float y = position.y + center.y + size.y/2 * dir; // bottom of collider

			ray = new Ray(new Vector2(x,y),new Vector2(0,dir));
			Debug.DrawRay (ray.origin, ray.direction);

			if (Physics.Raycast (ray, out hit, Mathf.Abs (deltaY) + skin, collisionMask)){

				platform = hit.transform;
				platformPositionOld = platform.position;
				// get distance between player and ground
				float distance = Vector3.Distance (ray.origin, hit.point);
				// stop players downwards movement after coming within skin width of a collider
				if (distance > skin){
					deltaY = distance * dir - skin * dir;
				} else {
					deltaY = 0;
				}
				grounded = true;
				break;
			} else {
				platform = null;
			}
		}
		#endregion
		
		#region Sideways Collisions
		//Check left and right collisions
		movementStopped = false;
		for (int i = 0; i < 3; i++) {
			float dir = Mathf.Sign (deltaX);
			float x = position.x + center.x + size.x/2 * dir;
			float y = (position.y + center.y - size.y/2) + size.y/2 * i;
			
			ray = new Ray(new Vector2(x,y),new Vector2(dir,0));
			Debug.DrawRay (ray.origin, ray.direction);
			
			if (Physics.Raycast (ray, out hit, Mathf.Abs (deltaX) + skin, collisionMask)){
				// get distance between player and ground
				float distance = Vector3.Distance (ray.origin, hit.point);
				// stop players downwards movement after coming within skin width of a collider
				if (distance > skin){
					deltaX = distance * dir - skin * dir;
				} else {
					deltaX = 0;
				}
				movementStopped = true;
				break;
			}
		}
		#endregion


		if (!grounded && !movementStopped){
			Vector3 playerDir = new Vector3 (deltaX, deltaY);
			Vector3 origin = new Vector3 (position.x + center.x + size.x / 2 * Mathf.Sign (deltaX), 
			                              position.y + center.y + size.y / 2 * Mathf.Sign (deltaY));
			ray = new Ray (origin, playerDir.normalized);
			Debug.DrawRay (origin, playerDir.normalized);

			if (Physics.Raycast (ray,Mathf.Sqrt (deltaX * deltaX + deltaY * deltaY), collisionMask)){
				grounded = true;
				deltaY = 0;
			}
		}

		Vector2 finalTransform = new Vector2(deltaX + deltaPlatformPos.x, deltaY);
		transform.Translate (finalTransform);
	}
}
