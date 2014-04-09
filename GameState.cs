using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public int playerScore;
	public float enemyDamage;
	public float playerDamage;
	public float enemyStartHealth;
	public float playerStartHealth;
	public int points;
	public int highScore;

	// Use this for initialization
	void Start () {
		highScore = PlayerPrefs.GetInt ("HighScore");
		playerDamage = PlayerPrefs.GetFloat ("PlayerHealth");
		playerStartHealth = PlayerPrefs.GetFloat ("PlayerStartHealth");
		enemyStartHealth = PlayerPrefs.GetFloat ("EnemyStartHealth");
		points = 0;
	}

	public void EnemyDamage(float i){
		enemyDamage = i;
	}

	public float EnemyDamage(){
		return enemyDamage;
	}

	public void PlayerDamage(float i){
		playerDamage = i;
	}
	
	public float PlayerDamage(){
		return playerDamage;
	}


	public void EnemyStartHealth(float i){
		enemyStartHealth = i;
	}
	
	public float EnemyStartHealth(){
		return enemyStartHealth;
	}

	public void PlayerStartHealth(float i){
		playerStartHealth = i;
	}

	public float PlayerStartHealth(){
		return playerStartHealth;
	}

	public void Points(int i){
		points = i;
	}

	public int Points(){
		return points;
	}

	public void HighScore(int i){
		if (i > highScore)
			highScore = i;
	}
	public int HighScore(){
		return highScore;
	}

	void OnDestroy(){
		PlayerPrefs.SetInt ("HighScore", highScore);
		PlayerPrefs.SetInt ("Points", PlayerPrefs.GetInt ("Points") + points);
		PlayerPrefs.SetFloat ("PlayerHealth", playerDamage);
		PlayerPrefs.SetFloat ("PlayerStartHealth", playerStartHealth);
		PlayerPrefs.SetFloat ("EnemyStartHealth", PlayerPrefs.GetFloat ("EnemyStartHealth")+5);
		PlayerPrefs.Save ();
	}
}
