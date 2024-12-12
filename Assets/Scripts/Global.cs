using System;
using UnityEngine;

public class Global : MonoBehaviour
{
	public static Global Instacne;

	public static bool showTryOn;

	public static int score;

	public static int levelNum;

	public static bool canShowSign;

	private void Awake()
	{
		if (Global.Instacne == null)
		{
			Global.Instacne = this;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public static void Shake()
	{
		if (AdmobAds.jc != null)
		{
			Logw.Log(AdmobAds.jc.ToString());
		}
		if (AdmobAds.jo != null)
		{
			Logw.Log(AdmobAds.jo.ToString());
			AdmobAds.jo.Call("ShakeShake", new object[0]);
		}
	}
}
