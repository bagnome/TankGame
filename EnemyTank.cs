using UnityEngine;
using System.Collections;

public class EnemyTank : MonoBehaviour {
	
	public float tankHealth = 100.0f;
	public float fireDamage = 5.0f;
	public float fireRate = 0.5f;
	private float nextFire = 0.0f;
	private float i = 100;
	private float fireDuration;
	public GameState stat;
	private float totalFireDamage = 0;
	public PointsHandler points;
	public int trackedTime;
	public EnemyMotor motor;
	public GameObject fire;
	
	// Use this for initialization
	void Start () {
		tankHealth = stat.EnemyStartHealth ();
		fire.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		stat.EnemyDamage (tankHealth);
		if (Time.time > nextFire && i < fireDuration) {
			fire.SetActive(true);
			totalFireDamage += fireDamage;
			tankHealth -= fireDamage;
			nextFire = Time.time + fireRate;
			points.CriticalHitFire(fireDamage);
			i++;
		}
		if (i >= fireDuration)
			fire.SetActive (false);
		
	}
	
	public  void IsHit(float hitValue, bool onFire, bool detracked){
		
		tankHealth -= hitValue;
		stat.EnemyDamage (tankHealth);
		if (onFire) {
			fireDuration = Random.Range(1,10);
			totalFireDamage = 0;
			i = 0;
			onFire = false;
		}

		if (detracked == true) {
			motor.Tracked();
			points.CriticalHitTracks();
			detracked = false;
		}

		points.Hit (hitValue);
		
	}

	public float getHealth(){
		return tankHealth;
	}
	
}
