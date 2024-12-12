using PreviewLabs;
using System;

public class Set
{
	public const string STR_SOUND_MUTE = "STR_MUSIC_MUTE";

	public const string STR_MUSIC_MUTE = "STR_MUSIC_MUTE";

	public const string STR_CONTROL = "STR_CONTROL";

	private bool musicMute;

	private bool soundMute;

	private int controlType;

	public bool SoundMute
	{
		get
		{
			return this.soundMute;
		}
		set
		{
			this.soundMute = value;
			PlayerPrefs.SetBool("STR_MUSIC_MUTE", value);
		}
	}

	public bool MusicMute
	{
		get
		{
			return this.musicMute;
		}
		set
		{
			this.musicMute = value;
			PlayerPrefs.SetBool("STR_MUSIC_MUTE", value);
		}
	}

	public int ControlType
	{
		get
		{
			return this.controlType;
		}
		set
		{
			this.controlType = value;
			PlayerPrefs.SetInt("STR_CONTROL", value);
			PlayerPrefs.Flush();
		}
	}

	public Set()
	{
		this.soundMute = PlayerPrefs.GetBool("STR_MUSIC_MUTE", false);
		this.musicMute = PlayerPrefs.GetBool("STR_MUSIC_MUTE", false);
		this.controlType = PlayerPrefs.GetInt("STR_CONTROL", 0);
	}
}
