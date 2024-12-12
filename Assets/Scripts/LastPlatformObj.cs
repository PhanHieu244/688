using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LastPlatformObj : MonoBehaviour
{
	private sealed class _Win_c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal bool isLocked;

		internal object _current;

		internal bool _disposing;

		internal int _PC;

		object IEnumerator<object>.Current
		{
			get
			{
				return this._current;
			}
		}

		object IEnumerator.Current
		{
			get
			{
				return this._current;
			}
		}

		public _Win_c__Iterator0()
		{
		}

		public bool MoveNext()
		{
			uint num = (uint)this._PC;
			this._PC = -1;
			switch (num)
			{
			case 0u:
				this._current = new WaitForSeconds(3f);
				if (!this._disposing)
				{
					this._PC = 1;
				}
				return true;
			case 1u:
				GamePlay.Instance.GameWin(this.isLocked);
				this._PC = -1;
				break;
			}
			return false;
		}

		public void Dispose()
		{
			this._disposing = true;
			this._PC = -1;
		}

		public void Reset()
		{
			throw new NotSupportedException();
		}
	}

	public AnNuiObj m_AnNuiObj;

	public GameObject[] showGameObjs;

	public Transform spawnPoint;

	public bool isReward;

	private Rigidbody rig;

	public Transform c1;

	public Transform c2;

	public Transform c3;

	public bool show;

	public MeshRenderer MeshRenderer;

	private bool turn;

	private void Start()
	{
		this.show = false;
		for (int i = 0; i < this.showGameObjs.Length; i++)
		{
			this.showGameObjs[i].SetActive(false);
		}
		this.m_AnNuiObj.Init(new Action(this.Hi));
	}

	public void SetColor()
	{
		this.MeshRenderer.materials = GamePlay.Instance.CurrentBgAndColor.dibuyuanhuan;
	}

	public void Show()
	{
		if (this.show || this.isReward)
		{
			return;
		}
		this.show = true;
		if (CarManager.Instance.nextCar != null)
		{
			this.showGameObjs[0].SetActive(true);
			this.showGameObjs[1].SetActive(true);
			int lockedNum = CarManager.Instance.nextCar.LockedNum;
			if (lockedNum != 3)
			{
				if (lockedNum != 2)
				{
					if (lockedNum == 1)
					{
						this.showGameObjs[2].SetActive(false);
						this.showGameObjs[3].SetActive(true);
						this.showGameObjs[4].SetActive(false);
					}
				}
				else
				{
					this.showGameObjs[2].SetActive(false);
					this.showGameObjs[3].SetActive(true);
					this.showGameObjs[4].SetActive(true);
				}
			}
			else
			{
				this.showGameObjs[2].SetActive(true);
				this.showGameObjs[3].SetActive(true);
				this.showGameObjs[4].SetActive(true);
			}
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(GamePlay.Instance.balls[CarManager.Instance.nextCar.ID], this.spawnPoint);
			this.rig = gameObject.GetComponent<Rigidbody>();
			this.rig.isKinematic = true;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localEulerAngles = Vector3.zero;
		}
	}

	private void Hi()
	{
		bool isLocked = false;
		GamePlay.Instance.ballController.transform.SetParent(base.transform);
		TouchRotate.Instance.enabled = false;
		this.turn = true;
		CarManager.Instance.nextCar.LockedNum--;
		int lockedNum = CarManager.Instance.nextCar.LockedNum;
		if (lockedNum != 0)
		{
			if (lockedNum != 1)
			{
				if (lockedNum == 2)
				{
					this.showGameObjs[2].transform.DOMove(new Vector3(0f, 2f, -1f), 0.5f, false).OnComplete(delegate
					{
						GameObject @object = PoolManager.Instance.GetObject("Particle_suo");
						@object.transform.position = this.showGameObjs[2].transform.position;
						@object.SetActive(true);
						UnityEngine.Object.Destroy(this.showGameObjs[2]);
					});
				}
			}
			else
			{
				this.showGameObjs[4].transform.DOMove(new Vector3(0f, 2f, -1f), 0.5f, false).OnComplete(delegate
				{
					GameObject @object = PoolManager.Instance.GetObject("Particle_suo");
					@object.transform.position = this.showGameObjs[4].transform.position;
					@object.SetActive(true);
					UnityEngine.Object.Destroy(this.showGameObjs[4]);
				});
			}
		}
		else
		{
			isLocked = true;
			this.showGameObjs[3].transform.DOMove(new Vector3(0f, 2f, -1f), 0.5f, false).OnComplete(delegate
			{
				UnityEngine.Debug.Log("笼子");
				this.c1.DOMove(new Vector3(1.155f, 0.224f, -0.483f), 0.3f, false);
				this.c2.DOMove(new Vector3(-1.8f, -0.18f, -1.625f), 0.3f, false);
				this.c3.DOMove(new Vector3(-0.159f, 5.251f, -0.078f), 1f, false);
				CarManager.Instance.nextCar.Locked = false;
				this.rig.isKinematic = false;
				GameObject @object = PoolManager.Instance.GetObject("Particle_suo");
				@object.transform.position = this.showGameObjs[3].transform.position;
				@object.SetActive(true);
				UnityEngine.Object.Destroy(this.showGameObjs[3]);
			});
		}
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(GamePlay.Instance.Partical_win);
		gameObject.transform.position = Vector3.zero;
		SoundManager.Instance.PlayAudio2("Win");
		base.StartCoroutine(this.Win(isLocked));
	}

	private IEnumerator Win(bool isLocked)
	{
		LastPlatformObj._Win_c__Iterator0 _Win_c__Iterator = new LastPlatformObj._Win_c__Iterator0();
		_Win_c__Iterator.isLocked = isLocked;
		return _Win_c__Iterator;
	}

	private void Update()
	{
		if (this.turn)
		{
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.Euler(Vector3.zero), Time.deltaTime * 15f);
		}
	}
}
