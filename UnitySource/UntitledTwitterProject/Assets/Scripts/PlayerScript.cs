using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	ParticleSystem flameEffect;
	ParticleSystem smokeEffect;
	bool keyPress = false;

	// Use this for initialization
	void Start () {
		flameEffect = GameObject.Find ("FlameParticles").GetComponent<ParticleSystem> ();
		smokeEffect = GameObject.Find ("SmokeParticles").GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Rigidbody2D> ().velocity *= 0.97f;
		if (Input.GetKey (KeyCode.W)) {
			flameEffect.Emit(2);
			smokeEffect.Emit(2);
			GetComponent<Rigidbody2D> ().AddForce (transform.up * 20f);
		} else if (Input.GetKey (KeyCode.S)) {
			keyPress = true;
			GetComponent<Rigidbody2D> ().AddForce (transform.up * -20f);
		} else {
			flameEffect.Emit(2);
			smokeEffect.Emit(2);
		}
	}
}
