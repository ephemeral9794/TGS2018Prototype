using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	// static
	public static bool Enabled { get; set; }

	// Unity Editor設定値
	[SerializeField]
	private Slider hpSlider;
	[SerializeField]
	private Text hpText;
	[SerializeField]
	private Text gameOverText;
	[SerializeField]
	private Text gameClearText;
	[SerializeField]
	private Text SpeedText;
	[SerializeField]
	private Text TimeText;
	[SerializeField]
	private Slider distanceSlider;
	/*[SerializeField]
	private Animator hitAnimator;*/
	//[SerializeField, Range(1, 100)]
	//private int damage = 10;
	[SerializeField]
	private float duration = 2.0f;
	[SerializeField]
	private float goalDistance = 10.0f;
	[SerializeField]
	private int hpMax = 100;

	// 内部変数
	private int hp;
	//private GameObject hit;
	private float timeDuration;
	private int speed;
	private float timeElapsed;
	private float distance;
	private float goal;

	// プロパティ
	public int HP {
		get { return hp; }
		set {
			hp = (value > hpMax) ? hpMax : (value < 0) ? 0 : value;
			hpSlider.value = hp;
			hpText.text = string.Format("{0:##0}/{1}", hp, hpMax);
		}
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
			TimeText.text = string.Format("{0:#0}:{1:00.00}", minite, timeElapsed);
		}
	}
	public float Distance {
		get { return distance; }
		set {
			distance = (value >= goal) ? goal : value;
			distanceSlider.value = (distance / goal);
		}
	}
	/*public GameObject HitAttack {
		get { return hit; }
	}*/

	// Use this for initialization
	void Start () {
		Enabled = true;
		hp = hpMax;
		hpSlider.value = hp;
		speed = 0;
		SpeedText.text = string.Format("{0}km/h", speed);
		timeElapsed = 0.0f;
		TimeText.text = string.Format("{0:0.##}", timeElapsed);
		gameOverText.enabled = false;
		gameClearText.enabled = false;
		distance = 0.0f;
		distanceSlider.value = 0.0f;
		goal = goalDistance;// * 3600.0f * Time.deltaTime;
		//hit = transform.Find("Hit").gameObject;
		//hit.GetComponent<BoxCollider2D>().enabled = false;
		//hit.GetComponent<Image>().enabled = false;
		//hit.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		/*if (Enabled) {
			if (Input.GetMouseButtonDown (0)) {
				if (hit.activeSelf == false) {
					//hit.GetComponent<BoxCollider2D>().enabled = true;
					//hit.GetComponent<Image>().enabled = true;
					hit.SetActive(true);
					//hit.GetComponent<Animator>().Play("Effect",0,0.0f);
					hitAnimator.Play("Effect", 0, 0.0f);
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
		}*/
		if (Enabled) {
			float ps = Speed / 3600.0f;// 秒速
			float fps = 1.0f / Time.deltaTime; // fps
			float pf = ps / fps; // フレーム速
			//Debug.Log("speed     : " + speed);
			//Debug.Log("per frame : " + pf);
			//Debug.Log("distance  : " + Distance);
			Distance += pf;
			if (Distance >= goal) {
				gameClearText.enabled = true;
				Enabled = false;
			}
		}

		if (Enabled)
			TimeElapsed += Time.deltaTime;

		if (!Enabled) {
			if (Input.GetMouseButtonDown(0)) 
				SceneManager.LoadScene(0);
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
