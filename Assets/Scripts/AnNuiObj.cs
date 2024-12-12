using System;
using UnityEngine;

public class AnNuiObj : MonoBehaviour
{
	private Action handler;

	private bool collision;

	public void Init(Action action)
	{
		this.handler = action;
		this.collision = false;
	}

	public void OnCollision()
	{
		if (this.collision)
		{
			return;
		}
		this.collision = true;
		base.transform.localScale = new Vector3(1f, 0.3f, 1f);
		if (this.handler != null)
		{
			this.handler();
			this.handler = null;
		}
	}
}
