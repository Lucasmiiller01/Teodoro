using UnityEngine;
using System.Collections;

public class ColliderCarController : MonoBehaviour {

	public bool collidingCar;
	public bool collidingLight;
	public bool dye;
	public string moveState;		
	public int rotation;
	public int goYellow;
	public int stressLvl;
	public string nextDirection;
	public bool toNull;
	public bool slow;
	public bool explode;


	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag.Equals("Car"))
		{
			moveState = "DontGo";
			collidingCar = true;
		}
		if (col.tag.Equals("CarChanger") && nextDirection.Equals(""))
		{
			nextDirection = col.gameObject.GetComponent<CarChangerController>().directions[Random.Range(0,col.gameObject.GetComponent<CarChangerController>().directions.Length)];
			toNull = true;
		}
		if (col.tag.Equals ("Light")) 
		{
			goYellow = Random.Range(0, stressLvl);
		}
		if (col.tag.Equals("Light") || col.tag.Equals("LightVertical") || col.tag.Equals("LightHorizontal"))
		{
			if (col.GetComponent<SpriteRenderer>().color.Equals(new Color(255, 0, 0)))
			{
				moveState = "DontGo";
				collidingLight = true;
			}
			else if (col.GetComponent<SpriteRenderer>().color.Equals(new Color(255, 255, 0)))
			{
				if(goYellow.Equals(0))
				{
					moveState = "RUN";
					collidingLight = false;
					slow = true;
				}
				else 
				{
					moveState = "DontGo";
					collidingLight = true;
				}
			}
		}
		
	}
	
	
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag.Equals("Light") || col.tag.Equals("LightVertical") || col.tag.Equals("LightHorizontal"))
		{
			
			if (col.GetComponent<SpriteRenderer>().color.Equals(new Color(0, 255, 0)))
			{
				moveState = "Go";
				collidingLight = false;
			}
			

		}
		if (col.tag.Equals("Car"))
		{
			collidingCar = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag.Equals("Car"))
		{
			moveState = "Go";
		}
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag.Equals("Car"))
		{
			dye = true;
			explode = true;
		}
	}

}
