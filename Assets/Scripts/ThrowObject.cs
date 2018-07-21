using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour {
	private static int out_count = 3;
	public enum ObjectType {
		Barrel,
		Banana,
		Strawberry,
		Money,
		Rock,
		Table,
	}

	[SerializeField]
	private ObjectType type;
	[SerializeField, Range(0, 30)]
	private int damage;
	[SerializeField, Range(-30, 30)]
	private int speed;

	public Player Player { get; set; }

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (Player.Enabled == false) {
			Destroy(gameObject);
		}
		if (Input.GetMouseButtonDown(0)) {
			var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			var collition2d = Physics2D.OverlapPoint(point);
	    if (collition2d) {
	        var hitObject = Physics2D.Raycast(point, -Vector2.up);
	        if (hitObject) {
	            //Debug.Log("hit object is " + hitObject.collider.gameObject.name);
							if (hitObject.collider.gameObject == this.gameObject) {
								//Debug.Log("hit object is " + hitObject.collider.gameObject.name);
								if (speed >= 0) {
									Player.Speed += speed;
								}
								if (type == ObjectType.Money) {
									out_count -= 1;
									//Debug.Log(out_count);
									if (out_count <= 0) {
										Player.HP = 0;
										Player.GameOverText.enabled = true;
										Player.Enabled = false;
									}
								}
								var anim = Resources.Load("Prefabs/HitAnim");
								var obj = Instantiate(anim, Vector2.zero, Quaternion.identity, transform) as GameObject;
								obj.GetComponent<HitAttack>().obj = this;
								//obj.GetComponent<Animator>().Play("Effect", 0, 0.0f);
								GetComponent<Rigidbody2D>().Sleep();
								//Destroy(gameObject);
							}
	        }
	    }
		}
	}

	public void OnDestroyHitAnimation() {
		if (GetComponent<Rigidbody2D>().IsSleeping())
			GetComponent<Rigidbody2D>().WakeUp();
		Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		/*if (collider.gameObject.tag == "HitAttack") {
			//Debug.Log(collider.gameObject.name);
			if (speed >= 0) {
				Player.Speed += speed;
			}
			if (type == ObjectType.Money) {
				out_count -= 1;
				//Debug.Log(out_count);
				if (out_count <= 0) {
					Player.HP = 0;
					Player.GameOverText.enabled = true;
					Player.Enabled = false;
				}
			}
			//Player.HitAttack.SetActive(false);
			//Debug.Log(Player.Speed);
			Destroy(gameObject);
		}*/
		if (collider.gameObject.tag == "Player") {
			//Debug.Log(collider.gameObject.name);
			if (speed < 0) {
				Player.Speed += speed;
			}
			Player.HP -= damage;
			if (Player.HP <= 0) {
				Player.GameOverText.enabled = true;
				Player.Enabled = false;
			}
			Destroy(gameObject);
		}
	}
}
