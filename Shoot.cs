using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	
	public Rigidbody2D Bullet;
	public AmmoHandler ammo;
	public float speed;
	public Turret turret;
	public float angle;
	public float fireRate;
	private float nextFire = 0.0f;
	private float accuracy;
	public float percentAccuracy = 0.95f;
	public PlayerMotor motor;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	/*void Update () {
		
		if(Input.GetButtonDown("Fire1")&&Time.time > nextFire){
		
			ammo.SubtractBullet ();
			if(motor.targetVel.x != 0.0f) accuracy  = 90.0f - 90.0f*0.7f;
			else accuracy  =  90.0f - 90.0f*percentAccuracy;
			nextFire = Time.time + fireRate;
			Rigidbody2D bulletInstance = Instantiate(Bullet, transform.position, Quaternion.identity) as Rigidbody2D;
			bulletInstance.velocity = new Vector2(GetXSpeed (),GetYSpeed());
			
			
		}
	}*/

	public void ShootBullet(){
		if(Input.GetButtonDown("Fire1")&&Time.time > nextFire){
			if(motor.targetVel.x != 0.0f) accuracy  = 90.0f - 90.0f*0.7f;
			else accuracy  =  90.0f - 90.0f*percentAccuracy;
			nextFire = Time.time + fireRate;
			Rigidbody2D bulletInstance = Instantiate(Bullet, transform.position, Quaternion.identity) as Rigidbody2D;
			bulletInstance.velocity = new Vector2(GetXSpeed (),GetYSpeed());
			ammo.SubtractBullet ();
		}
	}
	
	float GetYSpeed(){
		
		float ySpeed;
		int quad;
		angle = turret.GetAngle () + Random.Range(-accuracy, accuracy);
		
		if (angle < 90) {
			quad = 1;
		}else if (angle >= 90 && angle < 180){
			quad = 2;
			angle = angle - 90;
		}else if (angle >= 180 && angle < 270){
			quad = 3;
			angle = angle - 180;
		}else{
			quad = 4;
			angle = angle - 270;
		}
		
		if(quad == 1 || quad == 3) ySpeed = speed * (Mathf.Sin (angle * Mathf.Deg2Rad) * Mathf.Rad2Deg);
		else ySpeed = speed * (Mathf.Cos (angle * Mathf.Deg2Rad) * Mathf.Rad2Deg);
		
		if (quad == 1 || quad == 2)
			ySpeed = -ySpeed;
		
		return ySpeed;
	}
	
	float GetXSpeed(){
		
		float xSpeed;
		int quad;
		angle = turret.GetAngle () + Random.Range(-accuracy, accuracy);
		
		if (angle < 90) {
			quad = 1;
		}else if (angle >= 90 && angle < 180){
			quad = 2;
			angle = angle - 90;
		}else if (angle >= 180 && angle < 270){
			quad = 3;
			angle = angle - 180;
		}else{
			quad = 4;
			angle = angle - 270;
		}
		
		if(quad == 1 || quad == 3) xSpeed = speed * (Mathf.Cos (angle * Mathf.Deg2Rad) * Mathf.Rad2Deg);
		else xSpeed = speed * (Mathf.Sin (angle * Mathf.Deg2Rad) * Mathf.Rad2Deg);
		
		if (quad == 1 || quad == 4)
			xSpeed = -xSpeed;
		
		return xSpeed;
	}
}
