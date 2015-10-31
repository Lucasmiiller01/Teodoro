using UnityEngine;
using System.Collections;

public class DestroyerBehaviour : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);
    }
}
