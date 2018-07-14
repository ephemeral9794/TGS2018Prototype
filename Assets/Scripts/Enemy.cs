using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	//public static bool Enabled { get; set; }
	private static readonly int[] incidence = new [] {
		18, 18, 18, 18, 18, 10
	};

	//[SerializeField]
	//private ObjectType type;
	[SerializeField]
	private GameObject player;
	[SerializeField, Range(1.0f, 10.0f)]
	private float power = 3.0f;
	[SerializeField, Range(-45.0f, 45.0f)]
	private float angle = 20.0f;
	[SerializeField, Range(1.0f, 10.0f)]
	private float wait = 3.0f;
	//[SerializeField]
	//private int count = 5;

	private GameObject throwObj;
	private List<GameObject> throwObjects;
	private float timeElapsed;
	private List<int> incidenceList;
	private float wait_real;
	private float shake_width;
	//private int n;

	// Use this for initialization
	void Start () {
		//Enabled = true;
		/*switch (type) {
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
		}*/
		throwObjects = new List<GameObject>();
		throwObjects.Add(Resources.Load("Prefabs/drink_taru") as GameObject);
		throwObjects.Add(Resources.Load("Prefabs/fruit_banana") as GameObject);
		throwObjects.Add(Resources.Load("Prefabs/rock") as GameObject);
		throwObjects.Add(Resources.Load("Prefabs/table_chabudai") as GameObject);
		throwObjects.Add(Resources.Load("Prefabs/fruit_strawberry") as GameObject);
		throwObjects.Add(Resources.Load("Prefabs/money_koban") as GameObject);
		incidenceList = Incidence.GetIncidenceDistributionList(incidence);
		//Debug.Log(incidenceList);
		timeElapsed = 0.0f;
		wait_real = wait;
		shake_width = 1.0f;
		//n = 0;
		//StartCoroutine(GenerateObject());
	}

	// Update is called once per frame
	void Update () {
		if (Player.Enabled) {
			if (timeElapsed >= wait_real) {
				int n = Random.Range(0, incidenceList.Count);
				var throwObj = throwObjects[incidenceList[n]];
				GameObject obj = Instantiate(throwObj, transform.position, Quaternion.identity, transform) as GameObject;
				Rigidbody2D rigidbody = obj.GetComponent<Rigidbody2D>();
				Vector2 launchVector = Quaternion.Euler(0, 0, angle) * transform.up.normalized;
				//Debug.Log($"{launchVector}, {transform.up.normalized}");
	      rigidbody.AddForce(launchVector * power, ForceMode2D.Impulse);
				obj.GetComponent<ThrowObject>().Player = player.GetComponent<Player>();
				timeElapsed = 0.0f;
				wait_real = wait + Random.Range(-shake_width, shake_width);
			}
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
}
