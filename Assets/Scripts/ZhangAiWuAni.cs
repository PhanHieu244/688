using System;
using UnityEngine;

public class ZhangAiWuAni : MonoBehaviour
{
	public AnimationCurve ani;

	private float timer;

	private Vector3 temp;

	private void Start()
	{
		this.temp = base.transform.localScale;
		this.temp.y = 0f;
		base.transform.localScale = this.temp;
	}

	private void Update()
	{
		this.timer += Time.deltaTime * 2f;
		this.temp.y = this.ani.Evaluate(this.timer);
		base.transform.localScale = this.temp;
	}
}
