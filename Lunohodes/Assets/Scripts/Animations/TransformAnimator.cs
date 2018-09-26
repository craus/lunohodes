using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using RSG;

public class TransformAnimator : MonoBehaviour {
	public float startTime;
	public State a;
	public State b;
	public float duration;

	public Promise promise;

	public class State {
		public Vector3 position;
		public Quaternion rotation;

		public State(Vector3 position, Quaternion rotation) {
			this.position = position;
			this.rotation = rotation;
		}
	}

	public float time {
		get {
			return Time.realtimeSinceStartup;
		}
	}

	public IPromise Animate(State target, float duration, float startTime = float.NaN) {
		duration = 0.25f;
		if (float.IsNaN(startTime)) {
			startTime = time;
		}
		this.duration = duration;
		this.b = target;
		this.a = new State(transform.position, transform.rotation);

		promise = new Promise();

		LateUpdate();

		return promise;
	}

	public void LateUpdate() {
		var t = Mathf.Clamp((time - startTime) / duration, 0, 1);
		//var r = Mathf.Sin((2 * t - 1) * Mathf.PI / 2);
		var r = t;
		transform.position = Vector3.Lerp(a.position, b.position, r);
		transform.rotation = Quaternion.Lerp(a.rotation, b.rotation, r);
		if (t == 1) {
			FinishAnimation();
		}
	}

	public void FinishAnimation() {
		promise.Resolve();
		promise = null;
		Destroy(this);
	}

	public void OnDestroy() {
		if (promise != null) {
			promise.Resolve();
		}
	}
}
