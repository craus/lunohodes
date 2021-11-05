using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RSG;

public class TimeManager : Singletone<TimeManager> {
	public Promise nextFrame;

	public IPromise NextFrame() {
		if (nextFrame == null) {
			nextFrame = new Promise();
		}
		return nextFrame;
	}

	public void Update() {
		if (nextFrame != null) {
			Debug.Log($"Next frame");
			nextFrame.Resolve();
			nextFrame = null;
		}
	}
}
