using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TapStart : MonoBehaviour {
	private float timeDuration;
	private float duration;
	private float timeElapsed;

	// Use this for initialization
	void Start () {
		timeDuration = 0.0f;
		duration = 0.5f;
		timeElapsed = 0.0f;
	}

	// Update is called once per frame
	void Update () {
		if (timeDuration >= 0.5f) {
			timeDuration = 0.0f;
			GetComponent<Text>().enabled = !GetComponent<Text>().enabled;
		}
		if (Input.GetMouseButtonDown(0)) {
			SceneManager.LoadScene(1);
		}
		timeDuration += Time.deltaTime;
	}
}
