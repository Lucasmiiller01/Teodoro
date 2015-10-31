using UnityEngine;
using System.Collections;

public class TrafficLightMenuManager : MonoBehaviour {

    public string inicialLight;
    private string actualLight;
    private SpriteRenderer sprite;

	void Start ()
    {
        sprite = GetComponent<SpriteRenderer>();

            if (this.gameObject.tag.Equals("LightVertical"))
            { this.actualLight = "Red"; }
            else if (this.gameObject.tag.Equals("LightHorizontal"))
            { this.actualLight = "Green"; }

        StartCoroutine(ChangeLight());
	}
    void OnMouseDown()
    {
        if (actualLight.Equals("Green"))
        { StartCoroutine(ToRedLight()); }
        else
        { actualLight = "Green"; }
    }

    IEnumerator ToRedLight()
    {
        actualLight = "Yellow";
        yield return new WaitForSeconds(2);
        actualLight = "Red";
    }

    IEnumerator ToGreenLight()
    {
        yield return new WaitForSeconds(2);
        actualLight = "Green";
    }

    IEnumerator ChangeLight()
    {
        yield return new WaitForSeconds(10);

        if (this.actualLight.Equals("Green"))
        { StartCoroutine(ToRedLight()); }

        if(this.actualLight.Equals("Red"))
        { StartCoroutine(ToGreenLight()); }

        StartCoroutine(ChangeLight());
    }

    void ColorManager()
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

	void FixedUpdate () 
    {
        ColorManager();
	}
}
