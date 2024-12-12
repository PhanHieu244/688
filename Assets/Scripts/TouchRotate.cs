using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchRotate : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEventSystemHandler
{
	public static TouchRotate Instance;

	public Transform target;

	public Transform Ball;

	[HideInInspector]
	public List<BallShadow> rotateBalls;

	[HideInInspector]
	private Vector3 LastPos;

	[HideInInspector]
	public bool isDown;

	public float speed = 0.7f;

	public Action fristAction;

	private bool canRight;

	private bool canLeft;

	public float rightLeftLineDis;

	public LayerMask LayerMask;

	public Transform hit;

	private void Awake()
	{
		TouchRotate.Instance = this;
	}

	private void Update()
	{
		if (Time.timeScale == 0f)
		{
			return;
		}
		Ray ray = new Ray(this.Ball.position, Vector3.right);
		RaycastHit raycastHit;
		if (Physics.Raycast(ray, out raycastHit, this.rightLeftLineDis, this.LayerMask))
		{
			this.canLeft = false;
			this.hit = raycastHit.collider.transform;
		}
		else
		{
			this.canLeft = true;
		}
		ray.direction = Vector3.left;
		if (Physics.Raycast(ray, out raycastHit, this.rightLeftLineDis, this.LayerMask))
		{
			this.canRight = false;
			this.hit = raycastHit.collider.transform;
		}
		else
		{
			this.canRight = true;
		}
		if (!this.isDown)
		{
			return;
		}
		float num = UnityEngine.Input.mousePosition.x - this.LastPos.x;
		num = Mathf.Clamp(num, -20f, 20f);
		this.rightLeftLineDis = num * 0.2f;
		this.rightLeftLineDis = Mathf.Clamp(this.rightLeftLineDis, 0.4f, 2f);
		if (num > 0f)
		{
			if (this.canRight)
			{
				Vector3 zero = Vector3.zero;
				zero.y = num * this.speed;
				this.target.transform.localEulerAngles -= zero;
				this.RotateBall(num);
			}
			else if (this.hit)
			{
				float num2 = this.hit.transform.eulerAngles.y - 195f;
				Vector3 eulerAngles = GamePlay.Instance.transform.eulerAngles;
				eulerAngles.y -= num2;
				GamePlay.Instance.transform.eulerAngles = eulerAngles;
			}
		}
		else if (num < 0f)
		{
			if (this.canLeft)
			{
				Vector3 zero2 = Vector3.zero;
				zero2.y = num * this.speed;
				this.target.transform.localEulerAngles -= zero2;
				this.RotateBall(num);
			}
			else if (this.hit)
			{
				float num3 = this.hit.transform.eulerAngles.y - 160f;
				Vector3 eulerAngles2 = GamePlay.Instance.transform.eulerAngles;
				eulerAngles2.y -= num3;
				GamePlay.Instance.transform.eulerAngles = eulerAngles2;
			}
		}
		this.LastPos = UnityEngine.Input.mousePosition;
	}

	public void OnDrag(PointerEventData eventData)
	{
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (this.isDown)
		{
			return;
		}
		this.isDown = true;
		if (this.fristAction != null)
		{
			this.fristAction();
			this.fristAction = null;
		}
		this.LastPos = UnityEngine.Input.mousePosition;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		this.isDown = false;
	}

	public void Close()
	{
		base.enabled = false;
	}

	public void Rest()
	{
		base.enabled = true;
	}

	private void RotateBall(float inputX)
	{
		for (int i = 0; i < this.rotateBalls.Count; i++)
		{
			this.rotateBalls[i].RotateBall(inputX);
		}
	}
}
