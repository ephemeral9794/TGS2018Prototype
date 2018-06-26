using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public enum ObjectType {
		Banana,
		Strawberry,
		Money,
		Rock,
		Table,
	}
	[SerializeField]
	private ObjectType type;
	[SerializeField]
	private GameObject player;
<<<<<<< HEAD
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
	[SerializeField, Range(1.0f, 10.0f)]
	private float power = 3.0f;
	[SerializeField, Range(-45.0f, 45.0f)]
	private float angle = 20.0f;
	[SerializeField, Range(1.0f, 10.0f)]
	private float wait = 3.0f;
	[SerializeField]
	private int count = 5;

	private GameObject throwObj;
	private float timeElapsed;
	private int n;

	// Use this for initialization
	void Start () {
			switch (type) {
				case ObjectType.Banana:
					throwObj = Resources.Load("Prefabs/fruit_banana") as GameObject;
					break;
				case ObjectType.Strawberry:
					throwObj = Resources.Load("Prefabs/fruit_strawberry") as GameObject;
					break;
				case ObjectType.Money:
					throwObj = Resources.Load("Prefabs/money_koban") as GameObject;
					break;
				case ObjectType.Rock:
					throwObj = Resources.Load("Prefabs/rock") as GameObject;
					break;
				case ObjectType.Table:
					throwObj = Resources.Load("Prefabs/table_chabudai") as GameObject;
					break;
			}
			timeElapsed = 0.0f;
			n = 0;
			//StartCoroutine(GenerateObject());
>>>>>>> 08610f13567cb286721f12c6b5c606653e0aec61
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
		if (timeElapsed >= wait) {
			if (n < count) {
				GameObject obj = Instantiate(throwObj, transform.position, Quaternion.identity, transform) as GameObject;
				Rigidbody2D rigidbody = obj.GetComponent<Rigidbody2D>();
				Vector2 launchVector = Quaternion.Euler(0, 0, angle) * transform.up.normalized;
				//Debug.Log($"{launchVector}, {transform.up.normalized}");
	      rigidbody.AddForce(launchVector * power, ForceMode2D.Impulse);
			}
			timeElapsed = 0.0f;
		}

		timeElapsed += Time.deltaTime;
	}

	/*IEnumerator GenerateObject() {
		for (int i = 0; i < count; i++) {
			GameObject obj = Instantiate(throwObj, transform.position, Quaternion.identity, transform) as GameObject;
			Rigidbody2D rigidbody = obj.GetComponent<Rigidbody2D>();
			Vector2 launchVector = Quaternion.Euler(0, 0, angle) * transform.up.normalized;
			//Debug.Log($"{launchVector}, {transform.up.normalized}");
      rigidbody.AddForce(launchVector * power, ForceMode2D.Impulse);
			yield return new WaitForSeconds(wait);
		}
	}*/
>>>>>>> 08610f13567cb286721f12c6b5c606653e0aec61
}
