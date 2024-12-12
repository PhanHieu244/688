using System;
using UnityEngine;

public class HideGameObject : MonoBehaviour
{
	public static HideGameObject Instance;

	private void Awake()
	{
		HideGameObject.Instance = this;
	}
}
