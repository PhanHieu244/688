
using System;
using UnityEngine;

public class RewardedVideoControl : MonoBehaviour
{
	private int userTotalCredits;

	public static string REWARDED_INSTANCE_ID = "0";

	public Action RewardedCompleteAction;

	private void Start()
	{
      
	}

	private void Update()
	{
	}

	public void ShowRewardedVideo(Action action)
	{
		this.RewardedCompleteAction = null;
        /*if(AdsControl.Instance.GetRewardAvailable())
        {
            this.RewardedCompleteAction = action;
            AdsControl.Instance.ShowRewardVideo();
        }*/
       
    }

	public bool HasRewardedVideo()
	{
		return true;
        //return AdsControl.Instance.GetRewardAvailable();
	}

	private void RewardedVideoAvailabilityChangedEvent(bool canShowAd)
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAvailabilityChangedEvent, value = " + canShowAd);
	}

	private void RewardedVideoAdOpenedEvent()
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAdOpenedEvent");
	}

	private void RewardedVideoAdRewardedEvent(/*IronSourcePlacement ssp*/)
	{
       
        this.userTotalCredits += 1;
        if (this.RewardedCompleteAction != null)
		{
			this.RewardedCompleteAction();
			this.RewardedCompleteAction = null;
		}
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
		//UnityEngine.Debug.Log("unity-script: I got RewardedVideoAdClickedEvent, name = " + ssp.getRewardName());
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
	}

	private void RewardedVideoAdOpenedDemandOnlyEvent(string instanceId)
	{
		UnityEngine.Debug.Log("unity-script: I got RewardedVideoAdOpenedDemandOnlyEvent for instance: " + instanceId);
	}

	private void RewardedVideoAdRewardedDemandOnlyEvent(string instanceId/*, IronSourcePlacement ssp*/)
	{
       
        this.userTotalCredits += 1;
        if (this.RewardedCompleteAction != null)
		{
			this.RewardedCompleteAction();
			this.RewardedCompleteAction = null;
		}
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
