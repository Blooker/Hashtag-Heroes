using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour {

	bool timeIncrease = true;
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
		if (timeIncrease == true) {
			timer += Time.deltaTime;
			timerFloor = Mathf.Floor (timer) - (minuteTimer * 60);
			minuteTimer = Mathf.Floor (timer / 60f);
			if (timerFloor < 10) {
				timerString = minuteTimer.ToString ("0") + ":0" + timerFloor.ToString ("0");
			} else {
				timerString = minuteTimer.ToString ("0") + ":" + timerFloor.ToString ("0");
			}
			UITimer.GetComponent<Text> ().text = timerString;
		}
	}

	void KillPlayer () {
		timeIncrease = false;
		Instantiate (explosion, GameObject.Find ("Player").gameObject.transform.position, Quaternion.identity);
		UITimer.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * -36500f);
		Destroy (GameObject.Find ("Player").gameObject);
	}
}
