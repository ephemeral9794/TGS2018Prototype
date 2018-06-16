using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField]
	private GameObject throwObj;
	[SerializeField]
	private Player player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (throwObj != null) {
			Instantiate(throwObj);

		}
	}
}
