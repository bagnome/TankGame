using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMotor : MonoBehaviour {
	
	[HideInInspector]
	public Vector2 targetVel = Vector2.zero;
	
	public float maxVel = 1.0f;
	private float nextMove = 0.0f;
	public float moveRate;
	int i;


	// Use this for initialization
	void Start () {
	}
	
	void FixedUpdate(){

	}
	
	// Update is called once per frame
	void Update () {

		float randomNum;


		if (Time.time > nextMove) {
			if (i <= 0) {
				randomNum = Random.Range (0.0f, 3.0f);
				if (randomNum < 1 && transform.position.x > -17) {
					targetVel.x = -5.0f;
				} else if (randomNum >= 1 && randomNum < 2) {
					targetVel.x = 0.0f;
				} else if (randomNum >= 2 && transform.position.x < 17) {
					targetVel.x = 5.0f;
				}
			} else {
				targetVel.x = 0.0f;
				i--;
			}

			nextMove = Time.time + moveRate;

			if (transform.position.x < -2 && transform.position.x > 2)
				targetVel.x = 0.0f;
		}

		Vector2 velocity = rigidbody2D.velocity;
		velocity = (targetVel - velocity);
		velocity = velocity.normalized * (Mathf.Clamp (velocity.magnitude, 0, maxVel));
		
		//rigidbody2D.velocity = velocity;
		rigidbody2D.AddForce(ForceForForceMode(velocity, ForceMode.VelocityChange));
		
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

	public void Tracked(){
		i = 5;
	}
}
