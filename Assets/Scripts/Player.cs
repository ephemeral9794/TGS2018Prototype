using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	// Unity Editor設定値
	[SerializeField]
	private Slider hpSlider;
	[SerializeField]
	private Text gameOverText;
	[SerializeField, Range(1, 100)]
	private int damage = 10;
	[SerializeField]
	private float duration = 2.0f;

	// 内部変数
	private int hp;
	private GameObject hit;
	private float timeDuration;

	// Use this for initialization
	void Start () {
		hp = 100;
		hpSlider.value = hp;
		gameOverText.enabled = false;
		hit = transform.Find("Hit").gameObject;
		hit.GetComponent<BoxCollider2D>().enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (hit.GetComponent<BoxCollider2D>().enabled == false) {
				hit.GetComponent<BoxCollider2D>().enabled = true;
				timeDuration = 0.0f;
			}
		}
		if (hit.GetComponent<BoxCollider2D>().enabled == true) {
			if (timeDuration >= duration) {
				hit.GetComponent<BoxCollider2D>().enabled = false;
			}
		}

		timeDuration += Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "ThrowObject") {
			hp -= damage;
			hpSlider.value = hp;
			Destroy(collider.gameObject);
			if (hp <= 0) {
				gameOverText.enabled = true;
			}
		}
	}
}
