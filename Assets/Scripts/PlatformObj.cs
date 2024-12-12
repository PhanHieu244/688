using System;
using System.Collections.Generic;
using UnityEngine;

public class PlatformObj : MonoBehaviour
{
	public bool canLock;

	public bool isReward;

	public Transform m_locked;

	public Transform[] m_WallPoint;

	public GameObject[] pians;

	public MeshRenderer[] Yuanhuans;

	public MeshRenderer[] TouMingHuan;

	public List<Transform> SpawnPoints;

	[HideInInspector]
	public bool locked;

	[HideInInspector]
	public bool turn;

	public bool show;

	public GameObject m;

	[HideInInspector]
	public List<GameObject> SpwanGameObjects;

	public GameObject[] rewardPians;

	private Quaternion targetQua = Quaternion.Euler(new Vector3(0f, 180f, 0f));

	private float timer;

	private bool getReward;

	private void Start()
	{
		this.SetColor();
	}

	public void SetColor()
	{
		for (int i = 0; i < this.Yuanhuans.Length; i++)
		{
			this.Yuanhuans[i].material = GamePlay.Instance.CurrentBgAndColor.yuanhuan;
		}
		for (int j = 0; j < this.TouMingHuan.Length; j++)
		{
			this.TouMingHuan[j].material = GamePlay.Instance.CurrentBgAndColor.toumingyuanhuan;
		}
	}

	private void Update()
	{
		if (this.turn)
		{
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, this.targetQua, Time.deltaTime * 15f);
		}
	}

	private void OnDestroy()
	{
		this.Yuanhuans = null;
		this.SpawnPoints = null;
	}

	public void Turn()
	{
		this.turn = true;
		base.transform.parent = GamePlay.Instance.transform;
		for (int i = 0; i < this.pians.Length; i++)
		{
			this.pians[i].SetActive(false);
		}
		this.OnAnNuiCol();
	}

	public void SetPian(bool b)
	{
		if (this.turn)
		{
			return;
		}
		if (this.isReward)
		{
			for (int i = 0; i < this.rewardPians.Length; i++)
			{
				this.rewardPians[i].SetActive(b);
			}
		}
		else
		{
			for (int j = 0; j < this.pians.Length; j++)
			{
				this.pians[j].SetActive(b);
			}
		}
	}

	public void Clear()
	{
		if (this.isReward && !this.getReward)
		{
			GamePlay.Instance.GetReward();
			this.getReward = true;
		}
		for (int i = 0; i < this.Yuanhuans.Length; i++)
		{
			this.Yuanhuans[i].transform.SetParent(null);
			this.Yuanhuans[i].gameObject.AddComponent<PlatformMove>();
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public void Spawn()
	{
		if (this.turn)
		{
			return;
		}
		this.SpwanGameObjects = new List<GameObject>();
		GamePlay.Instance.m_Spawn.Spwan(this, this.SpawnPoints, this.m_WallPoint);
	}

	public void OnAnNuiCol()
	{
		for (int i = 0; i < this.SpwanGameObjects.Count; i++)
		{
			UnityEngine.Object.Destroy(this.SpwanGameObjects[i]);
			this.locked = false;
		}
	}
}
