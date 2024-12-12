/*
using System;
using UnityEngine;

public class AdBannerScript : MonoBehaviour
{
	private void Start()
	{
		UnityEngine.Debug.Log("unity-script: BannerScript Start called");
		IronSourceEvents.onBannerAdLoadedEvent += new Action(this.BannerAdLoadedEvent);
		IronSourceEvents.onBannerAdLoadFailedEvent += new Action<IronSourceError>(this.BannerAdLoadFailedEvent);
		IronSourceEvents.onBannerAdClickedEvent += new Action(this.BannerAdClickedEvent);
		IronSourceEvents.onBannerAdScreenPresentedEvent += new Action(this.BannerAdScreenPresentedEvent);
		IronSourceEvents.onBannerAdScreenDismissedEvent += new Action(this.BannerAdScreenDismissedEvent);
		IronSourceEvents.onBannerAdLeftApplicationEvent += new Action(this.BannerAdLeftApplicationEvent);
	}

	public void ShowBanner()
	{
		UnityEngine.Debug.Log("unity-script: ShowBanner");
		IronSource.Agent.loadBanner(IronSourceBannerSize.BANNER, IronSourceBannerPosition.BOTTOM);
	}

	public void HideBanner()
	{
		UnityEngine.Debug.Log("unity-script: HideBanner");
		IronSource.Agent.hideBanner();
	}

	public void DestroyBanner()
	{
		UnityEngine.Debug.Log("unity-script: DestroyBanner");
		IronSource.Agent.destroyBanner();
	}

	private void BannerAdLoadedEvent()
	{
		UnityEngine.Debug.Log("unity-script: I got BannerAdLoadedEvent");
	}

	private void BannerAdLoadFailedEvent(IronSourceError error)
	{
		UnityEngine.Debug.Log(string.Concat(new object[]
		{
			"unity-script: I got BannerAdLoadFailedEvent, code: ",
			error.getCode(),
			", description : ",
			error.getDescription()
		}));
	}

	private void BannerAdClickedEvent()
	{
		UnityEngine.Debug.Log("unity-script: I got BannerAdClickedEvent");
	}

	private void BannerAdScreenPresentedEvent()
	{
		UnityEngine.Debug.Log("unity-script: I got BannerAdScreenPresentedEvent");
	}

	private void BannerAdScreenDismissedEvent()
	{
		UnityEngine.Debug.Log("unity-script: I got BannerAdScreenDismissedEvent");
	}

	private void BannerAdLeftApplicationEvent()
	{
		UnityEngine.Debug.Log("unity-script: I got BannerAdLeftApplicationEvent");
	}
}
*/