using UnityEngine;
using System.Collections;

public class RepairTank : MonoBehaviour {

	public int cost;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Repair(){
		PlayerPrefs.SetFloat ("PlayerHealth", PlayerPrefs.GetFloat ("PlayerStartHealth"));
		//PlayerPrefs.SetInt ("Points", PlayerPrefs.GetInt ("Points") - cost);
	}

	public int DetermineCost(){
		cost = Mathf.RoundToInt (PlayerPrefs.GetFloat("PlayerStartHealth") - PlayerPrefs.GetFloat ("PlayerHealth"));
			return cost*=10;
	}
}
