using System;
using UnityEngine;

[Serializable]
public class AmbientColorSet
{
	public int ballId;

	public Color ambientColorSet = Color.white;

	public Color lightColorSet = Color.white;

	public Sprite bg;

	public Material yuanhuan;

	public Material toumingyuanhuan;

	[Header("底部圆环")]
	public Material[] dibuyuanhuan;

	public string preName;
}
