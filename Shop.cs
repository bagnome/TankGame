using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {
	public GUIStyle menuButtons;

	void OnGUI(){


		GUILayout.BeginArea (new Rect (Screen.width/2-350, 0, 700, Screen.height));
		GUILayout.FlexibleSpace ();
		if (GUILayout.Button ("Buy 20 Default Ammo: Free", menuButtons)) {
				PlayerPrefs.SetInt ("DefaultRound", PlayerPrefs.GetInt ("DefaultRound") + 20);
		}

		if (GUILayout.Button ("Buy 5 AP Ammo: 200 Credits", menuButtons)) {
			if(PlayerPrefs.GetInt ("Points") >= 200){
				PlayerPrefs.SetInt ("APRound", PlayerPrefs.GetInt ("APRound") + 5);
				PlayerPrefs.SetInt ("Points", PlayerPrefs.GetInt ("Points")-200);
			}
		}
		if (GUILayout.Button ("Buy 5 HE Ammo: 200 Credits", menuButtons)) {
			if(PlayerPrefs.GetInt ("Points") >= 200){
				PlayerPrefs.SetInt ("HERound", PlayerPrefs.GetInt ("HERound") + 5);
				PlayerPrefs.SetInt ("Points", PlayerPrefs.GetInt ("Points")-200);
			}
		}
		if (GUILayout.Button ("Buy Armor Upgrade, +10 Armor: 1000 Credits", menuButtons)) {
			if(PlayerPrefs.GetInt ("Points") >= 1000){
				PlayerPrefs.SetFloat("PlayerStartHealth", PlayerPrefs.GetFloat ("PlayerStartHealth")+10);
				PlayerPrefs.SetFloat ("PlayerHealth",PlayerPrefs.GetFloat("PlayerStartHealth"));
				PlayerPrefs.SetInt ("Points", PlayerPrefs.GetInt ("Points")-1000);
			}
		}
		if (GUILayout.Button ("Back", menuButtons))
						Application.LoadLevel ("mainTitle");
		GUILayout.FlexibleSpace ();
		GUILayout.EndArea ();
		GUI.Label (new Rect (0, 0, 300, 100), "Credits: "+PlayerPrefs.GetInt ("Points"));
		PlayerPrefs.Save ();
	}
}
