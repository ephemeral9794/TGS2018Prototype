using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	// Unity Editor設定値
	[SerializeField]
	protected Slider hpSlider;
    [SerializeField]
    protected GameObject gameOverText;

	// 内部変数
	protected int hp;

	// Use this for initialization
	void Start () {
		hp = 100;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ThrowObject")
        {
            hp -= 10;
            hpSlider.value = hp;
            Debug.Log(hp);
            if (hp == 0) {
                // Game Over
                gameOverText.SetActive(true);
            }
        }
    }
}
