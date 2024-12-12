using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
	private static PoolManager instance;

	public const string PoolConfigPath = "Assets/Pool/Resources/pool.asset";

	public Dictionary<string, ObjectPool> poolDict = new Dictionary<string, ObjectPool>();

	public static PoolManager Instance
	{
		get
		{
			if (PoolManager.instance == null)
			{
				PoolManager.instance = new PoolManager();
			}
			return PoolManager.instance;
		}
	}

	public PoolManager()
	{
		ObjectPoolList objectPoolList = Resources.Load<ObjectPoolList>("pool");
		foreach (ObjectPool current in objectPoolList.PoolList)
		{
			this.poolDict.Add(current.Name, current);
		}
	}

	public GameObject GetObject(string poolName)
	{
		if (!this.poolDict.ContainsKey(poolName))
		{
			UnityEngine.Debug.LogError("没有这个 " + poolName + " 池子！");
			return null;
		}
		ObjectPool objectPool = this.poolDict[poolName];
		return objectPool.GetObject();
	}

	public GameObject GetObject(string poolName, Vector3 pos, Quaternion qua)
	{
		ObjectPool objectPool = this.poolDict[poolName];
		GameObject @object = objectPool.GetObject();
		@object.transform.position = pos;
		@object.transform.rotation = qua;
		return @object;
	}

	public void HideObject(GameObject go)
	{
		if (go)
		{
			foreach (ObjectPool current in this.poolDict.Values)
			{
				if (current.Contains(go))
				{
					current.HideObject(go);
					break;
				}
			}
		}
	}

	public void HideAllObject(string poolName)
	{
		if (!this.poolDict.ContainsKey(poolName))
		{
			UnityEngine.Debug.LogError("没有这个 " + poolName + " 池子！");
			return;
		}
		ObjectPool objectPool = this.poolDict[poolName];
		objectPool.HideAllObject();
	}

	public void InitAllPool()
	{
		foreach (ObjectPool current in this.poolDict.Values)
		{
			current.InitPool();
		}
	}
}
