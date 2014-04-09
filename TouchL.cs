using UnityEngine;
using System.Collections;

public class TouchL : MonoBehaviour {
	
	public PlayerController controller;
	public Shoot shoot;
	public Turret turret;
	private bool isTouchedLeft = false;
	public TouchR touch;

	
	
	// Update is called once per frame
	void Update () {
		if (Input.touches.Length <= 0) {
			
		}else{
			for (int i = 0; i < Input.touchCount; i++){
				if(this.guiTexture.HitTest(Input.GetTouch(i).position)){
					if(this.tag == "LeftButton"){
						if(Input.GetTouch(i).phase == TouchPhase.Began || Input.GetTouch(i).phase == TouchPhase.Stationary){
							controller.LeftButtonPressed();
							isTouchedLeft = true;
						}else if (Input.GetTouch(i).phase == TouchPhase.Ended){
							controller.LeftButtonReleased();
							isTouchedLeft = false;
						}
					}
					
				}else{
					if(isTouchedLeft){
						Vector2 touchPos = Input.GetTouch(i).position;
					
						turret.ScreenTouch(touchPos);
						shoot.ShootBullet();
					}
					if(!touch.touchingRight() && !isTouchedLeft){
						Vector2 touchPos = Input.GetTouch(i).position;
						
						turret.ScreenTouch(touchPos);
						shoot.ShootBullet();
					}
				}
			}
		}
	}

	public bool touchingLeft(){
		return isTouchedLeft;
	}

}
