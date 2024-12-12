using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ConsentAdmob : MonoBehaviour
{
	private sealed class _CheckIsLocationInEea_c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal WaitForSeconds _wf___0;

		internal bool _bConsentUpdated___1;

		internal ConsentAdmob _this;

		internal object _current;

		internal bool _disposing;

		internal int _PC;

		object IEnumerator<object>.Current
		{
			get
			{
				return this._current;
			}
		}

		object IEnumerator.Current
		{
			get
			{
				return this._current;
			}
		}

		public _CheckIsLocationInEea_c__Iterator0()
		{
		}

		public bool MoveNext()
		{
			uint num = (uint)this._PC;
			this._PC = -1;
			switch (num)
			{
			case 0u:
				this._wf___0 = new WaitForSeconds(3f);
				break;
			case 1u:
				break;
			default:
				return false;
			}
			this._bConsentUpdated___1 = ConsentAdmob.adMobEUConsent.GetStatic<bool>("bConsentUpdated");
			Logw.Log("bConsentUpdated:" + this._bConsentUpdated___1);
			if (!this._bConsentUpdated___1)
			{
				this._current = this._wf___0;
				if (!this._disposing)
				{
					this._PC = 1;
				}
				return true;
			}
			ConsentAdmob.isLocationInEea = ConsentAdmob.adMobEUConsent.GetStatic<bool>("isLocationInEea");
			Logw.Log("isLocationInEea:" + ConsentAdmob.isLocationInEea);
			this._this.setIsLocationInEea(ConsentAdmob.isLocationInEea);
			if (ConsentAdmob.isLocationInEea && !PlayerPrefs.HasKey("mShowNonPersonalizedAdRequestsStr"))
			{
				Logw.Log("ShowConsent");
				ConsentUI.consentUI.ShowConsent(true, false);
			}
			this._PC = -1;
			return false;
		}

		public void Dispose()
		{
			this._disposing = true;
			this._PC = -1;
		}

		public void Reset()
		{
			throw new NotSupportedException();
		}
	}

	public static bool isShowNonPersonalizedAdRequests;

	public static AndroidJavaObject adMobEUConsent;

	public static bool isLocationInEea;

	private const string isLocationInEeaStr = "isLocationInEeaStr";

	private const string isShowNonPersonalizedAdRequestsStr = "mShowNonPersonalizedAdRequestsStr";

	public static ConsentAdmob consentAdmob;

	private void OnEnable()
	{
		ConsentAdmob.consentAdmob = this;
		ConsentAdmob.isLocationInEea = !"false".Equals(PlayerPrefs.GetString("isLocationInEeaStr", "false"));
		ConsentAdmob.isShowNonPersonalizedAdRequests = !"false".Equals(PlayerPrefs.GetString("mShowNonPersonalizedAdRequestsStr", "false"));
		if (ConsentAdmob.isLocationInEea)
		{
			Logw.Log("Location In Eea");
			if (!PlayerPrefs.HasKey("mShowNonPersonalizedAdRequestsStr"))
			{
				Logw.Log("Location In Eea NO Set");
				this.setIsLocationInEea(true);
				ConsentUI.consentUI.ShowConsent(true, false);
			}
			else
			{
				Logw.Log("Location In Eea Set");
			}
		}
		else if (!PlayerPrefs.HasKey("isLocationInEeaStr"))
		{
			Logw.Log("No Where");
			try
			{
				Logw.Log("No Where");
				ConsentAdmob.adMobEUConsent = new AndroidJavaObject("com.admob.eu.consent.AdMobEUConsent", new object[0]);
				ConsentAdmob.adMobEUConsent.Call("checkConsentStatus", new object[]
				{
					"pub-6015391960680907"
				});
				if (ConsentAdmob.adMobEUConsent != null)
				{
					Logw.Log("new ok");
				}
				base.StartCoroutine("CheckIsLocationInEea");
			}
			catch (Exception)
			{
			}
		}
		else
		{
			Logw.Log("No Location In Eea");
		}
	}

	protected IEnumerator CheckIsLocationInEea()
	{
		ConsentAdmob._CheckIsLocationInEea_c__Iterator0 _CheckIsLocationInEea_c__Iterator = new ConsentAdmob._CheckIsLocationInEea_c__Iterator0();
		_CheckIsLocationInEea_c__Iterator._this = this;
		return _CheckIsLocationInEea_c__Iterator;
	}

	public void setIsLocationInEea(bool b)
	{
		ConsentAdmob.isLocationInEea = b;
		PlayerPrefs.SetString("isLocationInEeaStr", (!b) ? "false" : "true");
		PlayerPrefs.Save();
	}

	public void setIsShowNonPersonalizedAdRequests(bool b)
	{
		Logw.Log("setIsShowNonPersonalizedAdRequests:" + b);
		ConsentAdmob.isShowNonPersonalizedAdRequests = b;
		PlayerPrefs.SetString("mShowNonPersonalizedAdRequestsStr", (!b) ? "false" : "true");
		PlayerPrefs.Save();
	}
}
