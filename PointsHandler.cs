using UnityEngine;
using System.Collections;

public class PointsHandler : MonoBehaviour {

	private float points;
	public GameState stat;
	public GUISkin Text;

	public void Update(){
		stat.HighScore (stat.Points ());
	}

	public void Hit(float hitValue){
		points += hitValue * 10;
		stat.Points(Mathf.RoundToInt(points));
	}

	public void CriticalHitFire(float damage){
		points += damage * 15;
		stat.Points(Mathf.RoundToInt(points));
	}

	public void CriticalHitTracks(){
		points += 100;
		stat.Points(Mathf.RoundToInt(points));
	}

	/*void OnGUI(){

		GUI.skin = Text;
		GUI.Label (new Rect(10,10,300, 100), "Score: " + stat.Points());
		GUI.Label (new Rect(10,50,300, 100), "High Score: " + stat.HighScore());
	}*/
}
