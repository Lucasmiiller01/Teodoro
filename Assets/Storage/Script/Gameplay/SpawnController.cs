using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	private GameObject[] tipesOfEnemy;
	private GameObject spawnedOfEnemy;

	void Start () {
		tipesOfEnemy = GameObject.FindGameObjectsWithTag ("Enemy");

		for (int i=0; i < tipesOfEnemy.Length; i++)
			tipesOfEnemy [i].SetActive(false);
		StartCoroutine(Spawn());
	}
	

	void FixedUpdate()
	{
		rigidbody2D.velocity = (transform.right * 4000 * Time.deltaTime);
		 
	}
	IEnumerator Spawn() {
		int random = Random.Range (0, tipesOfEnemy.Length - 1);
		yield return new WaitForSeconds(Random.Range(6,10));
		spawnedOfEnemy = Instantiate (tipesOfEnemy [random],this.transform.position,this.transform.rotation) as GameObject;
		spawnedOfEnemy.SetActive(true);
		StartCoroutine(Spawn());
	}
}
