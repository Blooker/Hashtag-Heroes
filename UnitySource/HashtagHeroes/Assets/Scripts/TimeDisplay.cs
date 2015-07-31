using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour {

	GameObject GM;
	string timeText;
	bool gotText = false;

	// Use this for initialization
	void Start () {
		GM = GameObject.Find ("GM_");
	}
	
	// Update is called once per frame
	void Update () {
		if (GM.GetComponent<GM> ().startGame) {
			if (GM.GetComponent<GM> ().lose && !gotText) {
				if (GM.GetComponent<GM> ().minuteTimer != 0) {
					timeText = "You lasted for " + GM.GetComponent<GM> ().minuteTimer.ToString() + " minutes, " + GM.GetComponent<GM> ().timerFloor.ToString() + " seconds";
				} else {
					timeText = "You lasted for " + GM.GetComponent<GM> ().timerFloor.ToString() + " seconds";
				}
				GetComponent<Text> ().text = timeText;
				gotText = true;
			}
		}
	}
}
