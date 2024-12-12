using DG.Tweening.Core;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DG.Tweening
{
	[AddComponentMenu("DOTween/DOTween Animation")]
	public class DOTweenAnimation : ABSAnimationComponent
	{
		public float delay;

		public float duration = 1f;

		public Ease easeType = Ease.OutQuad;

		public AnimationCurve easeCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f),
			new Keyframe(1f, 1f)
		});

		public LoopType loopType;

		public int loops = 1;

		public string id = string.Empty;

		public bool isRelative;

		public bool isFrom;

		public bool isIndependentUpdate;

		public bool autoKill = true;

		public bool isActive = true;

		public bool isValid;

		public Component target;

		public DOTweenAnimationType animationType;

		public bool autoPlay = true;

		public float endValueFloat;

		public Vector3 endValueV3;

		public Color endValueColor = new Color(1f, 1f, 1f, 1f);

		public string endValueString = string.Empty;

		public Rect endValueRect = new Rect(0f, 0f, 0f, 0f);

		public bool optionalBool0;

		public float optionalFloat0;

		public int optionalInt0;

		public RotateMode optionalRotationMode;

		public ScrambleMode optionalScrambleMode;

		public string optionalString;

		private int _playCount = -1;

		private void Awake()
		{
			if (!this.isActive || !this.isValid)
			{
				return;
			}
			this.CreateTween();
		}

		private void OnDestroy()
		{
			if (this.tween != null && this.tween.IsActive())
			{
				this.tween.Kill(false);
			}
			this.tween = null;
		}

		public void CreateTween()
		{
			if (this.target == null)
			{
				UnityEngine.Debug.LogWarning(string.Format("{0} :: This tween's target is NULL, because the animation was created with a DOTween Pro version older than 0.9.255. To fix this, exit Play mode then simply select this object, and it will update automatically", base.gameObject.name), base.gameObject);
				return;
			}
			Type type = this.target.GetType();
			switch (this.animationType)
			{
			case DOTweenAnimationType.Move:
				if (type.IsSameOrSubclassOf(typeof(RectTransform)))
				{
					this.tween = ((RectTransform)this.target).DOAnchorPos3D(this.endValueV3, this.duration, this.optionalBool0);
				}
				else if (type.IsSameOrSubclassOf(typeof(Transform)))
				{
					this.tween = ((Transform)this.target).DOMove(this.endValueV3, this.duration, this.optionalBool0);
				}
				else if (type.IsSameOrSubclassOf(typeof(Rigidbody2D)))
				{
					this.tween = ((Rigidbody2D)this.target).DOMove(this.endValueV3, this.duration, this.optionalBool0);
				}
				else if (type.IsSameOrSubclassOf(typeof(Rigidbody)))
				{
					this.tween = ((Rigidbody)this.target).DOMove(this.endValueV3, this.duration, this.optionalBool0);
				}
				break;
			case DOTweenAnimationType.LocalMove:
				this.tween = base.transform.DOLocalMove(this.endValueV3, this.duration, this.optionalBool0);
				break;
			case DOTweenAnimationType.Rotate:
				if (type.IsSameOrSubclassOf(typeof(Transform)))
				{
					this.tween = ((Transform)this.target).DORotate(this.endValueV3, this.duration, this.optionalRotationMode);
				}
				else if (type.IsSameOrSubclassOf(typeof(Rigidbody2D)))
				{
					this.tween = ((Rigidbody2D)this.target).DORotate(this.endValueFloat, this.duration);
				}
				else if (type.IsSameOrSubclassOf(typeof(Rigidbody)))
				{
					this.tween = ((Rigidbody)this.target).DORotate(this.endValueV3, this.duration, this.optionalRotationMode);
				}
				break;
			case DOTweenAnimationType.LocalRotate:
				this.tween = base.transform.DOLocalRotate(this.endValueV3, this.duration, this.optionalRotationMode);
				break;
			case DOTweenAnimationType.Scale:
				this.tween = base.transform.DOScale((!this.optionalBool0) ? this.endValueV3 : new Vector3(this.endValueFloat, this.endValueFloat, this.endValueFloat), this.duration);
				break;
			case DOTweenAnimationType.Color:
				this.isRelative = false;
				if (type.IsSameOrSubclassOf(typeof(SpriteRenderer)))
				{
					this.tween = ((SpriteRenderer)this.target).DOColor(this.endValueColor, this.duration);
				}
				else if (type.IsSameOrSubclassOf(typeof(Renderer)))
				{
					this.tween = ((Renderer)this.target).material.DOColor(this.endValueColor, this.duration);
				}
				else if (type.IsSameOrSubclassOf(typeof(Image)))
				{
					this.tween = ((Image)this.target).DOColor(this.endValueColor, this.duration);
				}
				else if (type.IsSameOrSubclassOf(typeof(Text)))
				{
					this.tween = ((Text)this.target).DOColor(this.endValueColor, this.duration);
				}
				break;
			case DOTweenAnimationType.Fade:
				this.isRelative = false;
				if (type.IsSameOrSubclassOf(typeof(SpriteRenderer)))
				{
					this.tween = ((SpriteRenderer)this.target).DOFade(this.endValueFloat, this.duration);
				}
				else if (type.IsSameOrSubclassOf(typeof(Renderer)))
				{
					this.tween = ((Renderer)this.target).material.DOFade(this.endValueFloat, this.duration);
				}
				else if (type.IsSameOrSubclassOf(typeof(Image)))
				{
					this.tween = ((Image)this.target).DOFade(this.endValueFloat, this.duration);
				}
				else if (type.IsSameOrSubclassOf(typeof(Text)))
				{
					this.tween = ((Text)this.target).DOFade(this.endValueFloat, this.duration);
				}
				break;
			case DOTweenAnimationType.Text:
				if (type.IsSameOrSubclassOf(typeof(Text)))
				{
					this.tween = ((Text)this.target).DOText(this.endValueString, this.duration, this.optionalBool0, this.optionalScrambleMode, this.optionalString);
				}
				break;
			case DOTweenAnimationType.PunchPosition:
				if (type.IsSameOrSubclassOf(typeof(RectTransform)))
				{
					this.tween = ((RectTransform)this.target).DOPunchAnchorPos(this.endValueV3, this.duration, this.optionalInt0, this.optionalFloat0, this.optionalBool0);
				}
				else if (type.IsSameOrSubclassOf(typeof(Transform)))
				{
					this.tween = ((Transform)this.target).DOPunchPosition(this.endValueV3, this.duration, this.optionalInt0, this.optionalFloat0, this.optionalBool0);
				}
				break;
			case DOTweenAnimationType.PunchRotation:
				this.tween = base.transform.DOPunchRotation(this.endValueV3, this.duration, this.optionalInt0, this.optionalFloat0);
				break;
			case DOTweenAnimationType.PunchScale:
				this.tween = base.transform.DOPunchScale(this.endValueV3, this.duration, this.optionalInt0, this.optionalFloat0);
				break;
			case DOTweenAnimationType.ShakePosition:
				if (type.IsSameOrSubclassOf(typeof(RectTransform)))
				{
					this.tween = ((RectTransform)this.target).DOShakeAnchorPos(this.duration, this.endValueV3, this.optionalInt0, this.optionalFloat0, this.optionalBool0);
				}
				if (type.IsSameOrSubclassOf(typeof(Transform)))
				{
					this.tween = ((Transform)this.target).DOShakePosition(this.duration, this.endValueV3, this.optionalInt0, this.optionalFloat0, this.optionalBool0);
				}
				break;
			case DOTweenAnimationType.ShakeRotation:
				this.tween = base.transform.DOShakeRotation(this.duration, this.endValueV3, this.optionalInt0, this.optionalFloat0);
				break;
			case DOTweenAnimationType.ShakeScale:
				this.tween = base.transform.DOShakeScale(this.duration, this.endValueV3, this.optionalInt0, this.optionalFloat0);
				break;
			case DOTweenAnimationType.CameraAspect:
				this.tween = ((Camera)this.target).DOAspect(this.endValueFloat, this.duration);
				break;
			case DOTweenAnimationType.CameraBackgroundColor:
				this.tween = ((Camera)this.target).DOColor(this.endValueColor, this.duration);
				break;
			case DOTweenAnimationType.CameraFieldOfView:
				this.tween = ((Camera)this.target).DOFieldOfView(this.endValueFloat, this.duration);
				break;
			case DOTweenAnimationType.CameraOrthoSize:
				this.tween = ((Camera)this.target).DOOrthoSize(this.endValueFloat, this.duration);
				break;
			case DOTweenAnimationType.CameraPixelRect:
				this.tween = ((Camera)this.target).DOPixelRect(this.endValueRect, this.duration);
				break;
			case DOTweenAnimationType.CameraRect:
				this.tween = ((Camera)this.target).DORect(this.endValueRect, this.duration);
				break;
			}
			if (this.tween == null)
			{
				return;
			}
			if (this.isFrom)
			{
				((Tweener)this.tween).From(this.isRelative);
			}
			else
			{
				this.tween.SetRelative(this.isRelative);
			}
			this.tween.SetTarget(base.gameObject).SetDelay(this.delay).SetLoops(this.loops, this.loopType).SetAutoKill(this.autoKill).OnKill(delegate
			{
				this.tween = null;
			});
			if (this.easeType == Ease.INTERNAL_Custom)
			{
				this.tween.SetEase(this.easeCurve);
			}
			else
			{
				this.tween.SetEase(this.easeType);
			}
			if (!string.IsNullOrEmpty(this.id))
			{
				this.tween.SetId(this.id);
			}
			this.tween.SetUpdate(this.isIndependentUpdate);
			if (this.hasOnStart)
			{
				if (this.onStart != null)
				{
					this.tween.OnStart(new TweenCallback(this.onStart.Invoke));
				}
			}
			else
			{
				this.onStart = null;
			}
			if (this.hasOnPlay)
			{
				if (this.onPlay != null)
				{
					this.tween.OnPlay(new TweenCallback(this.onPlay.Invoke));
				}
			}
			else
			{
				this.onPlay = null;
			}
			if (this.hasOnUpdate)
			{
				if (this.onUpdate != null)
				{
					this.tween.OnUpdate(new TweenCallback(this.onUpdate.Invoke));
				}
			}
			else
			{
				this.onUpdate = null;
			}
			if (this.hasOnStepComplete)
			{
				if (this.onStepComplete != null)
				{
					this.tween.OnStepComplete(new TweenCallback(this.onStepComplete.Invoke));
				}
			}
			else
			{
				this.onStepComplete = null;
			}
			if (this.hasOnComplete)
			{
				if (this.onComplete != null)
				{
					this.tween.OnComplete(new TweenCallback(this.onComplete.Invoke));
				}
			}
			else
			{
				this.onComplete = null;
			}
			if (this.autoPlay)
			{
				this.tween.Play<Tween>();
			}
			else
			{
				this.tween.Pause<Tween>();
			}
		}

		public override void DOPlay()
		{
			DOTween.Play(base.gameObject);
		}

		public override void DOPlayBackwards()
		{
			DOTween.PlayBackwards(base.gameObject);
		}

		public override void DOPlayForward()
		{
			DOTween.PlayForward(base.gameObject);
		}

		public override void DOPause()
		{
			DOTween.Pause(base.gameObject);
		}

		public override void DOTogglePause()
		{
			DOTween.TogglePause(base.gameObject);
		}

		public override void DORewind()
		{
			this._playCount = -1;
			DOTweenAnimation[] components = base.gameObject.GetComponents<DOTweenAnimation>();
			for (int i = components.Length - 1; i > -1; i--)
			{
				Tween tween = components[i].tween;
				if (tween != null && tween.IsInitialized())
				{
					components[i].tween.Rewind(true);
				}
			}
		}

		public override void DORestart(bool fromHere = false)
		{
			this._playCount = -1;
			if (this.tween == null)
			{
				if (Debugger.logPriority > 1)
				{
					Debugger.LogNullTween(this.tween);
				}
				return;
			}
			if (fromHere && this.isRelative)
			{
				this.ReEvaluateRelativeTween();
			}
			DOTween.Restart(base.gameObject, true);
		}

		public override void DOComplete()
		{
			DOTween.Complete(base.gameObject);
		}

		public override void DOKill()
		{
			DOTween.Kill(base.gameObject, false);
			this.tween = null;
		}

		public void DOPlayById(string id)
		{
			DOTween.Play(base.gameObject, id);
		}

		public void DOPlayAllById(string id)
		{
			DOTween.Play(id);
		}

		public void DOPlayNext()
		{
			DOTweenAnimation[] components = base.GetComponents<DOTweenAnimation>();
			while (this._playCount < components.Length - 1)
			{
				this._playCount++;
				DOTweenAnimation dOTweenAnimation = components[this._playCount];
				if (dOTweenAnimation != null && dOTweenAnimation.tween != null && !dOTweenAnimation.tween.IsPlaying() && !dOTweenAnimation.tween.IsComplete())
				{
					dOTweenAnimation.tween.Play<Tween>();
					break;
				}
			}
		}

		public void DORewindAndPlayNext()
		{
			this._playCount = -1;
			DOTween.Rewind(base.gameObject, true);
			this.DOPlayNext();
		}

		public void DORestartById(string id)
		{
			this._playCount = -1;
			DOTween.Restart(base.gameObject, id, true);
		}

		public void DORestartAllById(string id)
		{
			this._playCount = -1;
			DOTween.Restart(id, true);
		}

		public List<Tween> GetTweens()
		{
			return DOTween.TweensByTarget(base.gameObject, false);
		}

		private void ReEvaluateRelativeTween()
		{
			if (this.animationType == DOTweenAnimationType.Move)
			{
				((Tweener)this.tween).ChangeEndValue(base.transform.position + this.endValueV3, true);
			}
			else if (this.animationType == DOTweenAnimationType.LocalMove)
			{
				((Tweener)this.tween).ChangeEndValue(base.transform.localPosition + this.endValueV3, true);
			}
		}
	}
}
