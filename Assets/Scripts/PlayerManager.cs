using System;

public class PlayerManager
{
	private static PlayerManager instance;

	private Player player;

	public static PlayerManager Instance
	{
		get
		{
			if (PlayerManager.instance == null)
			{
				PlayerManager.instance = new PlayerManager();
			}
			return PlayerManager.instance;
		}
	}

	public int Coins
	{
		get
		{
			return this.player.Coins;
		}
	}

	public int HighScore
	{
		get
		{
			return this.player.HighScore;
		}
		set
		{
			this.player.HighScore = value;
		}
	}

	public int PlayGameNum
	{
		get
		{
			return this.player.PlayGameNum;
		}
		set
		{
			this.player.PlayGameNum = value;
		}
	}

	public bool RateShowed
	{
		get
		{
			return this.player.RateShowed;
		}
		set
		{
			this.player.RateShowed = value;
		}
	}

	public int OpenApplicationNum
	{
		get
		{
			return this.player.OpenApplicationNum;
		}
		set
		{
			this.player.OpenApplicationNum = value;
		}
	}

	public bool RemoveAds
	{
		get
		{
			return this.player.RemoveAds;
		}
		set
		{
			this.player.RemoveAds = value;
		}
	}

	public int CurrentLevel
	{
		get
		{
			return this.player.CurrentLevel;
		}
		set
		{
			this.player.CurrentLevel = value;
		}
	}

	public PlayerManager()
	{
		this.player = new Player();
	}

	public void AddCoins(int num)
	{
		this.player.Coins += num;
	}

	public bool GetCoins(int num)
	{
		if (num <= this.player.Coins)
		{
			this.player.Coins -= num;
			return true;
		}
		return false;
	}
}
