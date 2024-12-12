using System;
using UnityEngine;

public class ColorSetManager
{
	private static ColorSetManager instance;

	private AmbientColorSetList objectPoolList;

	public static ColorSetManager Instance
	{
		get
		{
			if (ColorSetManager.instance == null)
			{
				ColorSetManager.instance = new ColorSetManager();
			}
			return ColorSetManager.instance;
		}
	}

	public ColorSetManager()
	{
		this.objectPoolList = Resources.Load<AmbientColorSetList>("colorset");
	}

	public Color GetAmbientColor(int id)
	{
		return this.objectPoolList.list[id].ambientColorSet;
	}

	public Color GetlightColor(int id)
	{
		return this.objectPoolList.list[id].lightColorSet;
	}

	public AmbientColorSet GetAmbientColorSetById(int id)
	{
		return this.objectPoolList.list[id];
	}
}
