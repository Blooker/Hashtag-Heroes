using UnityEngine;
using System.Collections;

public class CloudScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 5f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Rigidbody2D> ().velocity *= 0.97f;
		if (gameObject.tag == "CloudLarge") {
			GetComponent<Rigidbody2D> ().AddForce (Vector2.right * -25);
		} else if (gameObject.tag == "CloudMedium") {
			GetComponent<Rigidbody2D> ().AddForce (Vector2.right * -20);
		} else {
			GetComponent<Rigidbody2D> ().AddForce (Vector2.right * -15);
		}
	}
}
