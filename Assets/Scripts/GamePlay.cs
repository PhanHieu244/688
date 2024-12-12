using EZCameraShake;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
	[Serializable]
	public struct LevelMessage
	{
		public int level;

		public Vector2 jianciduiRange;

		public int jianciMaxNum;

		public bool yidongjianci;

		public bool wall;

		public bool yidongwall;

		public bool locked;
	}

	private sealed class _RewardWin_c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal GameObject _go___0;

		internal GamePlay _this;

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

		public _RewardWin_c__Iterator0()
		{
		}

		public bool MoveNext()
		{
			uint num = (uint)this._PC;
			this._PC = -1;
			switch (num)
			{
			case 0u:
				SoundManager.Instance.PlayAudio2("Win");
				this._go___0 = UnityEngine.Object.Instantiate<GameObject>(this._this.Partical_win);
				this._go___0.transform.position = Vector3.zero;
				this._current = new WaitForSeconds(2.5f);
				if (!this._disposing)
				{
					this._PC = 1;
				}
				return true;
			case 1u:
				this._this.GameWin(false);
				this._PC = -1;
				break;
			}
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

	private sealed class _HideObj_c__Iterator1 : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal GameObject obj;

		internal GamePlay _this;

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

		public _HideObj_c__Iterator1()
		{
		}

		public bool MoveNext()
		{
			uint num = (uint)this._PC;
			this._PC = -1;
			switch (num)
			{
			case 0u:
				this._current = this._this.hideWs;
				if (!this._disposing)
				{
					this._PC = 1;
				}
				return true;
			case 1u:
				PoolManager.Instance.HideObject(this.obj);
				this._PC = -1;
				break;
			}
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

	public static GamePlay Instance;

	public bool m_Reward;

	public Transform m_RotateTransform;

	public GameObject[] balls;

	public GameObject[] gameObjs0;

	public GameObject bottomObj;

	public int tier;

	public BallController ballController;

	private string effectName0;

	private string effectName1;

	private bool isUp;

	private float upTimer;

	private Vector3 targetPos;

	private Vector3 currentPos;

	private Vector3 tierPos = new Vector3(0f, 0.18f, 0f);

	public List<PlatformObj> m_tierList = new List<PlatformObj>();

	private int m_PerfectNum;

	[Header("==============")]
	public GameView m_GameView;

	[Header("==============")]
	public GameObject rewardGameObjs;

	public GameObject shadow;

	public GameObject Partical_win;

	public Light directional_Light;

	public SpriteRenderer sr;

	[Header("==============")]
	public GameObject ZhangAiWu;

	public GameObject RotateZhangAi;

	public GameObject Wall;

	public GameObject RotateWall;

	public GameObject AnNui;

	public GameObject LockedObj;

	public GameObject CoinObj;

	[Header("==============")]
	public Transform CoinTarget;

	[HideInInspector]
	public Vector3 ZhangAiPos = new Vector3(0f, 0.1f, 0.76f);

	[HideInInspector]
	public Vector3 CoinsPos = new Vector3(0f, 0.2f, 0.76f);

	public ISpawn m_Spawn;

	private LastPlatformObj m_LastPlatformObj;

	private Transform player0;

	private Transform player1;

	public List<GameObject> PintaiLizi = new List<GameObject>();

	public AmbientColorSet CurrentBgAndColor;

	public List<GamePlay.LevelMessage> levelMessage;

	private WaitForSeconds hideWs = new WaitForSeconds(3f);

	private GameObject col;

	private void Awake()
	{
		GamePlay.Instance = this;
		Application.targetFrameRate = 60;
		this.CurrentBgAndColor = ColorSetManager.Instance.GetAmbientColorSetById(CarManager.Instance.currentCar.ID);
		RenderSettings.ambientLight = this.CurrentBgAndColor.ambientColorSet;
		this.directional_Light.color = this.CurrentBgAndColor.lightColorSet;
		this.sr.sprite = this.CurrentBgAndColor.bg;
	}

	private void Start()
	{
		PoolManager.Instance.InitAllPool();
		SoundManager.Instance.PlayBGM("music");
		this.shadow.transform.SetParent(null);
		CarManager.Instance.tryOnCar = null;
		if (this.m_Reward)
		{
			this.SpawnRewardLevel();
			this.SpawnRewardLevelPlayer();
		}
		else
		{
			this.SpawnNormalLevel();
			this.SpawnNormalLevelPlayer();
			//Ads.Instance.replayInterstitialRecord++;
			/*if (Ads.Instance.replayInterstitialRecord >= 3)
			{
				Ads.Instance.replayInterstitialRecord = 0;
				//UnityEngine.Debug.LogError("ShowInterstitial");
				Ads.Instance.ShowInterstitial();
			}*/
		}
		this.m_GameView.Init(PlayerManager.Instance.Coins, 0, PlayerManager.Instance.CurrentLevel, PlayerManager.Instance.CurrentLevel + 1, true);
		this.targetPos = base.transform.position;
		this.m_GameView.UpdateScore(Global.score);
	}

	public void StartGame()
	{
		EventRecord.Instance.EventSet("levelstart", (PlayerManager.Instance.CurrentLevel + 1).ToString());
	}

	private void Update()
	{
		if (this.isUp)
		{
			this.upTimer += Time.deltaTime * 8f;
			base.transform.position = Vector3.Lerp(this.currentPos, this.targetPos, this.upTimer);
			if (this.upTimer >= 1f)
			{
				this.isUp = false;
			}
		}
	}

	public void SpawnNormalLevelPlayer()
	{
		if (this.ballController)
		{
			UnityEngine.Object.Destroy(this.ballController.gameObject);
		}
		GameObject gameObject;
		if (CarManager.Instance.tryOnCar != null)
		{
			gameObject = UnityEngine.Object.Instantiate<GameObject>(this.balls[CarManager.Instance.tryOnCar.ID]);
		}
		else
		{
			gameObject = UnityEngine.Object.Instantiate<GameObject>(this.balls[CarManager.Instance.currentCar.ID]);
		}
		gameObject.transform.position = new Vector3(0f, 1.99f, -1.286f);
		this.ballController = gameObject.GetComponent<BallController>();
		TouchRotate.Instance.Ball = gameObject.transform;
		this.effectName0 = gameObject.GetComponent<BallController>().effectName;
		this.SetCurrentColor(this.ballController.colorId);
	}

	private void SpawnNormalLevel()
	{
		int currentLevel = PlayerManager.Instance.CurrentLevel;
		int index = this.levelMessage.Count - 1;
		for (int i = 0; i < this.levelMessage.Count; i++)
		{
			if (this.levelMessage[i].level > currentLevel)
			{
				index = i;
				break;
			}
		}
		int jianduiNum = Mathf.RoundToInt(Mathf.Lerp(this.levelMessage[index].jianciduiRange.x, this.levelMessage[index].jianciduiRange.y, (float)(currentLevel % 5) / 4f));
		this.m_Spawn = new SpawnLevel6(jianduiNum, this.levelMessage[index].jianciMaxNum, this.levelMessage[index].yidongjianci, this.levelMessage[index].wall, this.levelMessage[index].yidongwall, this.levelMessage[index].locked);
		GameObject[] array = this.gameObjs0;
		Vector3 zero = Vector3.zero;
		Vector3 zero2 = Vector3.zero;
		zero.y = -0.36f;
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.bottomObj, this.m_RotateTransform);
		gameObject.transform.localPosition = zero;
		gameObject.transform.localEulerAngles = Vector3.zero;
		this.m_LastPlatformObj = gameObject.GetComponent<LastPlatformObj>();
		for (int j = 0; j < this.tier; j++)
		{
			zero2.y = (float)(UnityEngine.Random.Range(0, 72) * 5);
			zero.y = (float)j * 0.18f;
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.gameObjs0[UnityEngine.Random.Range(0, array.Length)], this.m_RotateTransform);
			gameObject2.transform.localPosition = zero;
			gameObject2.transform.rotation = Quaternion.Euler(zero2);
			PlatformObj component = gameObject2.GetComponent<PlatformObj>();
			component.SetPian(false);
			this.m_tierList.Add(component);
		}
		this.tier = this.m_tierList.Count;
		this.m_tierList[this.m_tierList.Count - 1].SetPian(true);
		this.m_tierList[this.m_tierList.Count - 1].transform.localEulerAngles = new Vector3(0f, (float)(90 * UnityEngine.Random.Range(-1, 2) + 30), 0f);
		base.transform.position = -zero;
	}

	private void SpawnRewardLevelPlayer()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.balls[CarManager.Instance.currentCar.ID]);
		gameObject.transform.position = new Vector3(-0.9f, 1.99f, -0.87f);
		this.ballController = gameObject.GetComponent<BallController>();
		TouchRotate.Instance.Ball = gameObject.transform;
		this.player0 = gameObject.transform;
		this.effectName0 = gameObject.GetComponent<BallController>().effectName;
		GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.balls[CarManager.Instance.nextCar.ID]);
		gameObject2.transform.position = new Vector3(0.9f, 1.99f, -0.87f);
		this.effectName1 = gameObject2.GetComponent<BallController>().effectName;
		this.player1 = gameObject2.transform.GetChild(0);
		this.player1.SetParent(this.player0);
		UnityEngine.Object.Destroy(gameObject2);
		this.SetCurrentColor(this.ballController.colorId);
	}

	private void SpawnRewardLevel()
	{
		this.m_Spawn = new SpawnLevelReawd();
		Vector3 zero = Vector3.zero;
		Vector3 zero2 = Vector3.zero;
		zero.y = -0.36f;
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.bottomObj, this.m_RotateTransform);
		gameObject.transform.localPosition = zero;
		gameObject.transform.localEulerAngles = Vector3.zero;
		this.m_LastPlatformObj = gameObject.GetComponent<LastPlatformObj>();
		this.m_LastPlatformObj.isReward = true;
		for (int i = 0; i < this.tier; i++)
		{
			zero2.y = (float)(UnityEngine.Random.Range(0, 72) * 5);
			zero.y = (float)i * 0.18f;
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.rewardGameObjs, this.m_RotateTransform);
			gameObject2.transform.localPosition = zero;
			gameObject2.transform.rotation = Quaternion.Euler(zero2);
			PlatformObj component = gameObject2.GetComponent<PlatformObj>();
			component.SetPian(false);
			this.m_tierList.Add(component);
		}
		this.tier = this.m_tierList.Count;
		for (int j = 0; j < this.m_tierList[this.m_tierList.Count - 1].rewardPians.Length; j++)
		{
			this.m_tierList[this.m_tierList.Count - 1].rewardPians[j].SetActive(true);
		}
		base.transform.position = -zero;
	}

	private void Up()
	{
		this.upTimer = 0f;
		this.isUp = true;
		this.currentPos = base.transform.position;
		this.targetPos += this.tierPos;
		if (this.m_tierList.Count > 0)
		{
			for (int i = 0; i < this.PintaiLizi.Count; i++)
			{
				PoolManager.Instance.HideObject(this.PintaiLizi[i]);
			}
			GameObject @object = PoolManager.Instance.GetObject("Huan");
			@object.SetActive(true);
			@object.transform.position = Vector3.zero;
			PlatformObj platformObj = this.m_tierList[this.m_tierList.Count - 1];
			this.m_tierList.RemoveAt(this.m_tierList.Count - 1);
			UnityEngine.Object.Destroy(platformObj.gameObject);
			CameraShaker.Instance.ShakeOnce(2f, 2f, 0f, 0.8f);
		}
		if (!this.m_Reward)
		{
			this.m_GameView.SetTest(this.m_tierList.Count, this.tier);
		}
		if (this.m_tierList.Count > 0)
		{
			this.m_tierList[this.m_tierList.Count - 1].Spawn();
		}
		else
		{
			if (this.m_Reward)
			{
				base.StartCoroutine(this.RewardWin());
			}
			if (CarManager.Instance.nextCar == null)
			{
				base.StartCoroutine(this.RewardWin());
			}
			base.transform.eulerAngles = Vector3.zero;
			this.m_LastPlatformObj.Show();
		}
		this.m_GameView.SetProgress((float)this.m_tierList.Count / (float)this.tier);
		if (!this.m_Reward && this.m_tierList.Count <= 6)
		{
			for (int j = this.m_tierList.Count - 1; j >= 0; j--)
			{
				this.m_tierList[j].Turn();
			}
			return;
		}
	}

	private IEnumerator RewardWin()
	{
		GamePlay._RewardWin_c__Iterator0 _RewardWin_c__Iterator = new GamePlay._RewardWin_c__Iterator0();
		_RewardWin_c__Iterator._this = this;
		return _RewardWin_c__Iterator;
	}

	public void NormalUp()
	{
		Global.score++;
		this.m_GameView.ShowMessage("+1");
		this.m_GameView.UpdateScore(Global.score);
		if (Global.score > PlayerManager.Instance.HighScore)
		{
			PlayerManager.Instance.HighScore = Global.score;
		}
		this.Up();
		this.m_PerfectNum = 0;
		if (this.m_tierList.Count >= 1)
		{
			this.m_tierList[this.m_tierList.Count - 1].SetPian(true);
		}
	}

	public void PerfectUp()
	{
		Global.score += 2;
		if (Global.score > PlayerManager.Instance.HighScore)
		{
			PlayerManager.Instance.HighScore = Global.score;
		}
		this.m_GameView.ShowMessage("PERFECT");
		this.m_GameView.ShowScore();
		this.m_GameView.UpdateScore(Global.score);
		GameObject @object = PoolManager.Instance.GetObject("Partical_Ring");
		@object.SetActive(true);
		@object.transform.position = Vector3.zero;
		base.StartCoroutine(this.HideObj(@object));
		this.m_PerfectNum++;
		if (this.m_PerfectNum >= 3)
		{
			this.m_PerfectNum = 0;
			if (this.m_tierList.Count > 6)
			{
				for (int i = this.m_tierList.Count - 1; i >= this.m_tierList.Count - 6; i--)
				{
					this.m_tierList[i].Turn();
				}
			}
		}
		else if (this.m_tierList.Count > 1)
		{
			this.m_tierList[this.m_tierList.Count - 2].SetPian(true);
		}
		this.Up();
	}

	private IEnumerator HideObj(GameObject obj)
	{
		GamePlay._HideObj_c__Iterator1 _HideObj_c__Iterator = new GamePlay._HideObj_c__Iterator1();
		_HideObj_c__Iterator.obj = obj;
		_HideObj_c__Iterator._this = this;
		return _HideObj_c__Iterator;
	}

	public void AddCoins(GameObject coins)
	{
		PoolManager.Instance.HideObject(coins);
		PlayerManager.Instance.AddCoins(1);
		this.m_GameView.UpdateCoins(PlayerManager.Instance.Coins);
	}

	public void GetReward()
	{
		GameObject @object = PoolManager.Instance.GetObject("Coins");
		@object.GetComponent<CoinMove>().Init(this.player0.position);
		GameObject object2 = PoolManager.Instance.GetObject("Coins");
		object2.GetComponent<CoinMove>().Init(this.player1.position);
	}

	public void GetPa(Vector3 p)
	{
		if (this.m_Reward)
		{
			this.GetPatt(p, this.effectName0);
			p.x = this.player1.position.x;
			p.z = this.player1.position.z;
			this.GetPatt(p, this.effectName1);
		}
		else
		{
			this.GetPatt(p, this.effectName0);
		}
	}

	private void GetPatt(Vector3 p, string effectName)
	{
		GameObject @object = PoolManager.Instance.GetObject(effectName);
		@object.SetActive(true);
		@object.transform.parent = this.m_RotateTransform;
		p.y += BallShadow.shadowTempPos.y;
		@object.transform.position = p;
		@object.transform.eulerAngles = new Vector3(0f, (float)UnityEngine.Random.Range(0, 360), 0f);
		this.PintaiLizi.Add(@object);
	}

	public void GameWin(bool isLocked)
	{
		Global.canShowSign = true;
		this.ShowChaPing();
		if (!this.m_Reward)
		{
			EventRecord.Instance.EventSet("levelfinish", (PlayerManager.Instance.CurrentLevel + 1).ToString());
			PlayerManager.Instance.CurrentLevel++;
		}
		else if (CarManager.Instance.nextCar != null && !CarManager.Instance.nextCar.Locked)
		{
			EventRecord.Instance.EventSet("unlockSkin", CarManager.Instance.nextCar.ID.ToString());
			CarManager.Instance.SelectCar(CarManager.Instance.nextCar.ID);
			CarManager.Instance.SetNextCar();
		}
		if (isLocked)
		{
			SceneManager.LoadScene("Reward");
		}
		else
		{
			SceneManager.LoadScene("Level");
		}
	}

	public void GameOver(GameObject col)
	{
		SoundManager.Instance.PlayAudio2("death");
		this.col = col;
		TouchRotate.Instance.isDown = false;
		this.m_GameView.ShowOver();
		this.ballController.gameObject.SetActive(false);
	}

	public void GetLife()
	{
		if (this.col)
		{
			UnityEngine.Object.Destroy(this.col);
		}
		this.m_GameView.HideOver();
		this.ballController.GetLife();
		//Ads.Instance.replayInterstitialRecord = 0;
		EventRecord.Instance.EventSet("revive", (PlayerManager.Instance.CurrentLevel + 1).ToString());
	}

	private void SetCurrentColor(int id)
	{
		this.CurrentBgAndColor = ColorSetManager.Instance.GetAmbientColorSetById(id);
		RenderSettings.ambientLight = this.CurrentBgAndColor.ambientColorSet;
		this.directional_Light.color = this.CurrentBgAndColor.lightColorSet;
		this.sr.sprite = this.CurrentBgAndColor.bg;
		this.m_LastPlatformObj.SetColor();
		for (int i = 0; i < this.m_tierList.Count; i++)
		{
			this.m_tierList[i].SetColor();
		}
	}

	private void ShowChaPing()
	{
		Global.levelNum++;
	}
}
