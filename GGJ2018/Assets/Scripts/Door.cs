using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public CheckIfCorrect check;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D> ();

    }
	
	// Update is called once per frame
	void Update () {

        if (check.AllTrue == true) {
            StartCoroutine (MoveDoor ());
        }

    }

    IEnumerator MoveDoor () {

        rb.AddForce (Vector3.up * 1f);
        yield return new WaitForSeconds (2.0f);
        rb.velocity = Vector3.zero;
  
    }
}
