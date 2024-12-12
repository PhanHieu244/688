using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
	private string SIGNNUM = "SIGNNUM";

	private string Year = "Year_STR";

	private string Month = "Month_STR";

	private string Day = "Day_STR";

	private string Hour = "Hour_STR";

	private string Minute = "Minute_STR";

	private string Second = "Second_STR";

	private int signNum;

	public DateTime lastSign;

	private bool canSign;

	public Button[] btnSigns;

	public Button btnClose;

	public GameObject[] geted;

	private void Awake()
	{
		this.lastSign = new DateTime(PlayerPrefs.GetInt(this.Year, DateTime.Now.Year), PlayerPrefs.GetInt(this.Month, DateTime.Now.Month), PlayerPrefs.GetInt(this.Day, 13), PlayerPrefs.GetInt(this.Hour, 0), PlayerPrefs.GetInt(this.Minute, 0), PlayerPrefs.GetInt(this.Second, 1));
		this.signNum = PlayerPrefs.GetInt(this.SIGNNUM, 0);
		this.UpdatePanel();
		this.btnClose.onClick.AddListener(new UnityAction(this.Close));
	}

	public void UpdatePanel()
	{
		if ((DateTime.Now - this.lastSign).TotalDays > 1.0 && this.signNum < 7)
		{
			this.canSign = true;
		}
		else
		{
			this.canSign = false;
		}
		if (this.canSign)
		{
			for (int i = 0; i < this.btnSigns.Length; i++)
			{
				if (i == this.signNum)
				{
					this.btnSigns[i].interactable = true;
				}
				else
				{
					this.btnSigns[i].interactable = false;
				}
			}
			for (int j = 0; j < this.geted.Length; j++)
			{
				this.geted[j].SetActive(false);
			}
			for (int k = 0; k < this.signNum; k++)
			{
				this.geted[k].SetActive(true);
			}
			return;
		}
		Global.canShowSign = false;
		this.Close();
	}

	public void OnBtnSign(int i)
	{
		if (this.canSign)
		{
			if (i == this.signNum)
			{
				switch (this.signNum)
				{
				case 0:
					PlayerManager.Instance.AddCoins(50);
					GamePlay.Instance.m_GameView.ShowMessage("+50");
					break;
				case 1:
					PlayerManager.Instance.AddCoins(60);
					GamePlay.Instance.m_GameView.ShowMessage("+60");
					break;
				case 2:
					PlayerManager.Instance.AddCoins(70);
					GamePlay.Instance.m_GameView.ShowMessage("+70");
					break;
				case 3:
					PlayerManager.Instance.AddCoins(80);
					GamePlay.Instance.m_GameView.ShowMessage("+80");
					break;
				case 4:
					PlayerManager.Instance.AddCoins(90);
					GamePlay.Instance.m_GameView.ShowMessage("+90");
					break;
				case 5:
					PlayerManager.Instance.AddCoins(100);
					GamePlay.Instance.m_GameView.ShowMessage("+100");
					break;
				case 6:
					PlayerManager.Instance.AddCoins(200);
					GamePlay.Instance.m_GameView.ShowMessage("+200");
					break;
				}
			}
			this.SignUpdate();
			this.UpdatePanel();
			GamePlay.Instance.m_GameView.UpdateCoins(PlayerManager.Instance.Coins);
		}
	}

	private void SignUpdate()
	{
		this.lastSign = DateTime.Now;
		this.signNum++;
		PlayerPrefs.SetInt(this.SIGNNUM, this.signNum);
		PlayerPrefs.SetInt(this.Year, this.lastSign.Year);
		PlayerPrefs.SetInt(this.Month, this.lastSign.Month);
		PlayerPrefs.SetInt(this.Day, this.lastSign.Day);
		PlayerPrefs.SetInt(this.Hour, this.lastSign.Hour);
		PlayerPrefs.SetInt(this.Minute, this.lastSign.Minute);
		PlayerPrefs.SetInt(this.Second, this.lastSign.Second);
	}

	private void Close()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}
}
