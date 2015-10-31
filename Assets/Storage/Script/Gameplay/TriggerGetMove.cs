using UnityEngine;
using System.Collections;

public class TriggerGetMove : MonoBehaviour {

    public GameObject myPerson;
    public string moveState;
	void LateUpdate () {
		if (myPerson.GetComponent<PersonBasicBehaviour> () != null)
			moveState = myPerson.GetComponent<PersonBasicBehaviour> ().moveState;
		else if(myPerson.GetComponent<PersonAngryBehaviour> () != null)
			moveState = myPerson.GetComponent<PersonAngryBehaviour> ().moveState;
		else if(myPerson.GetComponent<PersonFumblingBehaviour> () != null)
			moveState = myPerson.GetComponent<PersonFumblingBehaviour> ().moveState;
	}
}
