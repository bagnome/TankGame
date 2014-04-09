using UnityEngine;
using System.Collections;

public class PlayerTank : MonoBehaviour {
	
	private float tankHealth;
	public GameState stat;
	public float fireDamage = 5.0f;
	public float fireRate = 0.5f;
	private float nextFire = 0.0f;
	private float i = 100;
	private float fireDuration;
	public GameObject fire;
	
	// Use this for initialization
	void Start () {
		if (stat.PlayerDamage() <= 0.0f || stat.PlayerDamage() == null || tankHealth <= 0.0f) tankHealth = PlayerPrefs.GetFloat ("PlayerStartHealth");
		else
			tankHealth = PlayerPrefs.GetFloat ("PlayerHealth");
		fire.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextFire && i < fireDuration) {
			fire.SetActive(true);
			tankHealth -= fireDamage;
			nextFire = Time.time + fireRate;
			i++;
		}
		if (i >= fireDuration)
			fire.SetActive (false);
		
	}
	
	public void IsHit(float hitValue, bool onFire){
		
		tankHealth -= hitValue;
		stat.PlayerDamage (tankHealth);
		if (onFire) {
			fireDuration = Random.Range(1,10);
			i = 0;
			onFire = false;
		}

		
	}

	public float getHealth(){
		return tankHealth;
	}
}
