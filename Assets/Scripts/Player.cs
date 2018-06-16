using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	// Unity Editor設定値
	[SerializeField]
	protected Slider hpSlider;

	// 内部変数
	protected int hp;

	// Use this for initialization
	void Start () {
		hp = 100;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
