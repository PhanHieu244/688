using System;
using System.Collections.Generic;
using UnityEngine;

public class ResManager
{
	public class PrefabToLoad
	{
		public UnityEngine.Object Prefab;

		public string PrefabName;
	}

	public static ResManager instance;

	private readonly Dictionary<string, ResManager.PrefabToLoad> loadedPrefabDict = new Dictionary<string, ResManager.PrefabToLoad>();

	public static ResManager Instance
	{
		get
		{
			if (ResManager.instance == null)
			{
				ResManager.instance = new ResManager();
			}
			return ResManager.instance;
		}
	}

	public UnityEngine.Object LoadPrefab(string prefabName)
	{
		if (string.IsNullOrEmpty(prefabName))
		{
			return null;
		}
		if (this.loadedPrefabDict.ContainsKey(prefabName))
		{
			return this.loadedPrefabDict[prefabName].Prefab;
		}
		ResManager.PrefabToLoad value = new ResManager.PrefabToLoad
		{
			PrefabName = prefabName,
			Prefab = Resources.Load(prefabName)
		};
		this.loadedPrefabDict.Add(prefabName, value);
		return this.loadedPrefabDict[prefabName].Prefab;
	}

	public void UnLoadPrefab(string prefabName)
	{
		if (this.loadedPrefabDict.ContainsKey(prefabName))
		{
			return;
		}
		Resources.UnloadAsset(this.loadedPrefabDict[prefabName].Prefab);
		this.loadedPrefabDict[prefabName] = null;
		this.loadedPrefabDict.Remove(prefabName);
	}

	public void UnLoadAll()
	{
		foreach (KeyValuePair<string, ResManager.PrefabToLoad> current in this.loadedPrefabDict)
		{
			this.loadedPrefabDict[current.Key] = null;
		}
		this.loadedPrefabDict.Clear();
		Resources.UnloadUnusedAssets();
	}
}
