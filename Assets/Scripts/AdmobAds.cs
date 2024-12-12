using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AdmobAds : MonoBehaviour
{
	private sealed class _showLog_c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
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

		public _showLog_c__Iterator0()
		{
		}

		public bool MoveNext()
		{
			uint num = (uint)this._PC;
			this._PC = -1;
			switch (num)
			{
			case 0u:
				break;
			case 1u:
				break;
			default:
				return false;
			}
			this._current = new WaitForSeconds(2f);
			if (!this._disposing)
			{
				this._PC = 1;
			}
			return true;
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

	private sealed class _CheckTimeOut_c__Iterator1 : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal float _startTime___0;

		internal bool _Loop___0;

		internal WaitForSeconds _tempWFS___0;

		internal AdmobAds _this;

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

		public _CheckTimeOut_c__Iterator1()
		{
		}

		public bool MoveNext()
		{
			uint num = (uint)this._PC;
			this._PC = -1;
			switch (num)
			{
			case 0u:
				this._startTime___0 = Time.time;
				this._Loop___0 = true;
				this._tempWFS___0 = new WaitForSeconds(0.2f);
				break;
			case 1u:
				break;
			default:
				return false;
			}
			if (this._Loop___0)
			{
				if (Time.time - this._startTime___0 < 2f)
				{
					this._current = this._tempWFS___0;
					if (!this._disposing)
					{
						this._PC = 1;
					}
					return true;
				}
				if (this._this.OnEventTrg != null)
				{
					this._Loop___0 = false;
					this._this.OnEventTrg();
					this._this.OnEventTrg = null;
					UnityEngine.Debug.Log("CheckTimeOut OnEventTrg");
				}
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

	public static AdmobAds Instance;

	public static bool ShowAdsFromResume;

	private float lastTime;

	private bool Inited;

	public static AndroidJavaObject jo;

	public static AndroidJavaClass jc;

	private Action OnEventTrg;

	public bool HasRewardVideo
	{
		get
		{
			return false;
		}
	}

	private void Awake()
	{
		if (AdmobAds.Instance == null)
		{
			AdmobAds.Instance = this;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			return;
		}
		UnityEngine.Object.Destroy(base.transform.gameObject);
	}

	private void Start()
	{
	}

	private IEnumerator showLog()
	{
		return new AdmobAds._showLog_c__Iterator0();
	}

	private void loadRewardVideoFreecoins()
	{
	}

	private void loadAdMobInterstitialEnter()
	{
	}

	private void loadAdMobInterstitialPause()
	{
	}

	private void loadAdMobBanner()
	{
	}

	private void HandleRewardBasedVideoClosed(object sender, EventArgs args)
	{
		UnityEngine.Debug.Log("video Closed");
		this.loadRewardVideoFreecoins();
	}

	private void HandleRewardBasedVideoRewarded(object sender, EventArgs args)
	{
		UnityEngine.Debug.Log("video Rewarded");
		this.GetRewarded();
		this.loadRewardVideoFreecoins();
	}

	public void ShowAdMobRewardVideo_freecoins()
	{
		this.loadRewardVideoFreecoins();
	}

	public void ShowAllInterstitial(Action action)
	{
		if (action != null)
		{
			action();
		}
	}

	private void showAdMobInterstitial_enter(Action action)
	{
		this.InitEvent(action);
	}

	private void showAdMobInterstitial_pause(Action action)
	{
		this.SendEventInterstitial();
		this.InitEvent(action);
		base.StopCoroutine("CheckTimeOut");
		base.StartCoroutine("CheckTimeOut");
	}

	private void InitEvent(Action action)
	{
		this.OnEventTrg = action;
	}

	private IEnumerator CheckTimeOut()
	{
		AdmobAds._CheckTimeOut_c__Iterator1 _CheckTimeOut_c__Iterator = new AdmobAds._CheckTimeOut_c__Iterator1();
		_CheckTimeOut_c__Iterator._this = this;
		return _CheckTimeOut_c__Iterator;
	}

	private void HandleOnAdOpened(object sender, EventArgs args)
	{
		if (this.OnEventTrg != null)
		{
			this.OnEventTrg();
			this.OnEventTrg = null;
			UnityEngine.Debug.Log("HandleOnAdOpened +OnEventTrg");
		}
	}

	public void showAllAdsFromFocus()
	{
		if (Time.time - this.lastTime >= 2f && AdmobAds.ShowAdsFromResume)
		{
			this.ShowAllInterstitial(null);
		}
		else
		{
			AdmobAds.ShowAdsFromResume = true;
		}
	}

	private void OnApplicationPause(bool b)
	{
		if (!b)
		{
			this.showAllAdsFromFocus();
		}
		Logw.Log("OnApplicationPause_" + b);
	}

	private void GetRewarded()
	{
		if (AdsManager.OnRewardAdsCompleteAction != null)
		{
			AdsManager.OnRewardAdsCompleteAction();
			AdsManager.OnRewardAdsCompleteAction = null;
		}
	}

	private void SendEventInterstitial()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary["AdType"] = "Interstitial";
	}

	private void SendEventVideo()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary["AdType"] = "Video";
	}

	public void ShowBanner()
	{
	}

	public void HideBanner()
	{
	}
}
