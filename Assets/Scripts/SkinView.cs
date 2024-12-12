using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkinView : MonoBehaviour
{
	public GameObject Message;

	public Button btnUnLocked;

	public Button btnCancel;

	public Button btnClose;

	public Button[] btns;

	public Sprite[] locked_balls;

	public Transform select;

	private int currentid;

	public GameObject go;

	private void Awake()
	{
		this.btnClose.onClick.AddListener(new UnityAction(this.Close));
		this.btnUnLocked.onClick.AddListener(new UnityAction(this.OnbtnUnlockedClick));
		this.btnCancel.onClick.AddListener(new UnityAction(this.OnbtnCancelClick));
	}

	public void Show()
	{
		base.gameObject.SetActive(true);
		this.UpdateInfo();
	}

	private void UpdateInfo()
	{
		this.select.position = this.btns[CarManager.Instance.currentCar.ID].transform.position;
		for (int i = 0; i < this.btns.Length; i++)
		{
			if (CarManager.Instance.cars[i].Locked)
			{
				this.btns[i].image.sprite = this.locked_balls[i];
			}
			else
			{
				this.btns[i].transform.Find("Image").gameObject.SetActive(false);
			}
		}
	}

	public void Click(int id)
	{
		if (!CarManager.Instance.cars[id].Locked)
		{
			CarManager.Instance.SelectCar(id);
			this.select.position = this.btns[CarManager.Instance.currentCar.ID].transform.position;
			GamePlay.Instance.SpawnNormalLevelPlayer();
		}
		else if (PlayerManager.Instance.Coins >= 200)
		{
			this.currentid = id;
			this.go.SetActive(true);
		}
		else
		{
			this.Message.transform.localPosition = new Vector3(0f, -362f, 0f);
			this.Message.SetActive(true);
			this.Message.transform.DOLocalMove(Vector3.zero, 0.5f, false).OnComplete(delegate
			{
				this.Message.SetActive(false);
			});
		}
	}

	private void Close()
	{
		base.gameObject.SetActive(false);
	}

	private void OnbtnUnlockedClick()
	{
		base.gameObject.SetActive(false);
		this.go.SetActive(false);
		CarManager.Instance.cars[this.currentid].Locked = false;
		CarManager.Instance.SelectCar(this.currentid);
		GamePlay.Instance.SpawnNormalLevelPlayer();
		PlayerManager.Instance.GetCoins(200);
		EventRecord.Instance.EventSet("buySkin", this.currentid.ToString());
	}

	private void OnbtnCancelClick()
	{
		this.go.SetActive(false);
	}
}
