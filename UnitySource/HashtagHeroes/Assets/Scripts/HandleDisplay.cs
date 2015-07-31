using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HandleDisplay : MonoBehaviour {

	GameObject GM;
	public GameObject[] enemies;
	bool gotText = false;
	
	// Use this for initialization
	void Start () {
		GM = GameObject.Find ("GM_");
	}
	
	// Update is called once per frame
	void Update () {
		if (GM.GetComponent<GM> ().startGame) {
			enemies = GameObject.FindGameObjectsWithTag ("Enemy");
			if (GM.GetComponent<GM> ().lose && !gotText) {
				GetComponent<Text> ().text = enemies [0].GetComponent<EnemyScript> ().handle;
				gotText = true;
			}
		}
	}
}
