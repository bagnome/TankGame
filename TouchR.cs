using UnityEngine;
using System.Collections;

public class TouchR : MonoBehaviour {
	
	public PlayerController controller;
	public Shoot shoot;
	public Turret turret;
	private bool isTouchedRight = false;
	public TouchL touch;
	
	// Update is called once per frame
	void Update () {
		if (Input.touches.Length <= 0) {
			
		}else{
			for (int i = 0; i < Input.touchCount; i++){
				if(this.guiTexture.HitTest(Input.GetTouch(i).position)){
					if(this.tag == "RightButton"){
						
						if(Input.GetTouch(i).phase == TouchPhase.Began || Input.GetTouch(i).phase == TouchPhase.Stationary){
							controller.RightButtonPressed();
							isTouchedRight = true;
						}else if (Input.GetTouch(i).phase == TouchPhase.Ended){
							controller.RightButtonReleased();
							isTouchedRight = false;
						}
						
					}
					
				}else{
					if(isTouchedRight){
						Vector2 touchPos = Input.GetTouch(i).position;
						
						turret.ScreenTouch(touchPos);
						shoot.ShootBullet();
					}
					if(!touch.touchingLeft() && !isTouchedRight){
						Vector2 touchPos = Input.GetTouch(i).position;
						
						turret.ScreenTouch(touchPos);
						shoot.ShootBullet();
					}
				}
			}
		}
	


	}

	public bool touchingRight(){
		return isTouchedRight;
	}

}
