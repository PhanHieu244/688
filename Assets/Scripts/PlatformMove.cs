using System;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
	private float Z_timer = 0.2f;

	private float zSpeed = 5f;

	private Vector3 dir = new Vector3(0f, 0.7f, 1f);

	private void Update()
	{
		if (this.Z_timer > 0f)
		{
			base.transform.Translate(this.dir * this.zSpeed * Time.deltaTime);
		}
		else
		{
			base.transform.Translate(Vector3.down * this.zSpeed * Time.deltaTime);
		}
		this.Z_timer -= Time.deltaTime;
		if (this.Z_timer < -4f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		this.zSpeed += Time.deltaTime * 2f;
	}
}
