using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	public EnemyTank enemyTank;
	public PlayerTank playerTank;
	public float fireChance = 0.1f;
	public float trackedChance = 0.1f;
	public float EfireChance = 0.1f;
	public float EtrackedChance = 0.1f;
	public AmmoHandler ammo;
	private float damagePlus;
	
	// Use this for initialization
	void Start () {

		//Destroy (gameObject, 2);
		
	}
	
	// Update is called once per frame
	
	void OnTriggerEnter2D (Collider2D col){

		switch (ammo.AmmoInUse ()) {
		case 1: 
			EfireChance = 0.1f;
			EtrackedChance = 0.1f;
			damagePlus = 0.0f;
			break;
		case 2:
			EfireChance = 0.1f;
			EtrackedChance = 0.1f;
			damagePlus = 20.0f;
			break;
		case 3:
			EfireChance = 0.4f;
			EtrackedChance = 0.4f;
			damagePlus = -9.0f;
			break;
		}
		
		if (col.tag == "EnemyHull") {
			bool detracted = false;
			if(Random.Range(0.0f, 1.0f) < EtrackedChance)
				detracted = true;
			print ("Enemy hit in the hull");
			Destroy (this.gameObject);
			enemyTank.IsHit(Random.Range (0.0f, 20.0f + damagePlus), false, detracted);
			
		}
		if (col.tag == "EnemyFront") {
			
			print ("Enemy hit in the Front");
			Destroy (this.gameObject);
			enemyTank.IsHit(Random.Range (0.0f, 10.0f + damagePlus), false, false);
			
		}
		if (col.tag == "EnemyBack") {
			bool onFire = false;
			if(Random.Range(0.0f, 1.0f) < EfireChance)
				onFire = true;
			print ("Enemy hit in the Back");
			Destroy (this.gameObject);
			enemyTank.IsHit(Random.Range (10.0f, 30.0f + damagePlus), onFire, false);
			
		}
		if (col.tag == "PlayerHull") {
			
			print ("Player hit in the hull");
			Destroy (this.gameObject);
			playerTank.IsHit(Random.Range (0.0f, 20.0f), false);
			
		}
		if (col.tag == "PlayerFront") {
			
			print ("Player hit in the Front");
			Destroy (this.gameObject);
			playerTank.IsHit(Random.Range (0.0f, 10.0f), false);
			
		}
		if (col.tag == "PlayerBack") {
			bool onFire = false;
			if(Random.Range(0.0f, 1.0f) < fireChance)
				onFire = true;
			print ("Player hit in the Back");
			Destroy (this.gameObject);
			playerTank.IsHit(Random.Range (10.0f, 30.0f), onFire);
			
		}
		if (col.tag == "Bounds")
			Destroy (this.gameObject);
	}



}

