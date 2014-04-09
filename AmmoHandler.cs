using UnityEngine;
using System.Collections;

public class AmmoHandler : MonoBehaviour {
	
	private int AP;
	private int HE;
	private int defaultRound;
	private int selection = 1;
	public GUIStyle BulletButton;

	// Use this for initialization
	void Start () {

		defaultRound = PlayerPrefs.GetInt ("DefaultRound");

		AP = PlayerPrefs.GetInt ("APRound");

		HE = PlayerPrefs.GetInt ("HERound");
	}


	void OnGUI(){


		GUILayout.BeginArea (new Rect(10,50,100,250));
		GUILayout.FlexibleSpace ();
		if(GUILayout.Button ("Ammo: "+defaultRound, BulletButton)){
			selection = 1;
			BulletButton.active.Equals(true);
		}
		if(AP > 0){
			if(GUILayout.Button ("AP Ammo: "+AP, BulletButton)){
				selection = 2;
			}
		}
		if(HE > 0){
			if(GUILayout.Button ("HE Ammo: "+HE, BulletButton)){
				selection = 3;
			}
		}
		GUILayout.FlexibleSpace ();
		GUILayout.EndArea ();
		
	}

	void OnDestroy(){
		PlayerPrefs.SetInt ("DefaultRound", defaultRound);
		PlayerPrefs.SetInt ("APRound", AP);
		PlayerPrefs.SetInt ("HERound", HE);
	}
	
	public void SubtractBullet(){
		switch (selection) {
		case 1: 
			defaultRound --;
			break;
		case 2: 
			if(AP <= 0)selection = 1;
			else AP --;
			break;
		case 3: 
			if(HE <= 0)selection = 1;
			else HE --;
			break;
		}
		PlayerPrefs.SetInt ("DefaultRound", defaultRound);
		PlayerPrefs.SetInt ("APRound", AP);
		PlayerPrefs.SetInt ("HERound", HE);
		if (defaultRound <= 0 && AP <= 0 && HE <= 0) Application.LoadLevel("mainTitle");
	}

	public int AmmoInUse(){
		return selection;
	}


}
