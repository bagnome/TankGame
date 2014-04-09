using UnityEngine;
using System.Collections;

public class RightTouch : MonoBehaviour {
	
	public PlayerController controller;
	
	
	// Update is called once per frame
	void Update () {
		if (Input.touches.Length <= 0) {
			
		}else{
			for (int i = 0; i < Input.touchCount; i++){
				if(this.guiTexture.HitTest(Input.GetTouch(i).position)){
					if(Input.GetTouch(i).phase == TouchPhase.Began || Input.GetTouch(i).phase == TouchPhase.Stationary){
						controller.LeftButtonPressed();
					}else if (Input.GetTouch(i).phase == TouchPhase.Ended){
						controller.LeftButtonReleased();
					}
				}
			}
		}
	}
}
