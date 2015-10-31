using UnityEngine;
using System.Collections;

public class OnibusAI : MonoBehaviour {

	
	bool dye;
	string moveState;	
	int rotation;
	int goYellow;
	private int stressLvl;
	private string stateDirection;
	private string nextDirection;
	public SpriteRenderer sprite;
	public GameObject myCollider;
	public string[] myRote;
	
	void Start()
	{
		myCollider.GetComponent<BusChangerController> ().dye = false;
		myCollider.GetComponent<BusChangerController> ().stressLvl = Random.Range (0, 31);
		myCollider.GetComponent<BusChangerController> ().nextDirection = "";
		myCollider.GetComponent<BusChangerController> ().moveState = "Go";
		myCollider.GetComponent<BusChangerController> ().rotation = int.Parse (Mathf.Floor(transform.localEulerAngles.z).ToString());
		myCollider.GetComponent<BusChangerController> ().myRote = myRote;
		switch (rotation) 
		{
		case 0:
			stateDirection = "Right";
			break;
		case 90:
			stateDirection = "Up";
			break;
		case 180:
			stateDirection = "Left";
			break;
		case 270:
			stateDirection = "Down";
			break;
			
		}
	}
	IEnumerator Explode()
	{
		myCollider.GetComponent<BusChangerController> ().explode = false;
		yield return new WaitForSeconds(0.4f);
		sprite.enabled = false;
		yield return new WaitForSeconds(0.4f);
		sprite.enabled = true;
		yield return new WaitForSeconds(0.4f);
		Destroy (this.gameObject);
	}
	IEnumerator ToNull()
	{
		myCollider.GetComponent<BusChangerController> ().toNull = false;
		yield return new WaitForSeconds(0.5f);
		myCollider.GetComponent<BusChangerController> ().nextDirection = "";
	}
	IEnumerator Slow()
	{
		myCollider.GetComponent<BusChangerController> ().slow = false;
		yield return new WaitForSeconds(0.3f);
		myCollider.GetComponent<BusChangerController> ().moveState = "Go";
	}
	void Move()
	{
		if(moveState.Equals("Go"))
		{
			transform.Translate(Vector3.right * 4);
		}
		else if (moveState.Equals("DontGo"))
		{
			transform.Translate(new Vector3(0,0,0));
		}
		else
			transform.Translate(Vector3.right * 7);
		
	}
	void StateRotation()
	{
		rotation = int.Parse (Mathf.Floor(transform.localEulerAngles.z).ToString());
		switch (rotation) 
		{
		case 0:
			stateDirection = "Right";
			break;
		case 90:
			stateDirection = "Up";
			break;
		case 180:
			stateDirection = "Left";
			break;
		case 270:
			stateDirection = "Down";
			break;
		}
		if (nextDirection != null && stateDirection != nextDirection)
		{
			if(nextDirection.Equals("Up"))
			{
				if(stateDirection.Equals("Right") && rotation < 90)
				{
					transform.Rotate(new Vector3(0,0,3.7f));
					if(transform.localEulerAngles.z >= 90)
						transform.eulerAngles = new Vector3(0,0,90);
				}
				else if(stateDirection.Equals("Left") && rotation > 90)
				{
					transform.Rotate(new Vector3(0,0,-3.7f));
					if(transform.localEulerAngles.z <= 90)
						transform.eulerAngles = new Vector3(0,0,90);
				}
			}
			else if(nextDirection.Equals("Right"))
			{
				if(stateDirection.Equals("Up") && rotation > 0)
				{
					transform.Rotate(new Vector3(0,0,-4));
					if(transform.localEulerAngles.z > 180)
						transform.eulerAngles = new Vector3(0,0,0);
				}
			}
			else if(nextDirection.Equals("Left"))
			{
				if(stateDirection.Equals("Up") && rotation < 180)
				{
					transform.Rotate(new Vector3(0,0,4));
					if(transform.localEulerAngles.z > 180)
						transform.eulerAngles = new Vector3(0,0,180);
				}
			}
			
		}
		
	}
	void getMyCollider()
	{
		moveState = myCollider.GetComponent<BusChangerController> ().moveState; 
		dye = myCollider.GetComponent<BusChangerController> ().dye;		
		rotation = myCollider.GetComponent<BusChangerController> ().rotation;
		goYellow = myCollider.GetComponent<BusChangerController> ().goYellow;
		stressLvl = myCollider.GetComponent<BusChangerController> ().stressLvl;
		nextDirection = myCollider.GetComponent<BusChangerController> ().nextDirection;
		if (myCollider.GetComponent<BusChangerController> ().toNull)
			StartCoroutine (ToNull ());
		if (myCollider.GetComponent<BusChangerController> ().slow)
			StartCoroutine (Slow ());
		if (myCollider.GetComponent<BusChangerController> ().explode)
			StartCoroutine (Explode ());
	}
	void FixedUpdate () 
	{
		try
		{
			myCollider.GetComponent<BusChangerController> ().collidingCar = false;
			getMyCollider ();
		}
		catch
		{
			Destroy (this.gameObject);
		}
		if(!dye)
		{
			StateRotation();
			Move();
		}
		
	}
	void Update ()
	{
		if (myCollider.Equals (null))
			Destroy (this.gameObject);
	}
	void LateUpdate()
	{
		if (!myCollider.GetComponent<BusChangerController> ().collidingCar && !myCollider.GetComponent<BusChangerController> ().collidingLight)
			myCollider.GetComponent<BusChangerController> ().moveState = "Go";
	}
}
