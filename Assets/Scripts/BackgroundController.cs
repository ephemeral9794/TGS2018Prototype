using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
	[SerializeField, Range(-1.0f, 0.0f)]
	private float speed = -0.1f;
	[SerializeField]
	private Player player;

	// Update is called once per frame
	void Update () {
		if (Player.Enabled) {
			float sp = (player.Speed / 60.0f) * speed;
			/*transform.Translate(0.0f, sp, 0);
			if( transform.position.y < -10.3f ) {
				transform.position = new Vector3(0.0f, 10.3f, 90.3f);
			}*/
			float scroll = Mathf.Repeat (Time.time * 0.2f, 1);
			Vector2 offset = new Vector2 (0, scroll);
			GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", offset);
		}
	}
}
