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

	public IPromise Animate(State target, float duration) {
		startTime = Time.time;
		this.duration = duration;
		this.b = target;
		this.a = new State(transform.position, transform.rotation);
		promise = new Promise();
		return promise;
	}

	public void Update() {
		var t = Mathf.Clamp((Time.time - startTime) / duration, 0, 1);
		transform.position = Vector3.Lerp(a.position, b.position, t);
		transform.rotation = Quaternion.Lerp(a.rotation, b.rotation, t);
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
