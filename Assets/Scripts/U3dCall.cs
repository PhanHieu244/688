using System;
using UnityEngine;

public class U3dCall
{
	public static bool CheckPackage()
	{
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		string value = @static.Call<string>("getPackageName", new object[0]);
		return MyApploction.packageName.Equals(value);
	}

	public static void ShowMoreGames()
	{
		if (U3dCall.ChecakPacakge("com.android.vending"))
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("android.content.Intent");
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("android.content.Intent", new object[0]);
			androidJavaObject.Call<AndroidJavaObject>("setAction", new object[]
			{
				androidJavaClass.GetStatic<string>("ACTION_VIEW")
			});
			AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("android.net.Uri");
			AndroidJavaObject androidJavaObject2 = androidJavaClass2.CallStatic<AndroidJavaObject>("parse", new object[]
			{
				"market://search?q=pub:"
			});
			androidJavaObject.Call<AndroidJavaObject>("setPackage", new object[]
			{
				"com.android.vending"
			});
			androidJavaObject.Call<AndroidJavaObject>("setData", new object[]
			{
				androidJavaObject2
			});
			AndroidJavaClass androidJavaClass3 = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject @static = androidJavaClass3.GetStatic<AndroidJavaObject>("currentActivity");
			@static.Call("startActivity", new object[]
			{
				androidJavaObject
			});
		}
		else
		{
			Application.OpenURL("market://search?q=pub:");
		}
	}

	public static void RateGame()
	{
		U3dCall.OpenGooglePlay(MyApploction.packageName);
	}

	private static bool ChecakPacakge(string pName)
	{
		AndroidJavaObject result = null;
		try
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			AndroidJavaObject androidJavaObject = @static.Call<AndroidJavaObject>("getPackageManager", new object[0]);
			result = androidJavaObject.Call<AndroidJavaObject>("getLaunchIntentForPackage", new object[]
			{
				pName
			});
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.Log("exception" + ex.Message);
		}
		return result != null;
	}

	private static void OpenGooglePlay(string pName)
	{
		if (U3dCall.ChecakPacakge("com.android.vending"))
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("android.content.Intent");
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("android.content.Intent", new object[0]);
			androidJavaObject.Call<AndroidJavaObject>("setAction", new object[]
			{
				androidJavaClass.GetStatic<string>("ACTION_VIEW")
			});
			AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("android.net.Uri");
			AndroidJavaObject androidJavaObject2 = androidJavaClass2.CallStatic<AndroidJavaObject>("parse", new object[]
			{
				"market://details?id=" + pName
			});
			androidJavaObject.Call<AndroidJavaObject>("setPackage", new object[]
			{
				"com.android.vending"
			});
			androidJavaObject.Call<AndroidJavaObject>("setData", new object[]
			{
				androidJavaObject2
			});
			AndroidJavaClass androidJavaClass3 = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject @static = androidJavaClass3.GetStatic<AndroidJavaObject>("currentActivity");
			@static.Call("startActivity", new object[]
			{
				androidJavaObject
			});
		}
		else
		{
			Application.OpenURL("market://details?id=" + pName);
		}
	}

	public static void ShareOther()
	{
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("android.content.Intent");
		AndroidJavaObject androidJavaObject = new AndroidJavaObject("android.content.Intent", new object[0]);
		androidJavaObject.Call<AndroidJavaObject>("setAction", new object[]
		{
			androidJavaClass.GetStatic<string>("ACTION_SEND")
		});
		androidJavaObject.Call<AndroidJavaObject>("setType", new object[]
		{
			"text/plain"
		});
		androidJavaObject.Call<AndroidJavaObject>("putExtra", new object[]
		{
			androidJavaClass.GetStatic<string>("EXTRA_SUBJECT"),
			Application.productName
		});
		androidJavaObject.Call<AndroidJavaObject>("putExtra", new object[]
		{
			androidJavaClass.GetStatic<string>("EXTRA_TEXT"),
			Application.productName + " Great Game. Download Url https://play.google.com/store/apps/details?id=" + MyApploction.packageName
		});
		androidJavaObject.Call<AndroidJavaObject>("setFlags", new object[]
		{
			androidJavaClass.GetStatic<int>("FLAG_ACTIVITY_NEW_TASK")
		});
		AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject @static = androidJavaClass2.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaObject androidJavaObject2 = androidJavaClass.CallStatic<AndroidJavaObject>("createChooser", new object[]
		{
			androidJavaObject,
			"Share Games"
		});
		@static.Call("startActivity", new object[]
		{
			androidJavaObject2
		});
	}

	public static void OpenDownload(string pName)
	{
		U3dCall.OpenGooglePlay(pName);
	}

	public static void ShowLeaderboardsRequested(int maxlevel, int type)
	{
	}

	public static void ShowAchievementsRequested(int maxlevel)
	{
	}
}
