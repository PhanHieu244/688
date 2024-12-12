using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAni : MonoBehaviour
{
	public Text txt;

	public void Init(Transform t)
	{
		this.txt.color = Color.white;
		base.transform.localScale = Vector3.one;
		base.gameObject.SetActive(true);
		this.txt.DOColor(new Color(0f, 0f, 0f, 1f), 0.8f).OnComplete(delegate
		{
			PoolManager.Instance.HideObject(base.gameObject);
		});
	}
}
