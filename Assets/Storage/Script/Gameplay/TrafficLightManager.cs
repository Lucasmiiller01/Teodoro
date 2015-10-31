using UnityEngine;
using System.Collections;

public class TrafficLightManager : MonoBehaviour {

    public string inicialLight;
    private string actualLight;
    private SpriteRenderer sprite;

	void Start ()
    {
        sprite = GetComponent<SpriteRenderer>();
        if (inicialLight.Equals(null))
        {
            int random = Random.Range(0, 2);
            if (random.Equals(0))
            {
                actualLight = "Red";
            }
            else
            {
                actualLight = "Green";
            }
        }
        else
            actualLight = inicialLight;
	}
    void OnMouseDown()
    {
        if (actualLight.Equals("Green"))
            StartCoroutine(ToRedLight());
        else
        {
            actualLight = "Green";
        }
    }
    IEnumerator ToRedLight()
    {
        actualLight = "Yellow";
        yield return new WaitForSeconds(2);
        actualLight = "Red";
    }
	void FixedUpdate () 
    {
        if (actualLight.Equals("Green"))
            sprite.color = new Color(0, 255, 0);
        else if (actualLight.Equals("Yellow"))
            sprite.color = new Color(255, 255, 0);
        else if (actualLight.Equals("Red"))
            sprite.color = new Color(255, 0, 0);
        else
        {
            actualLight = "Green";
            sprite.color = new Color(0, 255, 0);
        }
	}
}
