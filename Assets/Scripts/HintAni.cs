using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class HintAni : MonoBehaviour
{
	public RectTransform rct;

	public Text txtMessage;

	public void Init(string str)
	{
		this.rct.localPosition = new Vector3(0f, -389f, 0f);
		base.transform.DOLocalMove(new Vector3(0f, -589f, 0f), 0.5f, false);
		this.txtMessage.text = str;
		base.Invoke("Hide", 2f);
	}

	private void Hide()
	{
		PoolManager.Instance.HideObject(base.gameObject);
	}
}
