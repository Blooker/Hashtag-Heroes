using UnityEngine;
using System.Collections;

public class TwitterPlayerColGet : MonoBehaviour {

	GameObject GM;
	string linkHexCode;
	Color linkColour;
	bool getColTrue = false;
	
	// Use this for initialization
	void Start () {
		GM = GameObject.Find ("GM_");
	}
	
	// Update is called once per frame
	void Update () {
		if (GM.GetComponent<TwitterAuth> ().profileComplete && !getColTrue) {
			GetCol ();
			getColTrue = true;
		}
	}

	void GetCol () {
		if (GM.GetComponent<TwitterAuth> ().playerProfileLinkCol != null) {
			linkHexCode = GM.GetComponent<TwitterAuth> ().playerProfileLinkCol;
		} else {
			linkHexCode = "FFFFFF";
		}
		Color.TryParseHexString (linkHexCode, out linkColour);
		GetComponent<SpriteRenderer> ().color = linkColour;
	}
}
