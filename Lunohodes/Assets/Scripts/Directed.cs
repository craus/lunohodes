using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Directed : MonoBehaviour {
	public int direction;

	[ContextMenu("Direct")]
	public void Direct() {
		transform.eulerAngles = Vector3.up * 90 * (1 - direction);
	}

	public void Update() {
		if (Extensions.Editor()) {
			Direct();
		}
	}

	public void Rotate(int delta) {
		direction += delta;
		Direct();
	}
}
