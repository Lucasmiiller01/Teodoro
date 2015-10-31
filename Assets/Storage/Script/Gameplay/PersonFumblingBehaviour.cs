using UnityEngine;
using System.Collections;

public class PersonFumblingBehaviour : PersonPrefab
{
	public Animator animator;
	public GameObject exclamation;
	private GameObject teodoro;
	private bool fumbling;
	public  bool comeToMe;
    void Start()
    {
		teodoro = GameObject.Find("Teodoro");
		speed = 4000;
        moveState = "Go";
		StartCoroutine(Stop());
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Finish"))
        {
            GameController.donePeople += 1;
        }
    }
	void InDistance()
	{
		exclamation.SetActive(false);
		if (transform.position.y > teodoro.transform.position.y + 70|| 
		    transform.position.y < teodoro.transform.position.y - 70 ||fumbling == true)
		{
			exclamation.SetActive(true);
		}
		if( transform.position.x > teodoro.transform.position.x + 70 || 
		   transform.position.x < teodoro.transform.position.x - 70 || fumbling == true)
		{
			exclamation.SetActive(true);
		}
	}

    public IEnumerator Stop()
    {
		yield return new WaitForSeconds(Random.Range(9,14));
		speed = 0;
    }
	void OnMouseDown()
	{
		if (exclamation.activeSelf)
		{
			comeToMe = true;
			teodoro.transform.Rotate(new Vector3(0,0,180));
		}
	}
    void FixedUpdate()
    {
		if (speed == 0) {
			fumbling = true;
			animator.enabled = false;
		}
		else {
			this.rigidbody2D.velocity = new Vector2(teodoro.rigidbody2D.velocity.x, teodoro.rigidbody2D.velocity.y);
			fumbling = false;
			animator.enabled = true;
		}
		Move();
		InDistance ();
    }
   
    
}
