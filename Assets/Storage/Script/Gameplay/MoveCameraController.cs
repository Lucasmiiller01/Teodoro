using UnityEngine;
using System.Collections;

public class MoveCameraController : MonoBehaviour {

	private GameObject teodoro;

	void Start()
	{
		teodoro = GameObject.Find ("Teodoro");
	}
	void FixedUpdate()
	{
		rigidbody2D.velocity = teodoro.rigidbody2D.velocity;
	}
}
