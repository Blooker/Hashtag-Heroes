using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HashtagEnter : MonoBehaviour {

	InputField input;

	void Start ()
	{
		/*input = GetComponent<InputField>();
		var se= new InputField.SubmitEvent();
		se.AddListener(SubmitName);
		input.onEndEdit = se;
		
		//or simply use the line below, 
		//input.onEndEdit.AddListener(SubmitName);  // This also works*/
	}
	
	/*private void SubmitName(string arg0)
	{
		Debug.Log(arg0);
	}*/
}