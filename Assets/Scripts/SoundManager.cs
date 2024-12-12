using PreviewLabs;
using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public const string STR_MUTE = "Mute";

	private static SoundManager instance;

	private static bool musicMute;

	public static AudioSource btnAudioSource;

	public static AudioSource musicAudioSource;

	public static AudioSource btnAudioSource2;

	public string ResDir = "Audio/";

	public static SoundManager Instance
	{
		get
		{
			if (SoundManager.instance == null)
			{
				GameObject gameObject = new GameObject("Sound");
				SoundManager.instance = gameObject.AddComponent<SoundManager>();
				SoundManager.musicAudioSource = gameObject.AddComponent<AudioSource>();
				SoundManager.btnAudioSource = gameObject.AddComponent<AudioSource>();
				SoundManager.btnAudioSource2 = gameObject.AddComponent<AudioSource>();
				SoundManager.musicAudioSource.loop = true;
				SoundManager.musicAudioSource.playOnAwake = false;
				SoundManager.btnAudioSource.loop = false;
				SoundManager.btnAudioSource.playOnAwake = false;
				SoundManager.btnAudioSource.volume = 1f;
				SoundManager.btnAudioSource2.loop = false;
				SoundManager.btnAudioSource2.playOnAwake = false;
				SoundManager.btnAudioSource2.volume = 1f;
				SoundManager.musicMute = PreviewLabs.PlayerPrefs.GetBool("Mute", false);
			}
			return SoundManager.instance;
		}
	}

	public bool MusicMute
	{
		get
		{
			return SoundManager.musicMute;
		}
		set
		{
			SoundManager.musicMute = value;
			SoundManager.musicAudioSource.mute = value;
			PreviewLabs.PlayerPrefs.SetBool("Mute", value);
		}
	}

	public void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	public void PlayAudio(string name)
	{
		if (this.MusicMute)
		{
			return;
		}
		AudioClip audioClip = ResManager.Instance.LoadPrefab(this.ResDir + name) as AudioClip;
		if (audioClip != null)
		{
			SoundManager.btnAudioSource.clip = audioClip;
			SoundManager.btnAudioSource.Play();
		}
		else
		{
			UnityEngine.Debug.LogError("路径存在错误");
		}
	}

	public void PlayAudio2(string name)
	{
		if (this.MusicMute)
		{
			return;
		}
		AudioClip audioClip = ResManager.Instance.LoadPrefab(this.ResDir + name) as AudioClip;
		if (audioClip != null)
		{
			SoundManager.btnAudioSource2.clip = audioClip;
			SoundManager.btnAudioSource2.PlayOneShot(audioClip);
		}
		else
		{
			UnityEngine.Debug.LogError("路径存在错误");
		}
	}

	public void StopBtnSource()
	{
		SoundManager.btnAudioSource.Stop();
	}

	public void PlayAudio(string name, Vector3 pos)
	{
		if (this.MusicMute)
		{
			return;
		}
		AudioClip audioClip = ResManager.Instance.LoadPrefab(this.ResDir + name) as AudioClip;
		if (audioClip != null)
		{
			AudioSource.PlayClipAtPoint(audioClip, pos);
		}
		else
		{
			UnityEngine.Debug.LogError("路径存在错误");
		}
	}

	public bool isBGMPlaying()
	{
		return SoundManager.musicAudioSource.isPlaying;
	}

	public void PlayBGM(string name)
	{
		AudioClip audioClip = ResManager.Instance.LoadPrefab(this.ResDir + name) as AudioClip;
		if (audioClip != null)
		{
			SoundManager.musicAudioSource.clip = audioClip;
		}
		else
		{
			UnityEngine.Debug.LogError("路径存在错误");
		}
		if (this.MusicMute)
		{
			return;
		}
		SoundManager.musicAudioSource.Play();
	}

	public void StopBGM()
	{
		SoundManager.musicAudioSource.Stop();
	}

	public void PlayBGM()
	{
		if (SoundManager.musicAudioSource.clip)
		{
			if (!this.MusicMute)
			{
				SoundManager.musicAudioSource.Play();
			}
			else
			{
				SoundManager.musicAudioSource.Stop();
			}
		}
	}
}
