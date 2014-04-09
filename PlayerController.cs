using UnityEngine;
using System.Collections;

[RequireComponent(typeof(OldMotor))]
public class PlayerController : MonoBehaviour {
	
	public float speed = 5.0f;
	private PlayerMotor motor;
	
	// Use this for initialization
	void Start () {
		motor = GetComponent<PlayerMotor> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A) && transform.position.x > -20) {
			motor.targetVel.x = -speed;
		} else if (Input.GetKey (KeyCode.D) && transform.position.x < 20) {
			motor.targetVel.x = speed;
		} else {
			motor.targetVel.x = 0;
		}
	}

	public void LeftButtonPressed(){
		if(transform.position.x > -20)
		motor.targetVel.x = -speed;
	}

	public void LeftButtonReleased(){
		motor.targetVel.x = 0;
	}
	
	public void RightButtonPressed(){
		if(transform.position.x < 20)
		motor.targetVel.x = speed;
	}

	public void RightButtonReleased(){
		motor.targetVel.x = 0;
	}
}
