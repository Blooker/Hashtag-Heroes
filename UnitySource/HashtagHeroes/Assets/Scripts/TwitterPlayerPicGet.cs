using UnityEngine;
using System.Collections;

public class TwitterPlayerPicGet : MonoBehaviour {

	GameObject GM;
	bool coroutineStarted = false;
	
	// Use this for initialization
	void Start () {
		GM = GameObject.Find ("GM_");
		GetComponent<Renderer> ().material.mainTexture = new Texture2D (4, 4);
	}
	
	// Update is called once per frame
	void Update () {
		if (GM.GetComponent<TwitterAuth> ().profileComplete && !coroutineStarted) {
			StartCoroutine (PicGet ());
			coroutineStarted = true;
		}
	}
	
	private IEnumerator PicGet () {
		WWW www = new WWW (GM.GetComponent<TwitterAuth> ().playerProfilePicUrl);
		yield return www;
		www.LoadImageIntoTexture (GetComponent<Renderer>().material.mainTexture as Texture2D);
	}
}
