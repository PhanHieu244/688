using PreviewLabs;
using System;

public class Car
{
	private const string STR_LOCKED = "STR_LOCKED";

	private const string STR_LOCKED_NUM = "STR_LOCKED_NUM";

	private int id;

	private bool locked;

	private int price;

	private int lockedNum;

	public int ID
	{
		get
		{
			return this.id;
		}
	}

	public bool Locked
	{
		get
		{
			return this.locked;
		}
		set
		{
			this.locked = value;
			PlayerPrefs.SetBool("STR_LOCKED" + this.id, value);
		}
	}

	public int Price
	{
		get
		{
			return this.price;
		}
	}

	public int LockedNum
	{
		get
		{
			return this.lockedNum;
		}
		set
		{
			this.lockedNum = value;
			PlayerPrefs.SetInt("STR_LOCKED_NUM" + this.id, value);
		}
	}

	public Car(int id, int price)
	{
		this.id = id;
		this.locked = PlayerPrefs.GetBool("STR_LOCKED" + id, true);
		this.lockedNum = PlayerPrefs.GetInt("STR_LOCKED_NUM" + id, 3);
		this.price = price;
	}
}
