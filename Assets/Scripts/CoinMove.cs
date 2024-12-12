using System;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
	public Transform child;

	public Vector3 targetScale;

	private float timer;

	private Vector3 startPos;

	private AnimationCurve m_AnimationCurve;

	private Vector3 temp = Vector3.zero;

	private bool right;

	public void Init(Vector3 pos)
	{
		GameObject @object = PoolManager.Instance.GetObject("Particle_coin");
		@object.SetActive(true);
		@object.transform.position = pos;
		this.timer = 0f;
		this.startPos = pos;
		base.transform.position = this.startPos;
		if (this.startPos.x >= 0f)
		{
			this.right = true;
		}
		else
		{
			this.right = false;
		}
		this.m_AnimationCurve = new AnimationCurve();
		this.m_AnimationCurve.AddKey(0f, 0f);
		this.m_AnimationCurve.AddKey(UnityEngine.Random.Range(0.2f, 0.5f), UnityEngine.Random.Range(0.03f, 0.06f));
		this.m_AnimationCurve.AddKey(UnityEngine.Random.Range(0.6f, 0.8f), UnityEngine.Random.Range(0.03f, 0.06f));
		this.m_AnimationCurve.AddKey(1f, 0f);
		if (!base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(true);
		}
	}

	private void Update()
	{
		this.timer += Time.deltaTime * 1.5f;
		base.transform.position = Vector3.Lerp(this.startPos, GamePlay.Instance.CoinTarget.position, this.timer);
		float num = this.m_AnimationCurve.Evaluate(this.timer);
		if (this.right)
		{
			this.temp.x = num;
		}
		else
		{
			this.temp.x = -num;
		}
		this.child.Rotate(Vector3.up * 150f);
		this.child.localPosition = this.temp;
		this.child.localScale = Vector3.Lerp(Vector3.one, this.targetScale, this.timer);
		if (this.timer >= 1f)
		{
			this.timer = 0f;
			GamePlay.Instance.AddCoins(base.gameObject);
		}
	}
}
