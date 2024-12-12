using System;
using UnityEngine;

public class ConsentUI : MonoBehaviour
{
	public static ConsentUI consentUI;

	public GameObject consentObj;

	public GameObject closeObj;

	private void Awake()
	{
		ConsentUI.consentUI = this;
	}

	public void ShowConsent(bool bShow, bool bShowClose)
	{
		if (bShow)
		{
			this.consentObj.SetActive(true);
			this.closeObj.SetActive(bShowClose);
		}
		else
		{
			this.consentObj.SetActive(false);
		}
	}

	public void ConsentNo()
	{
		ConsentAdmob.consentAdmob.setIsShowNonPersonalizedAdRequests(true);
		this.ShowConsent(false, false);
	}

	public void ConsentYes()
	{
		ConsentAdmob.consentAdmob.setIsShowNonPersonalizedAdRequests(false);
		this.ShowConsent(false, false);
	}

	public void ConsentAbout()
	{
		Application.OpenURL(AdsId.privacyPolicyUrl);
	}

	public void ConsentClose()
	{
		this.ShowConsent(false, false);
	}
}
