using UnityEngine;
using System.Collections;

public class TitleButtons : MonoBehaviour {

	public RepairTank repairTank;
	public GUIStyle menuButtons;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){

		GUI.Label (new Rect(0,0,100,100), "Credits: "+PlayerPrefs.GetInt ("Points"));
		GUILayout.BeginArea(new Rect(Screen.width/2-250, 0, 500,Screen.height));
		GUILayout.FlexibleSpace ();
		if(GUILayout.Button ("Start New Game",menuButtons)){
			NewGame();
			Application.LoadLevel("Scene");
		}


		if (PlayerPrefs.GetFloat ("PlayerStartHealth") != 0 && PlayerPrefs.GetFloat ("PlayerHealth") > 0){
			if(GUILayout.Button ("Play Game",menuButtons))
				Application.LoadLevel("Scene");
		}


		if (GUILayout.Button ("Shop",menuButtons))
			Application.LoadLevel ("Shop");


		if(GUILayout.Button ("Reset High Score",menuButtons))
			PlayerPrefs.SetInt("HighScore", 0);


		if(GUILayout.Button ("Repair Tank. Cost: " + repairTank.DetermineCost(),menuButtons)){
			if(PlayerPrefs.GetInt ("Points") >=  repairTank.DetermineCost()){
				PlayerPrefs.SetInt ("Points", PlayerPrefs.GetInt ("Points")-repairTank.DetermineCost());
				repairTank.Repair ();

			}
		}


		GUILayout.FlexibleSpace ();
		GUILayout.EndArea();

		PlayerPrefs.Save ();

	}

	void NewGame(){
		PlayerPrefs.SetInt ("Points", 1500);
		PlayerPrefs.SetInt ("DefaultRound", 30);
		PlayerPrefs.SetInt ("APRound", 0);
		PlayerPrefs.SetInt ("HERound", 0);
		PlayerPrefs.SetFloat ("PlayerHealth", 20.0f);
		PlayerPrefs.SetFloat ("PlayerStartHealth", 20.0f);
		PlayerPrefs.SetFloat ("EnemyStartHealth", 100.0f);
		PlayerPrefs.Save ();
	}
}
