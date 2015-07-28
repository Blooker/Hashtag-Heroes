using UnityEngine;
using System.Collections;

public class EnemySpawnScript : MonoBehaviour {

	public float spawnInterval;
	public GameObject enemy;
	float timer;
	int randomNum;
	int oldNum;
	
	// Use this for initialization
	void Start () {
		oldNum = 0;
		randomNum = 0;
		Spawn ();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= spawnInterval) {
			Spawn ();
			timer = 0f;
			if (spawnInterval >= 0.5f) {
				spawnInterval -= 0.005f;
			}
		}
	}

	void Spawn () {
		while (randomNum == oldNum) {
			randomNum = Random.Range (1, 4);
		}
		oldNum = randomNum;
		if (randomNum == 1) {
			Instantiate(enemy, new Vector3(17f, 4.8f, 0f), Quaternion.identity);
		} else if (randomNum == 2) {
			Instantiate(enemy, new Vector3(17.1f, 0.8f, 0f), Quaternion.identity);
		} else {
			Instantiate(enemy, new Vector3(17.4f, -3.4f, 0f), Quaternion.identity);
		}
	}
}
