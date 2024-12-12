using System;
using System.Collections.Generic;
using UnityEngine;

public class SetManager
{
	private static SetManager instance;

	private Set set;

	public AudioSource bgmAudio;

	public List<AudioSource> audioList;

	public static SetManager Instance
	{
		get
		{
			if (SetManager.instance == null)
			{
				SetManager.instance = new SetManager();
			}
			return SetManager.instance;
		}
	}

	public bool SoundMute
	{
		get
		{
			return this.set.SoundMute;
		}
		set
		{
			this.set.SoundMute = value;
			this.SetMetu(value);
		}
	}

	public bool MusicMute
	{
		get
		{
			return this.set.MusicMute;
		}
		set
		{
			this.set.MusicMute = value;
			SoundManager.Instance.MusicMute = value;
		}
	}

	public int ControlType
	{
		get
		{
			return this.set.ControlType;
		}
		set
		{
			this.set.ControlType = value;
		}
	}

	public SetManager()
	{
		this.set = new Set();
		this.audioList = new List<AudioSource>();
	}

	private void SetMetu(bool b)
	{
		for (int i = 0; i < this.audioList.Count; i++)
		{
			if (this.audioList[i])
			{
				this.audioList[i].mute = b;
			}
		}
	}
}
