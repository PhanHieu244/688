/*
using System;
using UnityEngine;
using UnityEngine.UI;

public class ShowInterstitialScript : MonoBehaviour
{
	private GameObject InitText;

	private GameObject LoadButton;

	private GameObject LoadText;

	private GameObject ShowButton;

	private GameObject ShowText;

	public static string INTERSTITIAL_INSTANCE_ID = "0";

	private void Start()
	{
		UnityEngine.Debug.Log("unity-script: ShowInterstitialScript Start called");
		this.LoadButton = GameObject.Find("LoadInterstitial");
		this.LoadText = GameObject.Find("LoadInterstitialText");
		this.LoadText.GetComponent<Text>().color = Color.blue;
		this.ShowButton = GameObject.Find("ShowInterstitial");
		this.ShowText = GameObject.Find("ShowInterstitialText");
		this.ShowText.GetComponent<Text>().color = Color.red;
		IronSourceEvents.onInterstitialAdReadyEvent += new Action(this.InterstitialAdReadyEvent);
		IronSourceEvents.onInterstitialAdLoadFailedEvent += new Action<IronSourceError>(this.InterstitialAdLoadFailedEvent);
		IronSourceEvents.onInterstitialAdShowSucceededEvent += new Action(this.InterstitialAdShowSucceededEvent);
		IronSourceEvents.onInterstitialAdShowFailedEvent += new Action<IronSourceError>(this.InterstitialAdShowFailedEvent);
		IronSourceEvents.onInterstitialAdClickedEvent += new Action(this.InterstitialAdClickedEvent);
		IronSourceEvents.onInterstitialAdOpenedEvent += new Action(this.InterstitialAdOpenedEvent);
		IronSourceEvents.onInterstitialAdClosedEvent += new Action(this.InterstitialAdClosedEvent);
		IronSourceEvents.onInterstitialAdReadyDemandOnlyEvent += new Action<string>(this.InterstitialAdReadyDemandOnlyEvent);
		IronSourceEvents.onInterstitialAdLoadFailedDemandOnlyEvent += new Action<string, IronSourceError>(this.InterstitialAdLoadFailedDemandOnlyEvent);
		IronSourceEvents.onInterstitialAdShowSucceededDemandOnlyEvent += new Action<string>(this.InterstitialAdShowSucceededDemandOnlyEvent);
		IronSourceEvents.onInterstitialAdShowFailedDemandOnlyEvent += new Action<string, IronSourceError>(this.InterstitialAdShowFailedDemandOnlyEvent);
		IronSourceEvents.onInterstitialAdClickedDemandOnlyEvent += new Action<string>(this.InterstitialAdClickedDemandOnlyEvent);
		IronSourceEvents.onInterstitialAdOpenedDemandOnlyEvent += new Action<string>(this.InterstitialAdOpenedDemandOnlyEvent);
		IronSourceEvents.onInterstitialAdClosedDemandOnlyEvent += new Action<string>(this.InterstitialAdClosedDemandOnlyEvent);
		IronSourceEvents.onInterstitialAdRewardedEvent += new Action(this.InterstitialAdRewardedEvent);
	}

	private void Update()
	{
	}

	public void LoadInterstitialButtonClicked()
	{
		UnityEngine.Debug.Log("unity-script: LoadInterstitialButtonClicked");
		IronSource.Agent.loadInterstitial();
	}

	public void ShowInterstitialButtonClicked()
	{
		UnityEngine.Debug.Log("unity-script: ShowInterstitialButtonClicked");
		if (IronSource.Agent.isInterstitialReady())
		{
			IronSource.Agent.showInterstitial();
		}
		else
		{
			UnityEngine.Debug.Log("unity-script: IronSource.Agent.isInterstitialReady - False");
		}
	}

	private void LoadDemandOnlyInterstitial()
	{
		UnityEngine.Debug.Log("unity-script: LoadDemandOnlyInterstitialButtonClicked");
		IronSource.Agent.loadISDemandOnlyInterstitial(ShowInterstitialScript.INTERSTITIAL_INSTANCE_ID);
	}

	private void ShowDemandOnlyInterstitial()
	{
		UnityEngine.Debug.Log("unity-script: ShowDemandOnlyInterstitialButtonClicked");
		if (IronSource.Agent.isISDemandOnlyInterstitialReady(ShowInterstitialScript.INTERSTITIAL_INSTANCE_ID))
		{
			IronSource.Agent.showISDemandOnlyInterstitial(ShowInterstitialScript.INTERSTITIAL_INSTANCE_ID);
		}
		else
		{
			UnityEngine.Debug.Log("unity-script: IronSource.Agent.isISDemandOnlyInterstitialReady - False");
		}
	}

	private void InterstitialAdReadyEvent()
	{
		UnityEngine.Debug.Log("unity-script: I got InterstitialAdReadyEvent");
		this.ShowText.GetComponent<Text>().color = Color.blue;
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
	}

	private void InterstitialAdShowSucceededEvent()
	{
		UnityEngine.Debug.Log("unity-script: I got InterstitialAdShowSucceededEvent");
		this.ShowText.GetComponent<Text>().color = Color.red;
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
		this.ShowText.GetComponent<Text>().color = Color.red;
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
	}

	private void InterstitialAdRewardedEvent()
	{
		UnityEngine.Debug.Log("unity-script: I got InterstitialAdRewardedEvent");
	}

	private void InterstitialAdReadyDemandOnlyEvent(string instanceId)
	{
		UnityEngine.Debug.Log("unity-script: I got InterstitialAdReadyDemandOnlyEvent for instance: " + instanceId);
		this.ShowText.GetComponent<Text>().color = Color.blue;
	}

	private void InterstitialAdLoadFailedDemandOnlyEvent(string instanceId, IronSourceError error)
	{
		UnityEngine.Debug.Log(string.Concat(new object[]
		{
			"unity-script: I got InterstitialAdLoadFailedDemandOnlyEvent for instance: ",
			instanceId,
			", error code: ",
			error.getCode(),
			",error description : ",
			error.getDescription()
		}));
	}

	private void InterstitialAdShowSucceededDemandOnlyEvent(string instanceId)
	{
		UnityEngine.Debug.Log("unity-script: I got InterstitialAdShowSucceededDemandOnlyEvent for instance: " + instanceId);
		this.ShowText.GetComponent<Text>().color = Color.red;
	}

	private void InterstitialAdShowFailedDemandOnlyEvent(string instanceId, IronSourceError error)
	{
		UnityEngine.Debug.Log(string.Concat(new object[]
		{
			"unity-script: I got InterstitialAdShowFailedDemandOnlyEvent for instance: ",
			instanceId,
			", error code :  ",
			error.getCode(),
			",error description : ",
			error.getDescription()
		}));
		this.ShowText.GetComponent<Text>().color = Color.red;
	}

	private void InterstitialAdClickedDemandOnlyEvent(string instanceId)
	{
		UnityEngine.Debug.Log("unity-script: I got InterstitialAdClickedDemandOnlyEvent for instance: " + instanceId);
	}

	private void InterstitialAdOpenedDemandOnlyEvent(string instanceId)
	{
		UnityEngine.Debug.Log("unity-script: I got InterstitialAdOpenedDemandOnlyEvent for instance: " + instanceId);
	}

	private void InterstitialAdClosedDemandOnlyEvent(string instanceId)
	{
		UnityEngine.Debug.Log("unity-script: I got InterstitialAdClosedDemandOnlyEvent for instance: " + instanceId);
	}

	private void InterstitialAdRewardedDemandOnlyEvent(string instanceId)
	{
		UnityEngine.Debug.Log("unity-script: I got InterstitialAdRewardedDemandOnlyEvent for instance: " + instanceId);
	}
}
*/