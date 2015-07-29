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

	// Use this for initialization
	void Start () {
		bearer = "";
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

		WWW www = new WWW ("https://api.twitter.com/1.1/search/tweets.json?q=" + WWW.EscapeURL(hashtag), null, headers);

		yield return www;
		//System.IO.File.WriteAllText (Application.dataPath + "/Tweets.json", www.text);

		Debug.Log (JSON.Parse (www.text));

		foreach (JSONClass tweet in JSON.Parse(www.text).AsObject["statuses"].AsArray) {
			Debug.Log(tweet["text"]);
		}
	}

	public void Search () {
		StartCoroutine (_Search ());
	}

	public void Login () {
		StartCoroutine (_Login());
	}
}
