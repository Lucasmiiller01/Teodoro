using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject[] spawns;
	public GameObject winCanvas;
	public static int donePeople;
	public int people;
	public Text childText;
	public Text timeText;
	int seg;
	int min;
	void Start () {
		try{spawns [Random.Range (0, spawns.Length)].GetComponent<SpawnManager> ().canBus = true;}catch{};
		childText.text = donePeople + "/" + people;
		donePeople = 0;
		StartCoroutine(Timer());
	}
	IEnumerator Timer()
	{
		yield return new WaitForSeconds(1f);
		seg ++;
		if (seg > 59) 
		{
			seg = 0;
			min ++;
		}
		if(min < 10)timeText.text = "0" + min + ":";
		else timeText.text = min + ":";
		if(seg < 10)timeText.text += "0" + seg;
		else timeText.text += seg;
		StartCoroutine(Timer());
	}
	void Update () {
		childText.text = donePeople + "/" + people;
		if (donePeople.Equals(people))
			winCanvas.SetActive(true);
	}
	void RestartScene()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
	
	
}
