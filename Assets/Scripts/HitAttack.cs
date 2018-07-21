using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAttack : MonoBehaviour {
	private Animator animator;
	public ThrowObject obj;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		animator.Play("Effect", 0, 0.0f);
	}

	// Update is called once per frame
	void Update () {
		if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) {
			obj.OnDestroyHitAnimation();
			Destroy(gameObject);
		}
	}
}
