using EZCameraShake;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ShakeDemo : MonoBehaviour
{
	private delegate float Slider(float val, string prefix, float min, float max, int pad);

	private Vector3 posInf = new Vector3(0.25f, 0.25f, 0.25f);

	private Vector3 rotInf = new Vector3(1f, 1f, 1f);

	private float magn = 1f;

	private float rough = 1f;

	private float fadeIn = 0.1f;

	private float fadeOut = 2f;

	private bool modValues;

	private bool showList;

	private CameraShakeInstance shake;

	private static ShakeDemo.Slider __f__am_cache0;

	private void OnGUI()
	{
		if (UnityEngine.Input.GetKeyDown(KeyCode.R))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
		}
		ShakeDemo.Slider slider = delegate(float val, string prefix, float min, float max, int pad)
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label(prefix, new GUILayoutOption[]
			{
				GUILayout.MaxWidth((float)pad)
			});
			val = GUILayout.HorizontalSlider(val, min, max, new GUILayoutOption[0]);
			GUILayout.Label(val.ToString("F2"), new GUILayoutOption[]
			{
				GUILayout.MaxWidth(50f)
			});
			GUILayout.EndHorizontal();
			return val;
		};
		GUI.Box(new Rect(10f, 10f, 250f, (float)(Screen.height - 15)), "Make-A-Shake");
		GUILayout.BeginArea(new Rect(29f, 40f, 215f, (float)(Screen.height - 40)));
		GUILayout.Label("--Position Infleunce--", new GUILayoutOption[0]);
		this.posInf.x = slider(this.posInf.x, "X", 0f, 4f, 25);
		this.posInf.y = slider(this.posInf.y, "Y", 0f, 4f, 25);
		this.posInf.z = slider(this.posInf.z, "Z", 0f, 4f, 25);
		GUILayout.Label("--Rotation Infleunce--", new GUILayoutOption[0]);
		this.rotInf.x = slider(this.rotInf.x, "X", 0f, 4f, 25);
		this.rotInf.y = slider(this.rotInf.y, "Y", 0f, 4f, 25);
		this.rotInf.z = slider(this.rotInf.z, "Z", 0f, 4f, 25);
		GUILayout.Label("--Other Properties--", new GUILayoutOption[0]);
		this.magn = slider(this.magn, "Magnitude:", 0f, 10f, 75);
		this.rough = slider(this.rough, "Roughness:", 0f, 20f, 75);
		this.fadeIn = slider(this.fadeIn, "Fade In:", 0f, 10f, 75);
		this.fadeOut = slider(this.fadeOut, "Fade Out:", 0f, 10f, 75);
		GUILayout.Label("--Saved Shake Instance--", new GUILayoutOption[0]);
		GUILayout.Label("You can save shake instances and modify their properties at runtime.", new GUILayoutOption[0]);
		if (this.shake == null && GUILayout.Button("Create Shake Instance", new GUILayoutOption[0]))
		{
			this.shake = CameraShaker.Instance.StartShake(this.magn, this.rough, this.fadeIn);
			this.shake.DeleteOnInactive = false;
		}
		if (this.shake != null)
		{
			if (GUILayout.Button("Delete Shake Instance", new GUILayoutOption[0]))
			{
				this.shake.DeleteOnInactive = true;
				this.shake.StartFadeOut(this.fadeOut);
				this.shake = null;
			}
			if (this.shake != null)
			{
				GUILayout.BeginHorizontal(new GUILayoutOption[0]);
				if (GUILayout.Button("Fade Out", new GUILayoutOption[0]))
				{
					this.shake.StartFadeOut(this.fadeOut);
				}
				if (GUILayout.Button("Fade In", new GUILayoutOption[0]))
				{
					this.shake.StartFadeIn(this.fadeIn);
				}
				GUILayout.EndHorizontal();
				this.modValues = GUILayout.Toggle(this.modValues, "Modify Instance Values", new GUILayoutOption[0]);
				if (this.modValues)
				{
					this.shake.ScaleMagnitude = this.magn;
					this.shake.ScaleRoughness = this.rough;
					this.shake.PositionInfluence = this.posInf;
					this.shake.RotationInfluence = this.rotInf;
				}
			}
		}
		GUILayout.Label("--Shake Once--", new GUILayoutOption[0]);
		GUILayout.Label("You can simply have a shake that automatically starts and stops too.", new GUILayoutOption[0]);
		if (GUILayout.Button("Shake!", new GUILayoutOption[0]))
		{
			CameraShakeInstance cameraShakeInstance = CameraShaker.Instance.ShakeOnce(this.magn, this.rough, this.fadeIn, this.fadeOut);
			cameraShakeInstance.PositionInfluence = this.posInf;
			cameraShakeInstance.RotationInfluence = this.rotInf;
		}
		GUILayout.EndArea();
		float height;
		if (!this.showList)
		{
			height = 120f;
		}
		else
		{
			height = 120f + (float)CameraShaker.Instance.ShakeInstances.Count * 130f;
		}
		GUI.Box(new Rect((float)(Screen.width - 310), 10f, 300f, height), "Shake Instance List");
		GUILayout.BeginArea(new Rect((float)(Screen.width - 285), 40f, 255f, (float)(Screen.height - 40)));
		GUILayout.Label("All shake instances are saved and stacked as long as they are active.", new GUILayoutOption[0]);
		this.showList = GUILayout.Toggle(this.showList, "Show List", new GUILayoutOption[0]);
		if (this.showList)
		{
			int num = 1;
			foreach (CameraShakeInstance current in CameraShaker.Instance.ShakeInstances)
			{
				string str = current.CurrentState.ToString();
				GUILayout.Label(string.Concat(new object[]
				{
					"#",
					num,
					": Magnitude: ",
					current.Magnitude.ToString("F2"),
					", Roughness: ",
					current.Roughness.ToString("F2")
				}), new GUILayoutOption[0]);
				GUILayout.Label("      Position Influence: " + current.PositionInfluence, new GUILayoutOption[0]);
				GUILayout.Label("      Rotation Influence: " + current.RotationInfluence, new GUILayoutOption[0]);
				GUILayout.Label("      State: " + str, new GUILayoutOption[0]);
				GUILayout.Label("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -", new GUILayoutOption[0]);
				num++;
			}
		}
		GUILayout.EndArea();
	}
}
