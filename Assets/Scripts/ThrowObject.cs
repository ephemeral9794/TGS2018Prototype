using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour {

	public Player Player { get; set; }

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Enemy.Enabled == false) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "HitAttack") {
			//Debug.Log(collider.gameObject.name);
			Destroy(gameObject);
		}
		if (collider.gameObject.tag == "Player") {
			//Debug.Log(collider.gameObject.name);
			Player.HP -= Player.Damage;
			if (Player.HP <= 0) {
				Player.GameOverText.enabled = true;
				Enemy.Enabled = false;
			}
			Destroy(gameObject);
		}
	}
}
