using UnityEngine;
using System.Collections;

public class EnemyHealthBar : MonoBehaviour {
	
	public EnemyTank enemyHealth;
	public GameState stat;
	public GameObject bar;
	private Vector2 pos;
	public GUISkin Text;
	
	public void Start(){
		pos = Camera.main.WorldToScreenPoint(bar.rigidbody.position);
	}
	
	// Update is called once per frame
	void Update () {
		float health = enemyHealth.getHealth () / stat.EnemyStartHealth();
		if (health < 0)
			health = 0;
		this.transform.localScale = new Vector3(health, 1.0f,1.0f);
	}
	
	void OnGUI(){
		GUI.skin = Text;
		GUI.Label ( new Rect( pos.x-25, pos.y-245, 500, 100), Mathf.RoundToInt(enemyHealth.getHealth())+" / "+stat.EnemyStartHealth());
	}
}
