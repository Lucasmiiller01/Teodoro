using UnityEngine;
using System.Collections;

public class PersonBasicBehaviour : PersonPrefab {
    
	private GameObject personFumbling;
	public string toBack = "";
	bool entrei = false;

	void Start()
	{
		personFumbling = GameObject.Find("Fumbling");
        speed = 4000;
        moveState = "Go";
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Finish"))
        {
            GameController.donePeople += 1;
        }
    
    }    
	void Back()
	{
		print(toBack + "oi");
		if (toBack.Equals ("") && !entrei && iKnow == "acabou")
		{
			toBack = "Chegando";
			entrei = true;

		}
		if (toBack.Equals ("Chegando")) {
			if (transform.position.x < whereRhe.transform.position.x + whereRhe.renderer.bounds.size.x * 2) {
				transform.eulerAngles = new Vector3 (0, 0, 180);
				toBack = "Chegou";
			}
		} else if (toBack.Equals ("Chegou")) {
			if (transform.position.y < whereRhe.transform.position.y - whereRhe.renderer.bounds.size.y * 2) {
				transform.eulerAngles = new Vector3 (0, 0, 90);
				toBack = "Quase";
			}
		} else if (toBack.Equals ("Quase")) {
			if (transform.position.x < whereRhe.transform.position.x - whereRhe.renderer.bounds.size.x * 2) {
				transform.eulerAngles = new Vector3 (0, 0, 0);
				toBack = "Acabou";
			}
		} else if (toBack.Equals ("Acabou")) {
			if (transform.position.y < whereRhe.transform.position.y) {
				transform.eulerAngles = new Vector3 (0, 0, 90);
				toBack = "";
			}
		}
	}
    void FixedUpdate()
    {       
		if(personFumbling.GetComponent<PersonFumblingBehaviour> ().comeToMe && whereRhe != null)
		{
			if (personFumbling.transform.position.x < whereRhe.transform.position.x + whereRhe.renderer.bounds.size.x * 2 && !entrei) 
				Back();
		}
		
		Move();
		if (personFumbling.GetComponent<PersonFumblingBehaviour> ().comeToMe && 
		    personFumbling.transform.position.x >= transform.position.x - 20 && 
		    personFumbling.transform.position.y <= transform.position.x - 20 &&
		    speed != 0 ||
		    personFumbling.GetComponent<PersonFumblingBehaviour> ().comeToMe && 
		    personFumbling.transform.position.x >= transform.position.x - 20 && 
		    personFumbling.transform.position.y >= transform.position.x + 20 &&
		    speed != 0)
			{
				speed = 0;
				StartCoroutine (TalkToHer());
			}
    }
	IEnumerator TalkToHer()
	{
		yield return new WaitForSeconds(Random.Range(1,2));
		personFumbling.GetComponent<PersonFumblingBehaviour> ().comeToMe = false;
		personFumbling.GetComponent<PersonFumblingBehaviour> ().speed = 4000;
		StartCoroutine (personFumbling.GetComponent<PersonFumblingBehaviour> ().Stop ());
		transform.Rotate(new Vector3(0,0,180));
		speed = 4000;
	}

}

public class PersonPrefab : MonoBehaviour
{
    public string moveState;
    public Animator animationPlayer;
    public int speed;
	protected string iKnow = "";
	protected GameObject whereRhe;

    public void Move()
	{

		if (moveState.Equals("Go"))
        {
            rigidbody2D.velocity = (transform.up * speed * Time.deltaTime);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0, 0);
        }
		if (whereRhe != null) {
			if (iKnow.Equals ("Chegando")) {
				if (transform.position.x > whereRhe.transform.position.x - whereRhe.renderer.bounds.size.x * 2) {
					transform.eulerAngles = new Vector3 (0, 0, 180);
					iKnow = "Chegou";
				}
			} else if (iKnow.Equals ("Chegou")) {
				if (transform.position.y < whereRhe.transform.position.y - whereRhe.renderer.bounds.size.y * 2) {
					transform.eulerAngles = new Vector3 (0, 0, 270);
					iKnow = "Quase";
				}
			} else if (iKnow.Equals ("Quase")) {
				if (transform.position.x > whereRhe.transform.position.x + whereRhe.renderer.bounds.size.x * 2) {
					transform.eulerAngles = new Vector3 (0, 0, 0);
					iKnow = "Acabou";
				}
			} else if (iKnow.Equals ("Acabou")) {
				if (transform.position.y > whereRhe.transform.position.y) {
					transform.eulerAngles = new Vector3 (0, 0, 270);
					iKnow = "";
				}
			}
		}


	}

	void Update()
	{
		if (Mathf.Floor(transform.eulerAngles.z).Equals(0))
		{
			animationPlayer.SetInteger("Direction",0);
		}
		else if (Mathf.Floor(transform.eulerAngles.z).Equals(180))
		{
			animationPlayer.SetInteger("Direction",1);
		}
		else if (Mathf.Floor(transform.eulerAngles.z).Equals(90))
		{
			animationPlayer.SetInteger("Direction",3);
		}
		else if (Mathf.Floor(transform.eulerAngles.z).Equals(270))
		{
			animationPlayer.SetInteger("Direction",2);
		}
	}
	public void Escape(GameObject obstaclePosition)
	{
		iKnow = "Chegando";
		whereRhe = obstaclePosition;
	}
	void OnTriggerStay2D(Collider2D col)
	{
		
		if (col.tag.Equals ("PlayerTrigger")) {
			moveState = col.GetComponent<TriggerGetMove> ().moveState;
		}
		if (col.tag.Equals("Light"))
		{
			if (col.GetComponent<SpriteRenderer>().color.Equals(new Color(255, 0, 0)))
				moveState = "Go";
			
			else
				moveState = "DontGo";
		}
		if (col.tag.Equals("Up"))
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
		}
		else if (col.tag.Equals("Down"))
		{
			transform.eulerAngles = new Vector3(0, 0, 180);
		}
		else if (col.tag.Equals("Left"))
		{
			transform.eulerAngles = new Vector3(0, 0, 90);
		}
		else if (col.tag.Equals("Right"))
		{
			transform.eulerAngles = new Vector3(0, 0, 270);
		}
		
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag.Equals("Player"))
			moveState = "Go";
		if (col.tag.Equals("PlayerTrigger"))
			moveState = col.GetComponent<TriggerGetMove>().moveState;
	}
}