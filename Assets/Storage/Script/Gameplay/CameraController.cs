using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    BoxCollider2D b;
	void Start () 
    {
        b = gameObject.collider2D as BoxCollider2D;
	}

    void Controller()
    {
        if (Input.GetAxis("Zoom") > 0)
        {
            if (camera.orthographicSize >= 300)
                camera.orthographicSize -= 10;
        }
        else if (Input.GetAxis("Zoom") < 0)
        {
            if (camera.orthographicSize <= 2000)
                camera.orthographicSize += 10;
        }
        if(camera.orthographicSize < 1000)
            rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * 1000 / 4, Input.GetAxis("Vertical") * 1000 / 4);
        else
            rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * 1000, Input.GetAxis("Vertical") * 1000);
        
    }

	void FixedUpdate ()
    {
        Controller();
        b.size = new Vector2(camera.orthographicSize * 3, camera.orthographicSize * 2);
    }
}
