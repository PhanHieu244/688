using System;
using System.Collections.Generic;

public class AppManager
{
	public static bool HasRewardVideo
	{
		get
		{
			return AdsManager.HasVideo();
		}
	}

	public static void SetPackage(string pn)
	{
		MyApploction.packageName = pn;
	}

	public static bool CheckPackage()
	{
		return U3dCall.CheckPackage();
	}

	public static void RateGame()
	{
		AdmobAds.ShowAdsFromResume = false;
		U3dCall.RateGame();
	}

	public static void ShareOther()
	{
		U3dCall.ShareOther();
	}

	public static void OpenDownload(string pName)
	{
		U3dCall.OpenDownload(pName);
	}

	public static void ShowLeaderboardsRequested(int maxlevel, int type)
	{
		U3dCall.ShowLeaderboardsRequested(maxlevel, type);
	}

	public static void ShowAchievementsRequested(int maxlevel)
	{
		U3dCall.ShowAchievementsRequested(maxlevel);
	}

	public static void LoadGame(Action action)
	{
		AdsManager.GameLoad(action);
	}

	public static void MoreGame()
	{
		U3dCall.ShowMoreGames();
	}

	public static void WatchVedio_Freecoins(Action action)
	{
		AdsManager.WatchVedio_Freecoins(action);
	}

	public static void SendEventLevel(bool su, int id)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		if (su)
		{
			dictionary["levelid"] = id;
		}
		else
		{
			dictionary["levelid"] = id;
		}
	}

	public static void ShowBanner()
	{
		AdsManager.ShowBanner();
	}

	public static void HideBanner()
	{
		AdsManager.HideBanner();
	}
}
