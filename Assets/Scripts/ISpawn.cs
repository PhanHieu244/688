using System;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawn
{
	void Spwan(PlatformObj platformObj, List<Transform> jianci, Transform[] wall);
}
