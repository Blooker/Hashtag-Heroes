using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartButton : MonoBehaviour {

	GameObject GM;
	public bool clicked;
	public GameObject textInput;
	public GameObject textInput2;
	public GameObject buttonPlay;

	// Use this for initialization
	void Start () {
		GM = GameObject.Find ("GM_");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		GM.GetComponent<TwitterAuth> ().textInput = textInput.GetComponent<InputField> ();
		GM.GetComponent<TwitterAuth> ().textInput2 = textInput2.GetComponent<InputField> ();
		GameObject.Find ("Logo").GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 1000);
		GetComponent<Rigidbody2D> ().AddForce (Vector2.down * 1000);
		GetComponent<BoxCollider2D> ().enabled = false;
		Debug.Log ("IT WORKED?!?!?!?");
		clicked = true;
		StartCoroutine (showInput ());
		Destroy (GameObject.Find ("Logo").gameObject, 1f);
		Destroy (this.gameObject, 1.1f);

	}

	IEnumerator showInput () {
		yield return new WaitForSeconds(0.8f);
		textInput.SetActive(true);
		textInput2.SetActive (true);
		buttonPlay.SetActive (true);
	}
}
