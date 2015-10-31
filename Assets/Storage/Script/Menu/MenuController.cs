using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController: MonoBehaviour 
{
    public void ActiveCanvas(GameObject canvasToActive)
    { canvasToActive.SetActive(true); }

    public void DesableCanvas(GameObject canvasToActive)
    { canvasToActive.SetActive(false); }

    public void ChangeToScene(int scene)
    { Application.LoadLevel(scene); }

}
