using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class OldMotor : MonoBehaviour {
	
	[HideInInspector]
	public Vector2 targetVel = Vector2.zero;
	
	public float maxVel = 1.0f;
	
	// Use this for initialization
	void Start () {
	}
	
	void FixedUpdate(){
		Vector2 velocity = rigidbody2D.velocity;
		velocity = (targetVel - velocity);
		velocity = velocity.normalized * (Mathf.Clamp (velocity.magnitude, 0, maxVel));
		
		//rigidbody2D.velocity = velocity;
		rigidbody2D.AddForce(ForceForForceMode(velocity, ForceMode.VelocityChange));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	Vector2 ForceForForceMode(Vector2 force, ForceMode forceMode){
		switch (forceMode) {
		case ForceMode.Force:
			return force;
		case ForceMode.Impulse:
			return force/Time.fixedDeltaTime;
		case ForceMode.Acceleration:
			return force*rigidbody2D.mass;
		case ForceMode.VelocityChange:
			return force*rigidbody2D.mass/Time.fixedDeltaTime;
		}
		
		return force;
	}
}
