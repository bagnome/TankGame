﻿using UnityEngine;
using System.Collections;

public class EnemyTurret : MonoBehaviour {
	
	private float rotation;
	public float angle = 1;
	public Turret playerTurret; //player turret
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		Vector2 coords = playerTurret.rigidbody.transform.position;
		Vector2 turret = this.rigidbody.position;	
		
		
		if (coords.x <= turret.x) {//is mouse to the left?
			
			if(coords.y <= turret.y){//is mouse below?
				
				rotation = Mathf.Atan(Mathf.Abs(coords.y - turret.y)/Mathf.Abs(coords.x - turret.x))*Mathf.Rad2Deg;
				
			}else{//mouse is above
				
				rotation = 270.0f + Mathf.Atan(Mathf.Abs(coords.x - turret.x)/Mathf.Abs(coords.y - turret.y))*Mathf.Rad2Deg;
				
			}
			
			angle = rotation;
			transform.localEulerAngles = new Vector3(0,0,rotation);
			
		}else{//mouse is to right
			
			if(coords.y <= turret.y){//is mouse below?
				
				rotation = 90.0f + Mathf.Atan(Mathf.Abs(coords.x - turret.x)/Mathf.Abs(coords.y - turret.y))*Mathf.Rad2Deg;
				
			}else{//mouse is above
				
				rotation = 180.0f + Mathf.Atan(Mathf.Abs(coords.y - turret.y)/Mathf.Abs(coords.x - turret.x))*Mathf.Rad2Deg;
				
			}
			angle = rotation;
			transform.localEulerAngles = new Vector3(0,0,rotation);	
		}
	}
	
	public float GetAngle(){
		return angle;
		
	}
}
