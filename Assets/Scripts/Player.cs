using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	// static
	public static bool Enabled { get; set; }

	// Unity Editor設定値
	[SerializeField]
	private Slider hpSlider;
	[SerializeField]
	private Text gameOverText;
	[SerializeField]
	private Text SpeedText;
	[SerializeField]
	private Text TimeText;
	//[SerializeField, Range(1, 100)]
	//private int damage = 10;
	[SerializeField]
	private float duration = 2.0f;

	// 内部変数
	private int hp;
	private GameObject hit;
	private float timeDuration;
	private int speed;
	private float timeElapsed;

	// プロパティ
	public int HP {
		get { return hp; }
		set { hp = value > 100 ? 100 : value < 0 ? 0 : value; hpSlider.value = hp; }
	}
	/*public int Damage {
		get { return damage; }
		//set { damage = value > 100 ? 100 : value < 1 ? 1 : value; }
	}*/
	public Text GameOverText {
		get { return gameOverText; }
		//set { gameOverText = value; }
	}
	public int Speed {
		get { return speed; }
		set {
			speed = value < 0 ? 0 : value;
			SpeedText.text = string.Format("{0}km/h", speed);
		}
	}
	public float TimeElapsed {
		get { return timeElapsed; }
		set {
			timeElapsed = value;
			int minite = (int)Math.Floor(timeElapsed / 60.0f);
			TimeText.text = string.Format("{0:#0}:{1:00.##}", minite, timeElapsed);
		}
	}
	public GameObject HitAttack {
		get { return hit; }
	}

	// Use this for initialization
	void Start () {
		Enabled = true;
		hp = 100;
		hpSlider.value = hp;
		speed = 0;
		SpeedText.text = string.Format("{0}km/h", speed);
		timeElapsed = 0.0f;
		TimeText.text = string.Format("{0:0.##}", timeElapsed);
		gameOverText.enabled = false;
		hit = transform.Find("Hit").gameObject;
		//hit.GetComponent<BoxCollider2D>().enabled = false;
		//hit.GetComponent<Image>().enabled = false;
		hit.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		if (Enabled) {
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
		if (hit.activeSelf == true) {
			if (timeDuration >= duration) {
				//hit.GetComponent<BoxCollider2D>().enabled = false;
				//hit.GetComponent<Image>().enabled = true;
				hit.SetActive(false);
			}
		}

		if (Enabled)
			TimeElapsed += Time.deltaTime;

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
