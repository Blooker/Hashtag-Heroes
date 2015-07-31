using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KilledByDisplay : MonoBehaviour {

	GameObject GM;
	bool gotText = false;
	
	// Use this for initialization
	void Start () {
		GM = GameObject.Find ("GM_");
	}
	
	// Update is called once per frame
	void Update () {
		if (GM.GetComponent<GM> ().startGame) {
			if (GM.GetComponent<GM> ().lose && !gotText) {
				GetComponent<Text> ().text = "You were killed by";
				gotText = true;
			}
		}
	}
}
