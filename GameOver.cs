using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public EnemyTank enemyHealth;
	public PlayerTank playerHealth;
	public GameState stat;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (enemyHealth.getHealth() <= 0.0f || playerHealth.getHealth() <= 0.0f)
			Application.LoadLevel ("mainTitle");

		if (playerHealth.getHealth () <= 0.0f) {
			stat.Points(stat.Points()/4);
			Application.LoadLevel ("mainTitle");
		}
	
	}
}
