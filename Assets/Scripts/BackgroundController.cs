using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
	[SerializeField, Range(-3.0f, 0.0f)]
	private float speed = 0.1f;

	// Update is called once per frame
	void Update () {
		if (Player.Enabled) {
			transform.Translate(-0.0f, speed, 0);
			if( transform.position.y < -10.3f ) {
				transform.position = new Vector3(0.0f, 10.3f, 90.3f);
			}
		}
	}
}
