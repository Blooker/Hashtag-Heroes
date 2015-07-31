using UnityEngine;
using System.Collections;
//using System.Drawing;

public class EnemyScript : MonoBehaviour {

	ParticleSystem flameEffect;
	ParticleSystem smokeEffect;
	GameObject GM;
	public string tweet;
	public string handle;
	public bool lose = false;
	bool triggerLoseEvent = false;
	float timer;
	public bool timerIncrease = true;

	// Use this for initialization
	void Start () {
		GM = GameObject.Find ("GM_");
		tweet = GM.GetComponent<TwitterAuth> ().tweetList [0];
		GM.GetComponent<TwitterAuth> ().tweetList.RemoveAt (0);
		handle = GM.GetComponent<TwitterAuth> ().handleList [0];
		GM.GetComponent<TwitterAuth> ().handleList.RemoveAt (0);
		//Destroy (this.gameObject, 2.1f);	
		flameEffect = GameObject.Find ("E_FlameParticles").GetComponent<ParticleSystem> ();
		smokeEffect = GameObject.Find ("E_SmokeParticles").GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Rigidbody2D> ().velocity *= 0.97f;
		if (timerIncrease)
			timer += Time.deltaTime;
		if (timer >= 2.1f) {
			Destroy (this.gameObject);
		}
		if (!lose) {
			GetComponent<Rigidbody2D> ().AddForce (Vector2.right * -30);
		}
	}
}
