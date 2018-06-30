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

	// プロパティ
	public int HP {
		get { return hp; }
		set { hp = value > 100 ? 100 : value < 0 ? 0 : value; hpSlider.value = hp; }
	}
	public int Damage {
		get { return damage; }
		//set { damage = value > 100 ? 100 : value < 1 ? 1 : value; }
	}
	public Text GameOverText {
		get { return gameOverText; }
		//set { gameOverText = value; }
	}

	// Use this for initialization
	void Start () {
		hp = 100;
		hpSlider.value = hp;
		gameOverText.enabled = false;
		hit = transform.Find("Hit").gameObject;
		//hit.GetComponent<BoxCollider2D>().enabled = false;
		//hit.GetComponent<Image>().enabled = false;
		hit.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		if (Enemy.Enabled) {
			if (Input.GetMouseButtonDown (0)) {
				if (hit.activeSelf == false) {
					//hit.GetComponent<BoxCollider2D>().enabled = true;
					//hit.GetComponent<Image>().enabled = true;
					hit.SetActive(true);
					hit.GetComponent<Animator>().Play("Effect",0,0.0f);
					timeDuration = 0.0f;
				}
			}
		}
		if (hit.GetComponent<BoxCollider2D>().enabled == true) {
			if (timeDuration >= duration) {
				//hit.GetComponent<BoxCollider2D>().enabled = false;
				//hit.GetComponent<Image>().enabled = true;
				hit.SetActive(false);
			}
		}

		timeDuration += Time.deltaTime;
	}

	/*void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "ThrowObject") {
			Debug.Log(collider.gameObject.name);
			hp -= damage;
			hpSlider.value = hp;
			Destroy(collider.gameObject);
			if (hp <= 0) {
				gameOverText.enabled = true;
			}
		}
	}*/
}
