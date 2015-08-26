using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	GameObject GM;
	public GameObject killedByText;
	public GameObject handleText;
	public GameObject tweetText;
	public GameObject timeText;

	// Use this for initialization
	void Start () {
		GM = GameObject.Find ("GM_");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		GameObject.Find ("InputField").GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 50000);
		GameObject.Find ("InputField2").GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 50000);
		GetComponent<Rigidbody2D> ().AddForce (Vector2.down * 1000);
		GetComponent<BoxCollider2D> ().enabled = false;
		Debug.Log ("IT WORKED?!?!?!?");
		killedByText.SetActive(true);
		handleText.SetActive(true);
		tweetText.SetActive(true);
		timeText.SetActive(true);
		GM.GetComponent<GM> ().startGame = true;
		StartCoroutine (stopText ());
		//Destroy (GameObject.Find ("InputField").gameObject, 1f);
		//Destroy (this.gameObject, 1.1f);
	}

	IEnumerator stopText () {
		yield return new WaitForSeconds(0.8f);
		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 1000);
		GameObject.Find ("InputField").GetComponent<Rigidbody2D> ().AddForce (Vector2.down * 50000);
		GameObject.Find ("InputField2").GetComponent<Rigidbody2D> ().AddForce (Vector2.down * 50000);
	}
}
