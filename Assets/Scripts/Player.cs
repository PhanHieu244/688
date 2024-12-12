using PreviewLabs;
using System;

public class Player
{
	private string STR_COINS = "STR_COINS";

	private string STR_SCORE = "STR_SCORE";

	private const string STR_PLAY_GAME_NUM = "STR_PLAY_GAME_NUM";

	private const string STR_OPEN_APPLICATION = "STR_OPEN_APPLICATION";

	private const string STR_SHOW_RATE = "STR_SHOW_RATE";

	private const string REMOVE_ADS = "REMOVE_ADS";

	private const string CURRENT_LEVEL = "CURRENT_LEVEL";

	private int coins;

	private int highscore;

	private int playGameNum;

	private int openApplicationNum;

	private int currentLevel;

	private bool rateShowed;

	private bool removeAds;

	public int Coins
	{
		get
		{
			return this.coins;
		}
		set
		{
			this.coins = value;
			PlayerPrefs.SetInt(this.STR_COINS, value);
		}
	}

	public int HighScore
	{
		get
		{
			return this.highscore;
		}
		set
		{
			this.highscore = value;
			PlayerPrefs.SetInt(this.STR_SCORE, value);
		}
	}

	public bool RateShowed
	{
		get
		{
			return this.rateShowed;
		}
		set
		{
			this.rateShowed = value;
			PlayerPrefs.SetBool("STR_SHOW_RATE", value);
		}
	}

	public int PlayGameNum
	{
		get
		{
			return this.playGameNum;
		}
		set
		{
			this.playGameNum = value;
			PlayerPrefs.SetInt("STR_PLAY_GAME_NUM", value);
		}
	}

	public int OpenApplicationNum
	{
		get
		{
			return this.openApplicationNum;
		}
		set
		{
			this.openApplicationNum = value;
			PlayerPrefs.SetInt("STR_OPEN_APPLICATION", value);
		}
	}

	public bool RemoveAds
	{
		get
		{
			return this.removeAds;
		}
		set
		{
			this.removeAds = value;
			PlayerPrefs.SetBool("REMOVE_ADS", value);
		}
	}

	public int CurrentLevel
	{
		get
		{
			return this.currentLevel;
		}
		set
		{
			this.currentLevel = value;
			PlayerPrefs.SetInt("CURRENT_LEVEL", value);
		}
	}

	public Player()
	{
		this.coins = PlayerPrefs.GetInt(this.STR_COINS, 0);
		this.highscore = PlayerPrefs.GetInt(this.STR_SCORE, 0);
		this.playGameNum = PlayerPrefs.GetInt("STR_PLAY_GAME_NUM", 1);
		this.openApplicationNum = PlayerPrefs.GetInt("STR_OPEN_APPLICATION", 1);
		PlayerPrefs.SetInt("STR_OPEN_APPLICATION", this.openApplicationNum + 1);
		this.rateShowed = PlayerPrefs.GetBool("STR_SHOW_RATE", false);
		this.removeAds = PlayerPrefs.GetBool("REMOVE_ADS", false);
		this.currentLevel = PlayerPrefs.GetInt("CURRENT_LEVEL", 0);
	}
}
