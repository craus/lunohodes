using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RSG;

public static class Animations {
	static IPromise current = Promise.Resolved();

	static float endTime = float.NaN;

	public static void Move(this MonoBehaviour obj, Vector3 target, float duration) {
		current = current.Then(() => obj.gameObject.AddComponent<TransformAnimator>().Animate(
			new TransformAnimator.State(target, obj.transform.rotation), 
			duration
		));
	}

	public static void Turn(this MonoBehaviour obj, Quaternion target, float duration) {
		current = current.Then(() => obj.gameObject.AddComponent<TransformAnimator>().Animate(
			new TransformAnimator.State(obj.transform.position, target), 
			duration
		));
	}
}
