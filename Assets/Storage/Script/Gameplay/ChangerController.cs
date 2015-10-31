using UnityEngine;
using System.Collections;

public class ChangerController : MonoBehaviour {
    
    public string direction;

	void Start () {
        if(direction.Equals("Up") || direction.Equals("Down") || direction.Equals("Left") || direction.Equals("Right"))
            gameObject.tag = direction;
	}
}
