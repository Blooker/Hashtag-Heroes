using UnityEngine;
using System.Collections;

public class CloudSpawn : MonoBehaviour {

	public GameObject cloudSmall;
	public GameObject cloudMedium;
	public GameObject cloudLarge;
	
	float timer;
	float randTime;
	float randY;
	int randSelect;

	// Use this for initialization
	void Start () {
		randTime = Random.Range (0f, 1.5f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timer += Time.deltaTime;
		if (timer >= randTime) {
			randSelect = Random.Range(1, 4);
			randY = Random.Range (-6f, 6f);
			if (randSelect == 1) {
				Instantiate(cloudSmall, new Vector3(17f, randY, 2), Quaternion.identity);
			} else if (randSelect == 2) {
				Instantiate(cloudMedium, new Vector3(17f, randY, 2), Quaternion.identity);
			} else {
				Instantiate(cloudLarge, new Vector3(17f, randY, 2), Quaternion.identity);
			}
			timer = 0;
			randTime = Random.Range (0f, 1.5f);
		}
	}
}
