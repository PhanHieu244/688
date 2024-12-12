using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjectPool
{
	public string Name;

	[SerializeField]
	private GameObject Prefab;

	public int MaxCount = 20;

	[NonSerialized]
	public List<GameObject> PrefabList = new List<GameObject>();

	public bool Contains(GameObject go)
	{
		return this.PrefabList.Contains(go);
	}

	public GameObject GetObject()
	{
		GameObject gameObject = null;
		for (int i = 0; i < this.PrefabList.Count; i++)
		{
			if (!this.PrefabList[i].activeSelf)
			{
				gameObject = this.PrefabList[i];
				break;
			}
		}
		if (gameObject == null)
		{
			if (this.PrefabList.Count >= this.MaxCount)
			{
				UnityEngine.Object.Destroy(this.PrefabList[0]);
				this.PrefabList.RemoveAt(0);
			}
			gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Prefab);
			this.PrefabList.Add(gameObject);
		}
		return gameObject;
	}

	public void HideObject(GameObject go)
	{
		if (this.PrefabList.Contains(go))
		{
			go.SetActive(false);
		}
	}

	public void HideAllObject()
	{
		for (int i = 0; i < this.PrefabList.Count; i++)
		{
			if (this.PrefabList[i].activeSelf)
			{
				this.HideObject(this.PrefabList[i]);
			}
		}
	}

	public void InitPool()
	{
		this.PrefabList = new List<GameObject>();
	}
}
