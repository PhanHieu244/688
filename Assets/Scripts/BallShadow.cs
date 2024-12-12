using System;
using UnityEngine;

public class BallShadow : MonoBehaviour
{
	public LayerMask m_LayerMask;

	private Transform shadow;

	public static Vector3 shadowTempPos = new Vector3(0f, 0.02f, 0f);

	private Vector3 minSize = new Vector3(0.2f, 0.2f, 0.2f);

	private Vector3 maxSize = new Vector3(0.4f, 0.4f, 0.4f);

	private void Start()
	{
		this.shadow = UnityEngine.Object.Instantiate<GameObject>(GamePlay.Instance.shadow).transform;
		TouchRotate.Instance.rotateBalls.Add(this);
	}

	private void Update()
	{
		RaycastHit raycastHit;
		if (Physics.Raycast(base.transform.position, Vector3.down, out raycastHit, (float)this.m_LayerMask))
		{
			this.shadow.transform.position = raycastHit.point + BallShadow.shadowTempPos;
		}
		this.shadow.transform.localScale = Vector3.Lerp(this.minSize, this.maxSize, raycastHit.distance * 0.5f);
	}

	public void RotateBall(float inputX)
	{
		base.transform.Rotate(Vector3.forward * Time.deltaTime * inputX * 35f);
	}

	private void OnDestroy()
	{
		TouchRotate.Instance.rotateBalls.Remove(this);
		if (this.shadow)
		{
			UnityEngine.Object.Destroy(this.shadow.gameObject);
		}
	}
}
