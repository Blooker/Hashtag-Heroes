using UnityEngine;
using System.Collections;

public class TwitterLinkColGet : MonoBehaviour {

	GameObject GM;
	string linkHexCode;
	Color linkColour;
	
	// Use this for initialization
	void Start () {
		GM = GameObject.Find ("GM_");
		if (GM.GetComponent<TwitterAuth> ().profileLinkColList [0] != null) {
			linkHexCode = GM.GetComponent<TwitterAuth> ().profileLinkColList [0];
		} else {
			linkHexCode = "FFFFFF";
		}
		GM.GetComponent<TwitterAuth> ().profileLinkColList.RemoveAt (0);
		Color.TryParseHexString (linkHexCode, out linkColour);
		GetComponent<SpriteRenderer> ().color = linkColour;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
