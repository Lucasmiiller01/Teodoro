using UnityEngine;
using System.Collections;

public class PersonAngryBehaviour : PersonPrefab
{
	private GameObject teodoro;
	public GameObject exclamation;
	private GameObject personFumbling;
	public Animator animator;
	void Start()
	{
		personFumbling = GameObject.Find("Fumbling");
		teodoro = GameObject.Find("Teodoro");
        moveState = "Go";
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

		/*if (transform.position.y > teodoro.transform.position.y + 70|| 
		    transform.position.y < teodoro.transform.position.y - 70 && speed != 0)
		{
			exclamation.SetActive(true);
		}*/
		if( transform.position.x > teodoro.transform.position.x + 70 && speed != 0)
		{
			exclamation.SetActive(true);
		}
		if (!exclamation.activeSelf && speed < 3000 && transform.position.y < teodoro.transform.position.y + 30&& 
		    transform.position.y > teodoro.transform.position.y - 30 && transform.position.x < teodoro.transform.position.x + 30 && 
		    transform.position.x > teodoro.transform.position.x - 30)
		{
			speed = 4000;
			StartCoroutine(Run ());
		}
		if (personFumbling.GetComponent<PersonFumblingBehaviour> ().comeToMe && speed < 5000)
		{
			exclamation.SetActive(false);
			speed = 0;
		}
	}

	IEnumerator Run()
	{
		yield return new WaitForSeconds(Random.Range(6,9));
		if(!personFumbling.GetComponent<PersonFumblingBehaviour>().comeToMe)
			speed = 7000;
	}
   	void OnMouseDown()
	{
		if (exclamation.activeSelf){
			speed = 0;
		}
			
	}
    void FixedUpdate()
    {
		if(speed == 0)animator.enabled = false;
		else animator.enabled = true;
			
		Move();
		InDistance ();
    }
    
}