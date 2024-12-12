using System;

public static class AdsManager
{
	public static Action OnRewardAdsCompleteAction;

	public static void WatchVedio_Freecoins(Action action)
	{
		if (action != null)
		{
			AdsManager.OnRewardAdsCompleteAction = action;
		}
		AdmobAds.Instance.ShowAdMobRewardVideo_freecoins();
	}

	public static void GameLoad(Action action)
	{
		AdmobAds.Instance.ShowAllInterstitial(action);
	}

	public static void ShowBanner()
	{
		AdmobAds.Instance.ShowBanner();
	}

	public static void HideBanner()
	{
		AdmobAds.Instance.HideBanner();
	}

	public static bool HasVideo()
	{
		return AdmobAds.Instance.HasRewardVideo;
	}
}
