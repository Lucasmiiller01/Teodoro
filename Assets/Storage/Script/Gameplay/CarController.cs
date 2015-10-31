using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

	bool dye;
	string moveState;	
	int rotation;
	int goYellow;
	private int stressLvl;
	private string stateDirection;
	private string nextDirection;
    public SpriteRenderer sprite;
	public GameObject myCollider;

    void Start()
	{
		myCollider.GetComponent<ColliderCarController> ().dye = false;
		myCollider.GetComponent<ColliderCarController> ().stressLvl = Random.Range (0, 31);
		myCollider.GetComponent<ColliderCarController> ().nextDirection = "";
        sprite.color = new Color(0, 0, 0);
        sprite.color = new Color(Random.Range(0, 255) / 100, Random.Range(0, 255) / 100, Random.Range(0, 255) / 100);
		myCollider.GetComponent<ColliderCarController> ().moveState = "Go";
		myCollider.GetComponent<ColliderCarController> ().rotation = int.Parse (Mathf.Floor(transform.localEulerAngles.z).ToString());
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
		myCollider.GetComponent<ColliderCarController> ().explode = false;
		yield return new WaitForSeconds(0.4f);
		sprite.enabled = false;
		yield return new WaitForSeconds(0.4f);
		sprite.enabled = true;
		yield return new WaitForSeconds(0.4f);
		Destroy (this.gameObject);
	}
	IEnumerator ToNull()
	{
		myCollider.GetComponent<ColliderCarController> ().toNull = false;
		yield return new WaitForSeconds(0.5f);
		myCollider.GetComponent<ColliderCarController> ().nextDirection = "";
	}
    IEnumerator Slow()
	{
		myCollider.GetComponent<ColliderCarController> ().slow = false;
        yield return new WaitForSeconds(0.3f);
		myCollider.GetComponent<ColliderCarController> ().moveState = "Go";
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
		moveState = myCollider.GetComponent<ColliderCarController> ().moveState; 
		dye = myCollider.GetComponent<ColliderCarController> ().dye;		
		rotation = myCollider.GetComponent<ColliderCarController> ().rotation;
		goYellow = myCollider.GetComponent<ColliderCarController> ().goYellow;
		stressLvl = myCollider.GetComponent<ColliderCarController> ().stressLvl;
		nextDirection = myCollider.GetComponent<ColliderCarController> ().nextDirection;
		if (myCollider.GetComponent<ColliderCarController> ().toNull)
			StartCoroutine (ToNull ());
		if (myCollider.GetComponent<ColliderCarController> ().slow)
			StartCoroutine (Slow ());
		if (myCollider.GetComponent<ColliderCarController> ().explode)
			StartCoroutine (Explode ());
	}
	void FixedUpdate () 
	{
		try
		{
			myCollider.GetComponent<ColliderCarController> ().collidingCar = false;
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
		if (!myCollider.GetComponent<ColliderCarController> ().collidingCar && !myCollider.GetComponent<ColliderCarController> ().collidingLight)
			myCollider.GetComponent<ColliderCarController> ().moveState = "Go";
	}
}
