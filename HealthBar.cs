using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	
	public PlayerTank playerHealth;
	public GameState stat;
	public GameObject bar;
	private Vector2 pos;
	public GUISkin Text;
	
	public void Start(){
		pos = Camera.main.WorldToScreenPoint(bar.rigidbody.position);
		//this.transform.localScale = new Vector3(stat.PlayerDamage () / stat.PlayerStartHealth(), 1.0f,1.0f);

	}
	
	// Update is called once per frame
	void Update () {
		/*if (stat.PlayerStartHealth() == null && stat.PlayerDamage() == null){
			stat.PlayerStartHealth(20);
			stat.PlayerDamage(20);
		}*/
		float health = stat.PlayerDamage () / stat.PlayerStartHealth();
		if (health < 0)
			health = 0;
		this.transform.localScale = new Vector3(health, 1.0f,1.0f);
	}
	
	void OnGUI(){
		GUI.skin = Text;
		GUI.Label ( new Rect( pos.x-20, pos.y-175, 500, 100), Mathf.RoundToInt(playerHealth.getHealth())+" / "+stat.PlayerStartHealth());
	}
}
