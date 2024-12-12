using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EventRecord : MonoBehaviour
{
	public static EventRecord Instance;

	public static string uniqueUserId = "umeng";

	public static string appKey = "5d130d0e570df3b896000db5";

	private static Dictionary<string, int> __f__switch_map1;

	private void Awake()
	{
		if (EventRecord.Instance == null)
		{
			EventRecord.Instance = this;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void Start()
	{
		
		
	}

	public void EventSet(string type, string message = "")
	{
		UnityEngine.Debug.Log("EventRecord:  " + type + "     " + message);
		switch (type)
		{
		case "levelstart":
			//GA.StartLevel(message);
			break;
		case "levelfinish":
			//GA.FinishLevel(message);
			break;
		case "revive":
			//Analytics.Event("revive", message);
			break;
		case "replay":
			//Analytics.Event("replay", message);
			break;
		case "buySkin":
		//Analytics.Event("buySkin", message);
			break;
		case "unlockSkin":
			//Analytics.Event("unlockSkin", message);
			break;
		case "videoSkin":
		//Analytics.Event("videoSkin");
			break;
		}
	}

	private void OnInitComplete()
	{
		UnityEngine.Debug.Log("FaceBookOnInitComplete");
	}

	private void OnHideUnity(bool isGameShown)
	{
		UnityEngine.Debug.Log("FaceBookOnHideUnity");
	}
}
