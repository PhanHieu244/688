using System;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
	public float speed = 180f;

	private void Start()
	{
		if (UnityEngine.Random.Range(0, 2) > 0)
		{
			this.speed = -this.speed;
		}
	}

	private void FixedUpdate()
	{
		base.transform.Rotate(Vector3.up * this.speed * Time.deltaTime);
	}
}
