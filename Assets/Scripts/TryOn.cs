using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TryOn : MonoBehaviour
{
	public Image img;

	public Button btnClose;

	public Button btnOK;

	public Sprite[] balls;

	private int id;

	private void Start()
	{
		
		this.btnClose.onClick.AddListener(delegate
		{
			UnityEngine.Object.Destroy(base.gameObject);
			Time.timeScale = 1f;
		});
		this.btnOK.onClick.AddListener(new UnityAction(this.OnbtnOKClick));
		/*if (!Ads.Instance.HasVideo())
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}*/
		if (Global.showTryOn)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Global.showTryOn = true;
		this.id = CarManager.Instance.GetLockedCarID();
		if (this.id == -1)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			Time.timeScale = 0f;
			this.img.sprite = this.balls[this.id];
		}
	}

	private void OnbtnOKClick()
	{
        /*
		Ads.Instance.WatchVideo(delegate
		{
			Time.timeScale = 1f;
			UnityEngine.Object.Destroy(base.gameObject);
			CarManager.Instance.tryOnCar = CarManager.Instance.cars[this.id];
			GamePlay.Instance.SpawnNormalLevelPlayer();
			if (TouchRotate.Instance.fristAction != null)
			{
				TouchRotate.Instance.fristAction();
				TouchRotate.Instance.fristAction = null;
			}
			EventRecord.Instance.EventSet("videoSkin", string.Empty);
		});
        */
        /*if (AdsControl.Instance.GetRewardAvailable())
        {
            AdsControl.Instance.PlayDelegateRewardVideo(delegate
            {


                Time.timeScale = 1f;
                UnityEngine.Object.Destroy(base.gameObject);
                CarManager.Instance.tryOnCar = CarManager.Instance.cars[this.id];
                GamePlay.Instance.SpawnNormalLevelPlayer();
                if (TouchRotate.Instance.fristAction != null)
                {
                    TouchRotate.Instance.fristAction();
                    TouchRotate.Instance.fristAction = null;
                }
                EventRecord.Instance.EventSet("videoSkin", string.Empty);
            });
        }*/

    }
}
