using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Test : MonoBehaviour
{
	private static Action __f__am_cache0;

	public void Click0()
	{
	}

	public void Click1()
	{
		AppManager.LoadGame(delegate
		{
			Logw.Log("LoadGame");
		});
	}

	public void Click2()
	{
		AppManager.ShowBanner();
	}

	public void Click3()
	{
	}
}
