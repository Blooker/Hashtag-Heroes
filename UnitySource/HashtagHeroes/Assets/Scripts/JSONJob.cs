using UnityEngine;
using Newtonsoft.Json.Linq;

public class JSONJob : ThreadedJob
{
	public string InData;  // arbitary job data
	public JObject OutData; // arbitary job data

	protected override void ThreadFunction()
	{
		// Do your threaded task. DON'T use the Unity API here
		OutData = JObject.Parse (InData);
	}
	protected override void OnFinished()
	{
		// This is executed by the Unity main thread when the job is finished

	}
}