using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	public GameObject car;
	public GameObject bus;
    public int[] time = new int[2];
    public string direction;
	public string[] busRote;
	public bool canBus;
	private GameObject buses;

	void Start () 
    {
		if(canBus) 
		{
			if (direction.Equals("Down"))
				buses = (GameObject) Instantiate(bus, transform.position, Quaternion.Euler(0, 0, 270));
			else if (direction.Equals("Up"))
				buses = (GameObject) Instantiate(bus, transform.position, new Quaternion(0, 0, 270, 270));
			else if (direction.Equals("Left"))
				buses = (GameObject) Instantiate(bus, transform.position, new Quaternion(0, 0, 180, 0));
			else if (direction.Equals("Right"))
				buses = (GameObject) Instantiate(bus, transform.position, new Quaternion(0, 0, 0, 0));
			buses.gameObject.GetComponent<OnibusAI>().myRote = busRote;
		}
        if (time[0].Equals(0) || time[0].Equals(null))
            time[0] = 3;
        if (time[1].Equals(0) || time[1].Equals(null))
            time[1] = 15;
        StartCoroutine(Spawn());
	}
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(time[0], time[1]));
        if (direction.Equals("Down"))
            Instantiate(car, transform.position, Quaternion.Euler(0, 0, 270));
        else if (direction.Equals("Up"))
            Instantiate(car, transform.position, new Quaternion(0, 0, 270, 270));
        else if (direction.Equals("Left"))
            Instantiate(car, transform.position, new Quaternion(0, 0, 180, 0));
        else if (direction.Equals("Right"))
            Instantiate(car, transform.position, new Quaternion(0, 0, 0, 0));
        StartCoroutine(Spawn());
    }
	void Update ()
    {
	
	}
}
