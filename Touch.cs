using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {

	public PlayerController controller;
	public Shoot shoot;
	public Turret turret;


	// Update is called once per frame
	void Update () {
		if (Input.touches.Length <= 0) {
			
		}else{
			for (int i = 0; i < Input.touchCount; i++){
				if(this.guiTexture.HitTest(Input.GetTouch(i).position)){
					if(this.tag == "LeftButton"){
						if(Input.GetTouch(i).phase == TouchPhase.Began || Input.GetTouch(i).phase == TouchPhase.Stationary){
							controller.LeftButtonPressed();
						}else if (Input.GetTouch(i).phase == TouchPhase.Ended){
							controller.LeftButtonReleased();
						}
					}else if(this.tag == "RightButton"){
						if(Input.GetTouch(i).phase == TouchPhase.Began || Input.GetTouch(i).phase == TouchPhase.Stationary){
							controller.RightButtonPressed();
						}else if (Input.GetTouch(i).phase == TouchPhase.Ended){
							controller.RightButtonReleased();
						}
					}else{
						Vector2 touchPos = Input.GetTouch(i).position;

						turret.ScreenTouch(touchPos);
						shoot.ShootBullet();
					}

				}
			}
		}
	}
}
