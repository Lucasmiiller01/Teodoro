using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public GameObject exclamation;
	private bool theyKnow;
	private GameObject[] peoples = new GameObject[3];
	void Start () 
	{
		theyKnow = false;
		peoples[0] = GameObject.Find("Teodoro");
		peoples[1] = GameObject.Find("Fumbling");
		peoples[2] = GameObject.Find("Angry");
		exclamation.SetActive(false);
	}
	void OnMouseDown()
	{
		if (!theyKnow) {
			theyKnow = true;
			exclamation.SetActive(false);
			for (int i = 0; i < peoples.Length; i ++) {
				peoples [i].GetComponent<PersonPrefab> ().Escape (this.gameObject);
			}
		}
	}

	void Update () {
		InDistance ();
	}
	void InDistance()
	{
		if (transform.position.x + 200 < peoples [0].transform.position.x)
			Destroy (gameObject);

		if(transform.position.x < peoples[2].transform.position.x + 200 && !theyKnow)
			exclamation.SetActive(true);

	}

}
