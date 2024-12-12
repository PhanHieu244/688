/*
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowOfferwallScript : MonoBehaviour
{
	private GameObject InitText;

	private GameObject ShowButton;

	private GameObject ShowText;

	private GameObject AmountText;

	private int userCredits;

	private void Start()
	{
		UnityEngine.Debug.Log("ShowOfferwallScript Start called");
		this.ShowButton = GameObject.Find("ShowOfferwall");
		this.ShowText = GameObject.Find("ShowOfferwallText");
		this.ShowText.GetComponent<Text>().color = Color.red;
		this.AmountText = GameObject.Find("OWAmount");
		IronSourceEvents.onOfferwallClosedEvent += new Action(this.OfferwallClosedEvent);
		IronSourceEvents.onOfferwallOpenedEvent += new Action(this.OfferwallOpenedEvent);
		IronSourceEvents.onOfferwallShowFailedEvent += new Action<IronSourceError>(this.OfferwallShowFailedEvent);
		IronSourceEvents.onOfferwallAdCreditedEvent += new Action<Dictionary<string, object>>(this.OfferwallAdCreditedEvent);
		IronSourceEvents.onGetOfferwallCreditsFailedEvent += new Action<IronSourceError>(this.GetOfferwallCreditsFailedEvent);
		IronSourceEvents.onOfferwallAvailableEvent += new Action<bool>(this.OfferwallAvailableEvent);
	}

	private void Update()
	{
	}

	public void ShowOfferwallButtonClicked()
	{
		if (IronSource.Agent.isOfferwallAvailable())
		{
			IronSource.Agent.showOfferwall();
		}
		else
		{
			UnityEngine.Debug.Log("IronSource.Agent.isOfferwallAvailable - False");
		}
	}

	private void OfferwallOpenedEvent()
	{
		UnityEngine.Debug.Log("I got OfferwallOpenedEvent");
	}

	private void OfferwallClosedEvent()
	{
		UnityEngine.Debug.Log("I got OfferwallClosedEvent");
	}

	private void OfferwallShowFailedEvent(IronSourceError error)
	{
		UnityEngine.Debug.Log(string.Concat(new object[]
		{
			"I got OfferwallShowFailedEvent, code :  ",
			error.getCode(),
			", description : ",
			error.getDescription()
		}));
	}

	private void OfferwallAdCreditedEvent(Dictionary<string, object> dict)
	{
		UnityEngine.Debug.Log(string.Concat(new object[]
		{
			"I got OfferwallAdCreditedEvent, current credits = ",
			dict["credits"],
			" totalCredits = ",
			dict["totalCredits"]
		}));
		this.userCredits += Convert.ToInt32(dict["credits"]);
		this.AmountText.GetComponent<Text>().text = string.Empty + this.userCredits;
	}

	private void GetOfferwallCreditsFailedEvent(IronSourceError error)
	{
		UnityEngine.Debug.Log(string.Concat(new object[]
		{
			"I got GetOfferwallCreditsFailedEvent, code :  ",
			error.getCode(),
			", description : ",
			error.getDescription()
		}));
	}

	private void OfferwallAvailableEvent(bool canShowOfferwal)
	{
		UnityEngine.Debug.Log("I got OfferwallAvailableEvent, value = " + canShowOfferwal);
		if (canShowOfferwal)
		{
			this.ShowText.GetComponent<Text>().color = Color.blue;
		}
		else
		{
			this.ShowText.GetComponent<Text>().color = Color.red;
		}
	}
}
*/