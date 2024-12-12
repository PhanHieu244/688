/*
using System;
using UnityEngine;

public class InterstitialControl : MonoBehaviour
{
	public static string INTERSTITIAL_INSTANCE_ID = "0";

	private void Start()
	{
		UnityEngine.Debug.Log("unity-script: ShowInterstitialScript Start called");
		IronSourceEvents.onInterstitialAdReadyEvent += new Action(this.InterstitialAdReadyEvent);
		IronSourceEvents.onInterstitialAdLoadFailedEvent += new Action<IronSourceError>(this.InterstitialAdLoadFailedEvent);
		IronSourceEvents.onInterstitialAdShowSucceededEvent += new Action(this.InterstitialAdShowSucceededEvent);
		IronSourceEvents.onInterstitialAdShowFailedEvent += new Action<IronSourceError>(this.InterstitialAdShowFailedEvent);
		IronSourceEvents.onInterstitialAdClickedEvent += new Action(this.InterstitialAdClickedEvent);
		IronSourceEvents.onInterstitialAdOpenedEvent += new Action(this.InterstitialAdOpenedEvent);
		IronSourceEvents.onInterstitialAdClosedEvent += new Action(this.InterstitialAdClosedEvent);
		IronSourceEvents.onInterstitialAdRewardedEvent += new Action(this.InterstitialAdRewardedEvent);
		this.LoadInterstitial();
	}

	private void Update()
	{
	}

	public void LoadInterstitial()
	{
		UnityEngine.Debug.Log("unity-script: LoadInterstitial");
		IronSource.Agent.loadInterstitial();
	}

	public void ShowInterstitial()
	{
		this.LoadInterstitial();
		UnityEngine.Debug.Log("unity-script: ShowInterstitial");
		if (IronSource.Agent.isInterstitialReady())
		{
			IronSource.Agent.showInterstitial();
		}
		else
		{
			UnityEngine.Debug.Log("unity-script: IronSource.Agent.isInterstitialReady - False");
		}
	}

	private void InterstitialAdReadyEvent()
	{
		UnityEngine.Debug.Log("unity-script: I got InterstitialAdReadyEvent");
	}

	private void InterstitialAdLoadFailedEvent(IronSourceError error)
	{
		UnityEngine.Debug.Log(string.Concat(new object[]
		{
			"unity-script: I got InterstitialAdLoadFailedEvent, code: ",
			error.getCode(),
			", description : ",
			error.getDescription()
		}));
		this.LoadInterstitial();
	}

	private void InterstitialAdShowSucceededEvent()
	{
		UnityEngine.Debug.Log("unity-script: I got InterstitialAdShowSucceededEvent");
		this.LoadInterstitial();
	}

	private void InterstitialAdShowFailedEvent(IronSourceError error)
	{
		UnityEngine.Debug.Log(string.Concat(new object[]
		{
			"unity-script: I got InterstitialAdShowFailedEvent, code :  ",
			error.getCode(),
			", description : ",
			error.getDescription()
		}));
		this.LoadInterstitial();
	}

	private void InterstitialAdClickedEvent()
	{
		UnityEngine.Debug.Log("unity-script: I got InterstitialAdClickedEvent");
	}

	private void InterstitialAdOpenedEvent()
	{
		UnityEngine.Debug.Log("unity-script: I got InterstitialAdOpenedEvent");
	}

	private void InterstitialAdClosedEvent()
	{
		UnityEngine.Debug.Log("unity-script: I got InterstitialAdClosedEvent");
		this.LoadInterstitial();
	}

	private void InterstitialAdRewardedEvent()
	{
		UnityEngine.Debug.Log("unity-script: I got InterstitialAdRewardedEvent");
		this.LoadInterstitial();
	}
}
*/