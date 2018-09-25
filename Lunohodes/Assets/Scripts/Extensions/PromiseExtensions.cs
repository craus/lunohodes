using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using RSG;

#if UNITY_EDITOR
using UnityEditor;
#endif

public static class PromiseExtensions
{
	public static IPromise NextFrame(this MonoBehaviour mb) {
		return TimeManager.instance.NextFrame();
	}
}