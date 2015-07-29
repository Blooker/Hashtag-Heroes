using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using SimpleJSON;

public class TwitterAuth : MonoBehaviour {

	public string consumerKey;
	public string consumerSecret;
	private Dictionary<string, string> headers;
	private string bearer;
	public string hashtag;
	[Multiline]
	public string searchResults;
	public String[] imageUrlsArray = new string[50];
	public bool searchComplete = false;
	public List<string> imageUrls = new List<string>();
	bool listEmpty = false;
	string profilePicUrl;
	int picUrlLength;
	string fileType;



	// Use this for initialization
	void Start () {
		bearer = "";
		StartCoroutine (_Search());
	}
	
	// Update is called once per frame
	void Update () {

	}

	private IEnumerator _Login () {
		string authString = Convert.ToBase64String (Encoding.UTF8.GetBytes(string.Format("{0}:{1}", consumerKey, consumerSecret)));
		headers = new Dictionary<string, string> ();
		headers ["Authorization"] = string.Format ("Basic {0}", authString);

		WWWForm wwwForm = new WWWForm();
		wwwForm.AddField ("grant_type", "client_credentials");
		WWW www = new WWW ("https://api.twitter.com/oauth2/token", wwwForm.data, headers);

		yield return www;

		bearer = JSON.Parse (www.text).AsObject["access_token"];
		Debug.Log (www.text);
	}

	private IEnumerator _Search () {
		if (bearer.Length == 0) {
			yield return StartCoroutine (_Login ());
		}
		headers = new Dictionary<string, string> ();
		headers ["Authorization"] = string.Format ("Bearer {0}", bearer);

		WWW www = new WWW ("https://api.twitter.com/1.1/search/tweets.json?q=" + WWW.EscapeURL(hashtag) + "&result_type=recent&count=50", null, headers);

		yield return www;
		//System.IO.File.WriteAllText (Application.dataPath + "/Tweets.json", www.text);

		Debug.Log (JSON.Parse (www.text));

		foreach (JSONClass tweet in JSON.Parse(www.text).AsObject["statuses"].AsArray) {
			profilePicUrl = tweet["user"]["profile_image_url_https"];
			picUrlLength = profilePicUrl.Length;
			//Debug.Log(picUrlLength);
			if (profilePicUrl.Substring(picUrlLength - 4) == "jpeg") {
				profilePicUrl = profilePicUrl.Remove(picUrlLength - 12);
				fileType = ".jpeg";
			} else if (profilePicUrl.Substring(picUrlLength - 4) == ".jpg") {
				profilePicUrl = profilePicUrl.Remove(picUrlLength - 11);
				fileType = ".jpg";
			} else {
				profilePicUrl = profilePicUrl.Remove(picUrlLength - 11);
				fileType = ".png";
			}
			profilePicUrl += "_reasonably_small" + fileType;
			imageUrls.Add(profilePicUrl);
			//Debug.Log(profilePicUrl);
		}
		imageUrlsArray = imageUrls.ToArray ();
		imageUrls.Reverse ();
		Array.Reverse (imageUrlsArray);
		searchComplete = true;
		//Debug.Log (imageUrlsArray[1]);
	}

	public void Search () {
		StartCoroutine (_Search ());
	}

	public void Login () {
		StartCoroutine (_Login());
	}
}
