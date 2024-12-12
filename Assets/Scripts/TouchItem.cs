using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchItem
{
	private Transform target;

	public float InputX;

	[HideInInspector]
	public Vector2 LastPos;

	public TouchItem(Transform target)
	{
		this.target = target;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		this.InputX = 0f;
		this.LastPos = eventData.position;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}

	public void OnDrag(PointerEventData eventData)
	{
		this.InputX = eventData.position.x - this.LastPos.x;
		Vector3 zero = Vector3.zero;
		zero.y = this.InputX * TouchRotate.Instance.speed;
		this.target.transform.localEulerAngles -= zero;
		this.LastPos = eventData.position;
	}
}
