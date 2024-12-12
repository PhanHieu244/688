using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel6 : ISpawn
{
	private PlatformObj platformObj;

	private Vector3 dir;

	private int m_jianduiNum;

	private int m_jianciMaxNum;

	private bool m_yidongjianci;

	private bool m_wall;

	private bool m_yidongwall;

	private bool m_locekd;

	public SpawnLevel6(int jianduiNum, int jianciMaxNum, bool yidongjianci, bool wall, bool yidongwall, bool locked)
	{
		this.m_jianduiNum = jianduiNum;
		this.m_jianciMaxNum = jianciMaxNum;
		this.m_yidongjianci = yidongjianci;
		this.m_wall = wall;
		this.m_yidongwall = yidongwall;
		this.m_locekd = locked;
	}

	public void Spwan(PlatformObj platformObj, List<Transform> lst, Transform[] wall)
	{
		this.platformObj = platformObj;
		this.dir = GamePlay.Instance.ballController.transform.position;
		this.dir.y = 0f;
		int jianduiNum = this.m_jianduiNum;
		for (int i = 0; i < jianduiNum; i++)
		{
			this.SpawnJianCi(ref lst);
		}
		int num;
		if (platformObj.canLock)
		{
			num = UnityEngine.Random.Range(0, 3);
		}
		else
		{
			num = UnityEngine.Random.Range(0, 2);
		}
		if (num != 0)
		{
			if (num != 1)
			{
				if (num == 2)
				{
					if (this.m_wall && UnityEngine.Random.Range(0, 10) > 5)
					{
						this.SpawnWall(wall);
					}
				}
			}
			else if (this.m_yidongwall && UnityEngine.Random.Range(0, 10) > 5)
			{
				this.SpawnYiDongWall(platformObj.transform);
			}
		}
		else if (this.m_yidongjianci && UnityEngine.Random.Range(0, 10) > 5)
		{
			this.SpawnYiDongJianCi(platformObj.transform);
		}
		if (this.m_locekd && platformObj.canLock && UnityEngine.Random.Range(0, 10) > 4)
		{
			this.SpwanLockObj(platformObj);
		}
		this.SpawnCoins(ref lst);
	}

	private void SpawnJianCi(ref List<Transform> lst)
	{
		List<Transform> list = new List<Transform>();
		List<Transform> list2 = new List<Transform>();
		for (int i = 0; i < lst.Count; i++)
		{
			Vector3 forward = lst[i].forward;
			forward.y = 0f;
			if (Vector3.Angle(forward, this.dir) > 30f)
			{
				list.Add(lst[i]);
			}
			else
			{
				list2.Add(lst[i]);
			}
		}
		int num = this.m_jianciMaxNum;
		int num2 = UnityEngine.Random.Range(0, list.Count);
		num = UnityEngine.Random.Range(1, this.m_jianciMaxNum + 1);
		for (int j = 0; j < num + 2; j++)
		{
			if (!list2.Contains(list[j]))
			{
				list2.Add(list[j]);
			}
			if (j != 0 && j != num + 1)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(GamePlay.Instance.ZhangAiWu, list[j]);
				gameObject.transform.localPosition = GamePlay.Instance.ZhangAiPos;
				gameObject.transform.localEulerAngles = Vector3.zero;
				this.platformObj.SpwanGameObjects.Add(gameObject);
			}
		}
		for (int k = 0; k < list2.Count; k++)
		{
			if (lst.Contains(list2[k]))
			{
				lst.Remove(list2[k]);
			}
		}
	}

	private void SpawnYiDongJianCi(Transform parent)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(GamePlay.Instance.RotateZhangAi, parent);
		gameObject.transform.position = Vector3.zero;
		gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, (float)UnityEngine.Random.Range(-60, 60), 0f));
		this.platformObj.SpwanGameObjects.Add(gameObject);
	}

	private void SpawnWall(Transform[] wallParent)
	{
		int num = 0;
		for (int i = 1; i < wallParent.Length; i++)
		{
			if (Vector3.Angle(wallParent[num].forward, this.dir) > Vector3.Angle(wallParent[i].forward, this.dir))
			{
				num = i;
			}
		}
		if (Vector3.Angle(wallParent[num].forward, this.dir) > 30f)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(GamePlay.Instance.Wall, wallParent[num]);
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localEulerAngles = Vector3.zero;
			gameObject.transform.localScale = Vector3.one;
			gameObject.GetComponent<MeshRenderer>().material = GamePlay.Instance.CurrentBgAndColor.yuanhuan;
			this.platformObj.SpwanGameObjects.Add(gameObject);
		}
	}

	private void SpawnYiDongWall(Transform parent)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(GamePlay.Instance.RotateWall, parent);
		gameObject.transform.position = Vector3.zero;
		gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, (float)UnityEngine.Random.Range(-60, 60), 0f));
		gameObject.GetComponent<MeshRenderer>().material = GamePlay.Instance.CurrentBgAndColor.yuanhuan;
		this.platformObj.SpwanGameObjects.Add(gameObject);
	}

	private void SpwanLockObj(PlatformObj platformObj)
	{
		int index = 0;
		for (int i = 1; i < platformObj.SpawnPoints.Count; i++)
		{
			if ((platformObj.SpawnPoints[index].position - platformObj.m_locked.position).sqrMagnitude > (platformObj.SpawnPoints[i].position - platformObj.m_locked.position).sqrMagnitude)
			{
				index = i;
			}
		}
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(GamePlay.Instance.AnNui, platformObj.SpawnPoints[index]);
		gameObject.transform.localPosition = GamePlay.Instance.ZhangAiPos;
		gameObject.transform.localEulerAngles = Vector3.zero;
		platformObj.SpawnPoints.RemoveAt(index);
		AnNuiObj component = gameObject.transform.GetChild(0).GetComponent<AnNuiObj>();
		component.Init(new Action(platformObj.OnAnNuiCol));
		GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(GamePlay.Instance.LockedObj, platformObj.m_locked);
		gameObject2.transform.localPosition = Vector3.zero;
		gameObject2.transform.localEulerAngles = Vector3.zero;
		platformObj.SpwanGameObjects.Add(gameObject2);
		platformObj.locked = true;
	}

	private void SpawnCoins(ref List<Transform> lst)
	{
		if (UnityEngine.Random.Range(0, 10) > 3)
		{
			int num = UnityEngine.Random.Range(1, 3);
			for (int i = 0; i < lst.Count; i++)
			{
				if (num <= 0)
				{
					break;
				}
				num--;
				int index = UnityEngine.Random.Range(0, lst.Count);
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(GamePlay.Instance.CoinObj, lst[index]);
				gameObject.transform.localPosition = GamePlay.Instance.CoinsPos;
				gameObject.transform.localEulerAngles = Vector3.zero;
				lst.RemoveAt(index);
			}
		}
	}
}
