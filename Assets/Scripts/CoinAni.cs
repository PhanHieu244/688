using System;
using UnityEngine;

public class CoinAni : MonoBehaviour
{
	private void Start()
	{
		iTween.MoveBy(base.gameObject, iTween.Hash(new object[]
		{
			"y",
			0.25f,
			"easeType",
			"Linear",
			"loopType",
			"pingPong",
			"delay",
			0.1f
		}));
	}

	private void Update()
	{
		base.transform.Rotate(Vector3.up * 2f);
	}
}
