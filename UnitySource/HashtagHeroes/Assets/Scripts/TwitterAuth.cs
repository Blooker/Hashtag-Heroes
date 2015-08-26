using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class TwitterAuth : MonoBehaviour {

	WWW www;
	public string consumerKey;
	public TextAsset consumerSecret;
	private Dictionary<string, string> headers;
	private string bearer;
	public string hashtag;
	[Multiline]
	public string searchResults;
	public String[] imageUrlsArray = new string[50];
	public bool searchComplete = false;
	public bool profileComplete = false;
	public List<string> imageUrls = new List<string>();
	public string profileLinkCol;
	public string playerProfileLinkCol;
	public List<string> profileLinkColList = new List<string> ();
	public List<string> tweetList = new List<string> ();
	public List<string> handleList = new List<string> ();
	public TextAsset textTest;
	public InputField textInput;
	public InputField textInput2;
	string wwwText;
	string oldestID;
	bool toStart = false;
	bool listEmpty = false;
	string profilePicUrl;
	int picUrlLength;
	public string playerProfilePicUrl;
	int playerPicUrlLength;
	string fileType;

	// Use this for initialization
	void Start () {
		oldestID = "";
		bearer = "";
		//StartCoroutine (_Search());
	}
	
	// Update is called once per frame
	void Update () {
		if (searchComplete) {
			if (imageUrls.Count == 0) {
				listEmpty = true;
			}

			if (listEmpty) {
				searchComplete = false;
				listEmpty = false;
				StartCoroutine(_Search());
			}
		}
	}

	private IEnumerator _Login () {
		string authString = Convert.ToBase64String (Encoding.UTF8.GetBytes(string.Format("{0}:{1}", consumerKey, consumerSecret)));
		headers = new Dictionary<string, string> ();
		headers ["Authorization"] = string.Format ("Basic {0}", authString);

		WWWForm wwwForm = new WWWForm();
		wwwForm.AddField ("grant_type", "client_credentials");
		www = new WWW ("https://api.twitter.com/oauth2/token", wwwForm.data, headers);

		yield return www;

		bearer = (string)JObject.Parse (www.text)["access_token"];
		//Debug.Log (www.text);
	}

	private IEnumerator _PlayerProfile () {
		if (bearer.Length == 0) {
			yield return StartCoroutine (_Login());
		}
		headers = new Dictionary<string, string>();
		headers ["Authorization"] = string.Format ("Bearer {0}", bearer);

		www = new WWW ("https://api.twitter.com/1.1/users/show.json?screen_name=" + WWW.EscapeURL (textInput2.text), null, headers);
		yield return www;

		wwwText = www.text;
		JSONJob myJob = new JSONJob ();
		myJob.InData = wwwText;

		myJob.Start();
		//System.IO.File.WriteAllText (Application.dataPath + "/UserProfile.json", www.text);

		//foreach (JSONClass tweet in JSON.Parse(textTest.text).AsObject["statuses"].AsArray) {
		while (!myJob.Update()) {
			yield return null;
		}
		playerProfilePicUrl = (string)myJob.OutData ["profile_image_url_https"];
		playerProfileLinkCol = (string)myJob.OutData ["profile_link_color"];
		playerPicUrlLength = playerProfilePicUrl.Length;
		//Debug.Log (playerProfileLinkCol);
		//Debug.Log (playerProfilePicUrl);
		if (playerProfilePicUrl.Substring(playerPicUrlLength - 4) == "jpeg") {
			playerProfilePicUrl = playerProfilePicUrl.Remove(playerPicUrlLength - 12);
			fileType = ".jpeg";
		} else if (playerProfilePicUrl.Substring(playerPicUrlLength - 4) == ".jpg") {
			playerProfilePicUrl = playerProfilePicUrl.Remove(playerPicUrlLength - 11);
			fileType = ".jpg";
		} else if (playerProfilePicUrl.Substring(playerPicUrlLength - 4) == ".png"){
			playerProfilePicUrl = playerProfilePicUrl.Remove(playerPicUrlLength - 11);
			fileType = ".png";
		} else if (playerProfilePicUrl.Substring(playerPicUrlLength - 4) == "JPEG") {
			playerProfilePicUrl = playerProfilePicUrl.Remove(playerPicUrlLength - 12);
			fileType = ".JPEG";
		} else if (playerProfilePicUrl.Substring(playerPicUrlLength - 4) == ".JPG") {
			playerProfilePicUrl = playerProfilePicUrl.Remove(playerPicUrlLength - 11);
			fileType = ".JPG";
		} else if (playerProfilePicUrl.Substring(playerPicUrlLength - 4) == ".PNG"){
			playerProfilePicUrl = playerProfilePicUrl.Remove(playerPicUrlLength - 11);
			fileType = ".PNG";
		}
		playerProfilePicUrl += "_reasonably_small" + fileType;
		//Debug.Log (playerProfilePicUrl);
		System.IO.File.WriteAllText (Application.dataPath + "/UserProfile.json", myJob.OutData.ToString());
		profileComplete = true;
		StartCoroutine (_Search ());
	}

	private IEnumerator _Search () {
		if (bearer.Length == 0) {
			yield return StartCoroutine (_Login ());
		}
		headers = new Dictionary<string, string> ();
		headers ["Authorization"] = string.Format ("Bearer {0}", bearer);

		//Task.Factory.StartNew(() => JsonConvert.DeserializeObject(value, type, settings));
		hashtag = textInput.text;
		if (oldestID == "") {
			www = new WWW ("https://api.twitter.com/1.1/search/tweets.json?q=" + WWW.EscapeURL (hashtag) + "&result_type=recent&count=50", null, headers);
		} else {
			if (toStart) {
				www = new WWW ("https://api.twitter.com/1.1/search/tweets.json?q=" + WWW.EscapeURL (hashtag) + "&result_type=recent&count=50", null, headers);
			} else {
				www = new WWW ("https://api.twitter.com/1.1/search/tweets.json?q=" + WWW.EscapeURL (hashtag) + "&count=50&max_id=" + oldestID, null, headers);
			}
		}

		yield return www;

		wwwText = www.text;
		JSONJob myJob = new JSONJob ();
		myJob.InData = wwwText;

		myJob.Start();
		System.IO.File.WriteAllText (Application.dataPath + "/Tweets.json", www.text);

		//foreach (JSONClass tweet in JSON.Parse(textTest.text).AsObject["statuses"].AsArray) {
		while (!myJob.Update()) {
			yield return null;
		}
		//Debug.Log ((JObject)myJob.OutData);
		foreach (JObject tweet in (JArray)myJob.OutData["statuses"]) {
			profilePicUrl = (string)tweet["user"]["profile_image_url_https"];
			profileLinkCol = (string)tweet["user"]["profile_link_color"];
			picUrlLength = profilePicUrl.Length;
			//Debug.Log(profilePicUrl);
			//Debug.Log(profileLinkCol);
			if (profilePicUrl.Substring(picUrlLength - 4) == "jpeg") {
				profilePicUrl = profilePicUrl.Remove(picUrlLength - 12);
				fileType = ".jpeg";
			} else if (profilePicUrl.Substring(picUrlLength - 4) == ".jpg") {
				profilePicUrl = profilePicUrl.Remove(picUrlLength - 11);
				fileType = ".jpg";
			} else if (profilePicUrl.Substring(picUrlLength - 4) == ".png"){
				profilePicUrl = profilePicUrl.Remove(picUrlLength - 11);
				fileType = ".png";
			} else if (profilePicUrl.Substring(picUrlLength - 4) == "JPEG") {
				profilePicUrl = profilePicUrl.Remove(picUrlLength - 12);
				fileType = ".JPEG";
			} else if (profilePicUrl.Substring(picUrlLength - 4) == ".JPG") {
				profilePicUrl = profilePicUrl.Remove(picUrlLength - 11);
				fileType = ".JPG";
			} else if (profilePicUrl.Substring(picUrlLength - 4) == ".PNG"){
				profilePicUrl = profilePicUrl.Remove(picUrlLength - 11);
				fileType = ".PNG";
			}
			profilePicUrl += "_reasonably_small" + fileType;
			imageUrls.Add(profilePicUrl);
			tweetList.Add((string)tweet["text"]);
			profileLinkColList.Add (profileLinkCol);
			handleList.Add ("@" + (string)tweet["user"]["screen_name"])	;
			//Debug.Log("@" + (string)tweet["user"]["screen_name"]);
			oldestID = (string)tweet["id_str"];
		}
		imageUrls.Reverse ();
		profileLinkColList.Reverse ();
		tweetList.Reverse ();
		handleList.Reverse ();
		toStart = false;
		searchComplete = true;
		//Debug.Log (imageUrlsArray[1]);
	}

	public void Search () {
		StartCoroutine (_PlayerProfile ());
	}

	public void Login () {
		StartCoroutine (_Login());
	}
}
