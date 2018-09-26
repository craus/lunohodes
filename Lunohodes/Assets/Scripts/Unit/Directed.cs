using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Directed : MonoBehaviour {
	public int direction;
	public const int DIRECTIONS = 4;

	public Vector3 EulerAngles() {
		return Vector3.up * 90 * (1 - direction);
	}

	[ContextMenu("Direct")]
	public void Direct() {
		transform.eulerAngles = EulerAngles();
	}

	public void Direct(int direction) {
		this.direction = direction;
		Direct();
	}

	public void Update() {
		if (Extensions.Editor()) {
			Direct();
		}
	}

	public void Rotate(int delta, bool animate = false) {
		direction += delta;
		direction = direction.modulo(DIRECTIONS);
		if (animate) {
			this.Turn(Quaternion.Euler(EulerAngles()), 0.1f);
		} else {
			Direct();
		}
	}
}
