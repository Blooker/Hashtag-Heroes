using UnityEngine;
using System.Collections;

public class Twitter : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Rigidbody2D> ().velocity *= 0.97f;
		if (Input.GetKey (KeyCode.W)) {
			Debug.Log ("YEE");
		}
		GetComponent<Rigidbody2D> ().AddForce(transform.up * 10f);
	}
}
