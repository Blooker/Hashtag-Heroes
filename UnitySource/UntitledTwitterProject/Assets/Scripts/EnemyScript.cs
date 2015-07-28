using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	ParticleSystem flameEffect;
	ParticleSystem smokeEffect;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 2.5f);	
		flameEffect = GameObject.Find ("E_FlameParticles").GetComponent<ParticleSystem> ();
		smokeEffect = GameObject.Find ("E_SmokeParticles").GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Rigidbody2D> ().velocity *= 0.97f;
		GetComponent<Rigidbody2D> ().AddForce(Vector2.right * -30);
	}
}
