using System;
using UnityEngine;

public class Logw : MonoBehaviour
{
	public static string logstr = string.Empty;

	private static Rect rect = new Rect(0f, 0f, (float)Screen.width, (float)Screen.height);

	private static bool active_w = false;

	private float timer;

	private void Start()
	{
		if (!Logw.active_w)
		{
			Logw.active_w = true;
		}
	}

	private void OnGUI()
	{
		GUI.Label(Logw.rect, Logw.logstr);
	}

	public static void Log(string str)
	{
		if (Logw.active_w)
		{
			Logw.logstr = Logw.logstr + str + "\r\n";
		}
	}
}
