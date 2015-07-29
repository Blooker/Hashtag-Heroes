using UnityEngine;
using System.Collections;
using System;

public class TwitterPicGet : MonoBehaviour {

	GameObject GM;

	// Use this for initialization
	void Start () {
		GM = GameObject.Find ("GM_");
		GetComponent<Renderer> ().material.mainTexture = new Texture2D (4, 4);
		StartCoroutine (PicGet ());
	}
	
	// Update is called once per frame
	void Update () {

	}

	private IEnumerator PicGet () {
		WWW www = new WWW (GM.GetComponent<TwitterAuth> ().imageUrls[0]);
		yield return www;
		www.LoadImageIntoTexture (GetComponent<Renderer>().material.mainTexture as Texture2D);
		GM.GetComponent<TwitterAuth> ().imageUrls.RemoveAt (0);
	}
}
