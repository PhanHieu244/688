
using System;
using UnityEngine;
using UnityEngine.UI;

public class ShowRewardedVideoScript : MonoBehaviour
{
	private GameObject InitText;

	private GameObject ShowButton;

	private GameObject ShowText;

	private GameObject AmountText;

	private int userTotalCredits;

	public static string REWARDED_INSTANCE_ID = "0";

	private void Start()
	{
		UnityEngine.Debug.Log("unity-script: ShowRewardedVideoScript Start called");
		this.ShowButton = GameObject.Find("ShowRewardedVideo");
		this.ShowText = GameObject.Find("ShowRewardedVideoText");
		this.ShowText.GetComponent<Text>().color = Color.red;
		this.AmountText = GameObject.Find("RVAmount");
       
	}

	private void Update()
	{
	}

	public void ShowRewardedVideoButtonClicked()
	{


    }

	private void ShowDemandOnlyRewardedVideo()
	{

	}

	private void RewardedVideoAvailabilityChangedEvent(bool canShowAd)
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAvailabilityChangedEvent, value = " + canShowAd);
		if (canShowAd)
		{
			this.ShowText.GetComponent<Text>().color = Color.blue;
		}
		else
		{
			this.ShowText.GetComponent<Text>().color = Color.red;
		}
	}

	private void RewardedVideoAdOpenedEvent()
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAdOpenedEvent");
	}

	private void RewardedVideoAdRewardedEvent(/*IronSourcePlacement ssp*/)
	{
        this.userTotalCredits += 1;
        this.AmountText.GetComponent<Text>().text = string.Empty + this.userTotalCredits;
	}

	private void RewardedVideoAdClosedEvent()
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAdClosedEvent");
	}

	private void RewardedVideoAdStartedEvent()
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAdStartedEvent");
	}

	private void RewardedVideoAdEndedEvent()
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAdEndedEvent");
	}

	private void RewardedVideoAdShowFailedEvent(/*IronSourceError error*/)
	{
	}

	private void RewardedVideoAdClickedEvent(/*IronSourcePlacement ssp*/)
	{
	//	UnityEngine.Debug.Log("unity-script: I got RewardedVideoAdClickedEvent, name = " + ssp.getRewardName());
	}

	private void RewardedVideoAvailabilityChangedDemandOnlyEvent(string instanceId, bool canShowAd)
	{
		UnityEngine.Debug.Log(string.Concat(new object[]
		{
			"unity-script: I got RewardedVideoAvailabilityChangedDemandOnlyEvent for instance: ",
			instanceId,
			", value = ",
			canShowAd
		}));
		if (canShowAd)
		{
			this.ShowText.GetComponent<Text>().color = Color.blue;
		}
		else
		{
			this.ShowText.GetComponent<Text>().color = Color.red;
		}
	}

	private void RewardedVideoAdOpenedDemandOnlyEvent(string instanceId)
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAdOpenedDemandOnlyEvent for instance: " + instanceId);
	}

	private void RewardedVideoAdRewardedDemandOnlyEvent(string instanceId/*, IronSourcePlacement ssp*/)
	{

        this.userTotalCredits += 1;
        this.AmountText.GetComponent<Text>().text = string.Empty + this.userTotalCredits;

	}

	private void RewardedVideoAdClosedDemandOnlyEvent(string instanceId)
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAdClosedDemandOnlyEvent for instance: " + instanceId);
	}

	private void RewardedVideoAdStartedDemandOnlyEvent(string instanceId)
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAdStartedDemandOnlyEvent for instance: " + instanceId);
	}

	private void RewardedVideoAdEndedDemandOnlyEvent(string instanceId)
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAdEndedDemandOnlyEvent for instance: " + instanceId);
	}

	private void RewardedVideoAdShowFailedDemandOnlyEvent(string instanceId/*, IronSourceError error*/)
	{
       
	}

	private void RewardedVideoAdClickedDemandOnlyEvent(string instanceId/*, IronSourcePlacement ssp*/)
	{
		
	}
}
