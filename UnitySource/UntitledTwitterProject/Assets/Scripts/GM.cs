using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour {

	float timer;
	float timerFloor;
	float minuteTimer;
	GameObject UITimer;
	string timerString;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = -1;
		UITimer = GameObject.Find ("Timer");
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		timerFloor = Mathf.Floor (timer) - (minuteTimer * 60);
		minuteTimer = Mathf.Floor (timer / 60f);
		if (timerFloor < 10) {
			timerString = minuteTimer.ToString ("0") + ":0" + timerFloor.ToString ("0");
		} else {
			timerString = minuteTimer.ToString("0") + ":" + timerFloor.ToString("0");
		}
		UITimer.GetComponent<Text> ().text = timerString;
	}

	void KillPlayer () {
		Instantiate (explosion, GameObject.Find ("Player").gameObject.transform.position, Quaternion.identity);
		UITimer.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * -10f);
		Destroy (GameObject.Find ("Player").gameObject);
	}
}
