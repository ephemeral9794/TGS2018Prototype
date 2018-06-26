using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField]
	private GameObject throwObj;
	[SerializeField]
<<<<<<< HEAD
	private GameObject player;
    [SerializeField, Range(0.0f, 10.0f)]
    private float power = 3.0f;
    [SerializeField, Range(0.0f, 45.0f)]
    private float rotation = 20.0f;
    [SerializeField, Range(0.1f, 10.0f)]
    private float interval = 3.0f;
    [SerializeField]
    private int num = 0;

	// Use this for initialization
	void Start () {
		if (throwObj != null) {
			StartCoroutine(GenerateObject());
		}
=======
	private Player player;

	// Use this for initialization
	void Start () {
		
>>>>>>> parent of 08610f1... add data
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
		
	}

    IEnumerator GenerateObject() {
        for (int i = 0; i < num; i++) {
            GameObject obj = Instantiate(throwObj, new Vector3(transform.position.x, transform.position.y), Quaternion.identity) as GameObject;
            var rigidbody = obj.GetComponent<Rigidbody2D>();
            var vector = Quaternion.Euler(0, 0, rotation) * obj.transform.up.normalized;
            rigidbody.AddForce(vector * power, ForceMode2D.Impulse);
            yield return new WaitForSeconds(interval);
        }
    }
=======
		if (throwObj != null) {
			Instantiate(throwObj);

		}
	}
>>>>>>> parent of 08610f1... add data
}
