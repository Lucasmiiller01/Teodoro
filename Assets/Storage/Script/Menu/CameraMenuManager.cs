using UnityEngine;
using System.Collections;

public class CameraMenuManager : MonoBehaviour {

    private float speedX;
    private float speedY;

    void Start()
    {
        this.speedX = 50 * Time.deltaTime;
        this.speedY = -50 * Time.deltaTime;
    }

    void MoveControlle()
    {
        this.transform.Translate(this.speedX, this.speedY, 0);

        if(this.transform.position.x > 2900f)
        { this.speedX *= -1; }

        if(this.transform.position.y < -3387f)
        { this.speedY *= -1; }

        if(this.transform.position.x < -1485f)
        { this.speedX *= -1; }

        if(this.transform.position.y > 1542f)
        { this.speedY *= -1; }
    }

	void FixedUpdate ()
    { MoveControlle(); }
}
