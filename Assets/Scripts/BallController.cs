using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
	public Rigidbody m_Rigidbody;

	[SerializeField]
	private bool jumping;

	private LayerMask m_LayerMask = 1024;

	public float jumpForce = 5f;

	public float rotationSpeed = 10f;

	public Vector3 maxSize;

	public Vector3 minSize;

	private bool donghua;

	private float donghuatimer;

	public Transform aniTransform;

	public AnimationCurve donghuaAnimation;

	private Vector3 temp = Vector3.one;

	public string effectName;

	public int colorId;

	public bool wudi;

	private float ssTimer;

	private bool subcolora;

	private float bodytimer;

	public GameObject bodyObj;

	public GameObject shieldObj;

	private bool shieldOpen;

	private GameObject shieldClone;

	private void Update()
	{
		if (this.donghua)
		{
			this.donghuatimer += Time.deltaTime;
			if (this.donghuatimer > 0.8f)
			{
				this.aniTransform.localScale = Vector3.one;
				this.donghuatimer = 0f;
				this.donghua = false;
				return;
			}
			float num = this.donghuaAnimation.Evaluate(this.donghuatimer);
			this.temp.x = num;
			this.temp.y = 2f - num;
			this.aniTransform.localScale = this.temp;
		}
		if (this.wudi)
		{
			this.ssTimer += Time.deltaTime;
			if (this.subcolora)
			{
				this.bodytimer -= Time.deltaTime * 10f;
				if (this.bodytimer <= 0f)
				{
					this.bodyObj.gameObject.SetActive(false);
					this.subcolora = false;
				}
			}
			else
			{
				this.bodytimer += Time.deltaTime * 10f;
				if (this.bodytimer >= 1f)
				{
					this.bodyObj.gameObject.SetActive(true);
					this.subcolora = true;
				}
			}
			if ((double)this.ssTimer > 1.5)
			{
				this.bodyObj.gameObject.SetActive(true);
				this.ssTimer = 0f;
				this.wudi = false;
			}
		}
	}

	private void FixedUpdate()
	{
		this.jumping = false;
		if ((double)this.m_Rigidbody.velocity.y <= -0.01)
		{
			this.jumping = false;
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Platform"))
		{
			RaycastHit raycastHit;
			if (Physics.Raycast(base.transform.position, Vector3.down, out raycastHit, 1024f) && raycastHit.collider.CompareTag("Platform"))
			{
				GamePlay.Instance.GetPa(raycastHit.point);
			}
			this.Hop();
		}
		else if (other.gameObject.CompareTag("HopPlatform"))
		{
			RaycastHit raycastHit2;
			if (Physics.Raycast(base.transform.position, Vector3.down, out raycastHit2))
			{
				PlatformObj component = other.transform.parent.gameObject.GetComponent<PlatformObj>();
				if (component.locked)
				{
					GamePlay.Instance.GetPa(raycastHit2.point);
					this.Hop();
				}
				else
				{
					SoundManager.Instance.PlayAudio2("hit glass");
					if (component.isReward)
					{
						component.Clear();
						GamePlay.Instance.NormalUp();
						Global.Shake();
					}
					else
					{
						for (int i = 0; i < component.pians.Length; i++)
						{
							if (Vector3.Distance(raycastHit2.point, component.pians[i].transform.position) < 0.2f && !component.turn)
							{
								GameObject @object = PoolManager.Instance.GetObject("Partical_hitextrm");
								@object.SetActive(true);
								@object.transform.position = raycastHit2.point;
								component.Clear();
								GamePlay.Instance.PerfectUp();
								Global.Shake();
								return;
							}
						}
						GameObject object2 = PoolManager.Instance.GetObject(GamePlay.Instance.CurrentBgAndColor.preName);
						object2.SetActive(true);
						object2.transform.position = raycastHit2.point;
						component.Clear();
						GamePlay.Instance.NormalUp();
						Global.Shake();
					}
				}
			}
		}
		else if (other.gameObject.CompareTag("AnNui"))
		{
			this.Hop();
			AnNuiObj component2 = other.gameObject.GetComponent<AnNuiObj>();
			component2.OnCollision();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Coins"))
		{
			SoundManager.Instance.PlayAudio2("hit_coin");
			GameObject @object = PoolManager.Instance.GetObject("Coins");
			@object.GetComponent<CoinMove>().Init(other.transform.position);
			UnityEngine.Object.Destroy(other.gameObject);
			Global.Shake();
		}
		else if (other.gameObject.CompareTag("ZhangAi") && !this.wudi)
		{
			if (this.shieldOpen)
			{
				if (this.shieldClone != null)
				{
					UnityEngine.Object.Destroy(this.shieldClone);
					UnityEngine.Object.Destroy(other.gameObject);
				}
				this.shieldOpen = false;
				this.wudi = true;
			}
			else
			{
				GamePlay.Instance.GameOver(other.gameObject);
				Global.Shake();
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
	}

	private void OnDestroy()
	{
		this.m_Rigidbody = null;
		this.aniTransform = null;
		this.donghuaAnimation = null;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.right * TouchRotate.Instance.rightLeftLineDis);
		Gizmos.DrawLine(base.transform.position, base.transform.position + Vector3.left * TouchRotate.Instance.rightLeftLineDis);
	}

	public void GetLife()
	{
		base.gameObject.SetActive(true);
		base.transform.position = base.transform.position + Vector3.up * 1.2f;
		this.wudi = true;
		this.m_Rigidbody.velocity = Vector3.zero;
		this.shieldOpen = true;
		this.shieldClone = UnityEngine.Object.Instantiate<GameObject>(this.shieldObj);
		this.shieldClone.transform.SetParent(base.transform, false);
	}

	private void Hop()
	{
		if (this.jumping)
		{
			return;
		}
		SoundManager.Instance.PlayAudio("hit plat");
		this.m_Rigidbody.velocity = Vector3.zero;
		this.m_Rigidbody.AddForce(Vector3.up * this.jumpForce, ForceMode.Impulse);
		this.jumping = true;
		if (this.aniTransform)
		{
			this.donghua = true;
		}
	}
}
