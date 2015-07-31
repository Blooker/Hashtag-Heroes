using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	GameObject GM;
	ParticleSystem flameEffect;
	ParticleSystem smokeEffect;
	bool keyPress = false;
	public bool lose = false;

	// Use this for initialization
	void Start () {
		GM = GameObject.Find ("GM_");
		flameEffect = GameObject.Find ("FlameParticles").GetComponent<ParticleSystem> ();
		smokeEffect = GameObject.Find ("SmokeParticles").GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Rigidbody2D> ().velocity *= 0.97f;
		if (Input.GetKey (KeyCode.W)) {
			flameEffect.Emit(2);
			smokeEffect.Emit(2);
			GetComponent<Rigidbody2D> ().AddForce (transform.up * 40f);
		} else if (Input.GetKey (KeyCode.S)) {
			keyPress = true;
			GetComponent<Rigidbody2D> ().AddForce (transform.up * -40f);
		} else {
			flameEffect.Emit(2);
			smokeEffect.Emit(2);
		}
	}

	void OnTriggerEnter2D (Collider2D collider) {
		GM.SendMessage ("KillPlayer");
	}
}
